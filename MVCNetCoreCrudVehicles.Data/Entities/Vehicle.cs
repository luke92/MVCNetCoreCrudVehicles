using System.ComponentModel.DataAnnotations;

namespace MVCNetCoreCrudVehicles.Data.Entities
{
    public class Vehicle : BaseEntity
    {
        [Required]
        public string Patent { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        public int NumberOfDoors { get; set; }

        [Required]
        public string Owner { get; set; }

        public Vehicle() : base()
        {
            
        }


    }
}
