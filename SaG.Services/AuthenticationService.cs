using System;
using SaG.Business;
using SaG.Business.Models;
using SaG.Core;
using SaG.Data.Repositories;
using SaG.Services.Contracts;
using SaG.Data;

namespace SaG.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRandomGenerator randomGenerator;
        private readonly IAPIAuthCodeRepository authCodeRepository;
        private readonly IAPIClientRepository apiClientRepository;
        private readonly IAPIAccessTokenRepository apiAccessTokenRepository;
        private readonly IDateHelper dateHelper;
        private readonly IAuditTrailService auditTrail;
        private readonly IRepository<Accessor> accessorRepository;

        public AuthenticationService(IAPIAuthCodeRepository authCodeRepository, 
            IRandomGenerator randomGenerator, IDateHelper dateHelper,
            IAPIClientRepository apiClientRepository, IAPIAccessTokenRepository apiAccessTokenRepository, 
            IAuditTrailService auditTrail, IRepository<Accessor> accessorRepository)
        {
            this.authCodeRepository = authCodeRepository;
            this.apiClientRepository = apiClientRepository;
            this.apiAccessTokenRepository = apiAccessTokenRepository;
            this.randomGenerator = randomGenerator;
            this.dateHelper = dateHelper;
            this.auditTrail = auditTrail;
            this.accessorRepository = accessorRepository;
        }

        public string GenerateAuthCode(APIClient client, Operator user)
        {
            if(client == null)
                throw new ArgumentNullException("client");

            if(user == null)
                throw new ArgumentNullException("user");

            string authCode = this.randomGenerator.AuthCodeString();
            while (this.authCodeRepository.AuthCodeExists(authCode))
                authCode = this.randomGenerator.AuthCodeString();

            DateTime issuedDate = this.dateHelper.GetIssuedDate();
            DateTime expirationDate = this.dateHelper.GetExpirationDate(issuedDate);
            var apiAuthCode = new APIAuthCode
            {
                AuthCode = authCode,
                Client = client,
                Operator = user,
                IssuedOn = issuedDate,
                ExpiresOn = expirationDate
            };

            this.authCodeRepository.Save(apiAuthCode);
            return apiAuthCode.AuthCode;
        }

        public bool ValidateAuthCode(string authCode, string clientId)
        {
            APIAuthCode code = this.authCodeRepository.GetAuthCode(authCode);
            if (code == null)
                return false;

            return code.Client.ConsumerKey == clientId && !code.IsExpired() && !code.Tokenized;
        }

        public string GenerateAccessToken(string authCode, string clientId)
        {
            APIAuthCode code = this.authCodeRepository.GetAuthCode(authCode);
            if(code == null)
                throw new ArgumentException("authCode: Invalid authorization code.");

            APIClient client = this.apiClientRepository.GetApiClient(clientId);
            if(client == null)
                throw new ArgumentException("clientId: Invalid client.");

            string accessTokenString = this.randomGenerator.AccessTokenString();  
            while(this.apiAccessTokenRepository.AccessTokenExists(accessTokenString, client.ConsumerKey))
                accessTokenString = this.randomGenerator.AccessTokenString();

            DateTime issuedDate = this.dateHelper.GetIssuedDate();
            DateTime expirationDate = this.dateHelper.GetExpirationDate(issuedDate);
            code.Tokenized = true;
            var accessToken = new APIAccessToken
                              {
                                AccessToken = accessTokenString,
                                AuthCode = code,
                                Client = client,
                                IssuedOn = issuedDate,
                                ExpiresOn = expirationDate,
                                Operator = code.Operator
                              };
            this.apiAccessTokenRepository.Save(accessToken);
            return accessToken.AccessToken;
        }


        public bool ValidAccessToken(string accessToken)
        {
            APIAccessToken token = this.apiAccessTokenRepository.GetAccessToken(accessToken);
            if (token == null)
                return false;

            return !token.IsExpired();
        }    

        public APIAccessToken GetAccessToken(string accessToken)
        {
            return this.apiAccessTokenRepository.GetAccessToken(accessToken);
        }

        public bool KillAccessToken(string accessToken)
        {
            if (!ValidAccessToken(accessToken))
                return false;

            var accessTokenKill = this.apiAccessTokenRepository.GetAccessToken(accessToken);
            accessTokenKill.IsExpired = true;
            this.apiAccessTokenRepository.Save(accessTokenKill);   

            Accessor accessor = this.accessorRepository.GetById(accessTokenKill.Operator.AccessorId);
            this.auditTrail.Audit(AuditType.SignOff, "Operation Code", accessTokenKill.Operator.Login,
                string.Format("{0}, {1}", accessor.LastName, accessor.FirstName));
            return true;
        }
    }
}
