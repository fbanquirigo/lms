using SaG.Business.Models;

namespace SaG.Services.Contracts
{
    public interface ITouchKeyService
    {
        bool VerifyTouchKey(string touchKey, int accessorId, out TouchKey key);

        bool VerifyTouchKey(int accessorId, out TouchKey key);

        bool VerifyTouchKeyPos(string touchKey, int command, int dispEntity, out TouchKeyPos pos);
    }
}