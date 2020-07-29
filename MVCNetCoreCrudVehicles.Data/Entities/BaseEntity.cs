using System;
using System.ComponentModel.DataAnnotations;

namespace MVCNetCoreCrudVehicles.Data.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            DeletedDate = null;

            Deleted = false;
        }

        public void Delete()
        {
            Deleted = true;
            DeletedDate = DateTime.Now;
        }

        public void SetModification()
        {
            ModifiedDate = DateTime.Now;
        }
    }
}
