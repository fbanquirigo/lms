using SaG.Business.Models;
using SaG.Data.Repositories;
using SaG.Services.Contracts;

namespace SaG.Services
{
    public class TouchKeyService : ITouchKeyService
    {
        private readonly ITouchKeyRepository touchKeyRepository;
        private readonly ITouchKeyPosRepository touchKeyPosRepository;

        public TouchKeyService(ITouchKeyRepository touchKeyRepository, ITouchKeyPosRepository touchKeyPosRepository)
        {
            this.touchKeyRepository = touchKeyRepository;
            this.touchKeyPosRepository = touchKeyPosRepository;
        }  

        public bool VerifyTouchKey(int accessorId, out TouchKey key)
        {
            key = this.touchKeyRepository.Get(accessorId);
            return key != null;
        }

        public bool VerifyTouchKey(string touchKey, int accessorId, out TouchKey key)
        {
            key = this.touchKeyRepository.Get(touchKey, accessorId);
            return key != null;
        }


        public bool VerifyTouchKeyPos(string touchKey, int command, int dispEntity, out TouchKeyPos pos)
        {
            pos = this.touchKeyPosRepository.Get(touchKey, command, dispEntity);
            return pos != null;
        }
    }
}
