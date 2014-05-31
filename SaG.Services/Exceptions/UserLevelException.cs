namespace SaG.Services.Exceptions
{
    public class UserLevelException : BaseException
    {
        private readonly string message;

        public override string Message
        {
            get { return this.message; }
        }

        public UserLevelException(string userId)
        {
            this.message = string.Format("Invalid user level: {0}", userId);
        }
    }
}
