namespace SaG.API.Models.Responses
{
    /// <summary>
    /// Response message status.
    /// </summary>
    public enum ResponseStatus
    {
        /// <summary>
        /// Ok
        /// </summary>
        Ok = 0,

        /// <summary>
        /// Invalid credentials
        /// </summary>
        InvalidCredentials = 1,

        /// <summary>
        /// Error
        /// </summary>
        Error = 2,

        /// <summary>
        /// Unauthorized
        /// </summary>
        UnAuthorized = 3,

        /// <summary>
        /// Unhandled exception
        /// </summary>
        UnhandledException = 4
    }
}