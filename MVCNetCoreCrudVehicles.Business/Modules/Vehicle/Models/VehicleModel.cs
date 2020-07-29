

using System;
using MVCNetCoreCrudVehicles.Business.Modules.Base.Models;

namespace MVCNetCoreCrudVehicles.Business.Modules.Vehicle.Models
{
    public class VehicleModel : IBaseModel
    {
        public VehicleModel()
        {

        }

        public Guid Id { get; set; }
                
        public string Patent { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int NumberOfDoors { get; set; }

        public string Owner { get; set; }
    }
}
