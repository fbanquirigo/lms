namespace SaG.Services.Exceptions
{
    public class InvalidOperationHourLimitException : BaseException
    {
        private readonly string message;

        public override string Message
        {
            get { return this.message; }
        }

        public InvalidOperationHourLimitException(int timeBlock)
        {
            this.message = string.Format("Invalid time block value: {0}", timeBlock);
        }
    }
}
