using MVCNetCoreCrudVehicles.Business.Modules.Owner.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVCNetCoreCrudVehicles.Business.Modules.Owner
{
    public interface IOwnerModule
    {
        Task<ICollection<OwnerModel>> GetOwners();
    }
}
