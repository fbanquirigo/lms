using System;

namespace SaG.Services.Exceptions
{
    public class InvalidOperationDateRangeException : BaseException
    {
        private readonly string message;

        public override string Message
        {
            get { return this.message; }
        }

        public InvalidOperationDateRangeException(DateTime date, string atmId)
        {
            this.message = string.Format("Date {0} is invalid for ATM {1}", date.ToString("d"), atmId);
        }
    }
}
