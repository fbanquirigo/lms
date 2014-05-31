using NHibernate;

namespace SaG.Data.NHibernate
{
    public interface ISessionManager
    {
        ISessionFactory CreateSessionFactory();
    }
}