namespace SaG.Business
{
    public class OperatorUser : IOperator
    {
        public string LoginName { get; private set; }  

        public int Id { get; private set; }

        public OperatorPriorityLevel PriorityLevel { get; private set; }

        public OperatorUser(int id, string loginName, OperatorPriorityLevel priority)
        {
            Id = id;
            LoginName = loginName;
            PriorityLevel = priority;
        }
    }
}
