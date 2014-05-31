namespace SaG.Services.Exceptions
{
    public class InvalidTouchKeyPositionException : BaseException
    {
        private readonly string message;

        public override string Message
        {
            get { return this.message; }
        }

        public InvalidTouchKeyPositionException(string touchKeyId)
        {
            this.message = string.Format("Invalid touch key position: TouchKey {0}", touchKeyId);
        }
    }
}
