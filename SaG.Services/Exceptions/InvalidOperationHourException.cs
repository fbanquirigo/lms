namespace SaG.Services.Exceptions
{
    public class InvalidOperationHourException : BaseException
    {
        private readonly string message;

        public override string Message
        {
            get { return this.message; }
        }

        public InvalidOperationHourException(int hour)
        {
            this.message = string.Format("{0} is an invalid operation hour.  Must be between 0 to 23.", hour);
        }
    }
}
