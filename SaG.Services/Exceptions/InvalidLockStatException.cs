namespace SaG.Services.Exceptions
{
    public class InvalidLockStatException : BaseException
    {
        private readonly string message;

        public override string Message
        {
            get { return this.message; }
        }

        public InvalidLockStatException(int lockStat)
        {
            this.message = string.Format("Invalid lock status: {0}", lockStat);
        }
    }
}
