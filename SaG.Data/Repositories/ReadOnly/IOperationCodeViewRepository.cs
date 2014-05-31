using System.Collections;
using System.Collections.Generic;
using SaG.Business.Models;
using SaG.Business.Models.Views;

namespace SaG.Data.Repositories.ReadOnly
{
    public interface IOperationCodeViewRepository
    {
        OperationCodeDetailView GetActiveOperationCodes(int accessorId, string locationId);
    }
}
