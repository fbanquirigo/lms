using SaG.Business.Models;
using SaG.Data;
using SaG.Services.Contracts;

namespace SaG.Services
{
    public class AccessorService : IAccessorService
    {
        private readonly IRepository<Accessor> accessorRepository;

        public AccessorService(IRepository<Accessor> accessorRepository)
        {
            this.accessorRepository = accessorRepository;
        }

        public Accessor GetAccessor(int accessorId)
        {
            return this.accessorRepository.GetById(accessorId);
        }
    }
}
