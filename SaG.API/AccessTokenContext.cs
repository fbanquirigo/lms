namespace SaG.API
{
    /// <summary>
    /// AccessTokenContext
    /// </summary>
    public class AccessTokenContext : IAccessTokenContext
    {
        /// <summary>
        /// Access token
        /// </summary>
        public string AccessToken
        {
            get; set;
        }
    }
}