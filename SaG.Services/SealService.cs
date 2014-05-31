using System;
using System.IO;
using SaG.Business.Models;
using SaG.Core;
using SaG.Core.Logging;
using SaG.Services.Contracts;

namespace SaG.Services
{
    public class SealService : ISealService
    {
        private readonly IFileHelper fileHelper;
        private readonly IConvertHelper convertHelper;
        private readonly IPathHelper pathHelper;
        private readonly ILogger logger;

        public SealService(IFileHelper fileHelper, IPathHelper pathHelper,
            IConvertHelper convertHelper, ILogger logger)
        {
            this.fileHelper = fileHelper;
            this.pathHelper = pathHelper;
            this.logger = logger;
            this.convertHelper = convertHelper;
        }

        public Seal GetSeal(string operationResult, SealType sealType)
        {
            switch (sealType)
            {
                case SealType.A:
                    return GetSeal(operationResult, "ASealInfo");
                case SealType.B:
                    return GetSeal(operationResult, "BSealInfo");
                default:
                    return null;
            }
        }

        private Seal GetSeal(string operationResult, string name)
        {  
            var sealKey = 0;
            int seal = this.convertHelper.ToInt32(operationResult, 10);
            sealKey = ((seal >= 18 ? 18 : seal) <= 2 ? 2 : sealKey) + (seal + 0x3);   
            string sealPath = this.pathHelper.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Seals\\{0}", name));
            if (!this.fileHelper.Exists(sealPath))
            {
                this.logger.ErrorFormat("Error in SealService: GetSeal.  Unable to locate seal file: {0}", sealPath);
                throw new FileNotFoundException("Seal File Not Found", sealPath);    
            }

            string[] lines = this.fileHelper.ReadAllLines(sealPath);    
            var sealResults = new Seal();       
            if (lines.Length > sealKey) 
                sealResults.TableValue = Convert.ToInt32(lines.GetValue(sealKey)); 
            sealResults.Key = (seal >= 2 ? 2 : seal) + 0xffff;
            return sealResults;   
        }
    }
}
