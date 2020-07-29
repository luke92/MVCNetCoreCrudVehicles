using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCNetCoreCrudVehicles.Business.Modules.Owner;

namespace MVCNetCoreCrudVehicles.Web.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IOwnerModule _ownerModule;

        public UsersController(IOwnerModule ownerModule)
        {
            _ownerModule = ownerModule;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var owners = await _ownerModule.GetOwners();

            return Ok(owners);
        }
    }
}