namespace SaG.Services.Exceptions
{
    public class CodeAlreadyClosedException : BaseException
    {
        private readonly string message;

        public override string Message
        {
            get { return this.message; }
        }

        public CodeAlreadyClosedException(int operationCode)
        {
            this.message = string.Format("Operation Code: {0} is already closed.", operationCode);
        }
    }
}
