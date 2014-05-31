using SaG.Business.Models;

namespace SaG.Data.Repositories
{
    public interface ITouchKeyPosRepository
    {
        TouchKeyPos Get(string touchKey, int command, int dispEntity);
    }
}