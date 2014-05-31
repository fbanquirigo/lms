namespace SaG.Services.Exceptions
{
    public class MethodArgumentException : BaseException
    {
        private readonly string message;

        public override string Message
        {
            get { return this.message; }
        }

        public string Parameter
        {
            get; private set;
        }

        public MethodArgumentException(string parameter)
        {
            Parameter = parameter;
        }

        public MethodArgumentException(string parameter, string message)
        {
            this.message = message;
            Parameter = parameter;
        }
    }
}
