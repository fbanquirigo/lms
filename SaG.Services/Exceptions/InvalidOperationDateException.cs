namespace SaG.Services.Exceptions
{
    public class InvalidOperationDateException : BaseException
    {
        private readonly string message;

        public override string Message
        {
            get { return this.message; }
        }

        public InvalidOperationDateException(string operDate)
        {
            this.message = string.Format("Invalid Operation Date: {0}", operDate);
        }
    }
}
