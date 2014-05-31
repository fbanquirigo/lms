namespace SaG.API
{
    public interface ISessionStateProvider
    {
        object this[string key] { get; set; }

        void Remove(string key); 
    }
}