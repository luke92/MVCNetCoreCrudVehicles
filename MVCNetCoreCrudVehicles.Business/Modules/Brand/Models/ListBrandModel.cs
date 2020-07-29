using System.Collections.Generic;

namespace MVCNetCoreCrudVehicles.Business.Modules.Brand.Models
{
    public class ListBrandModel
    {
        public List<BrandModel> Brands { get; set; }

        public ListBrandModel()
        {
            var brands = new List<string>{ "Fiat", "Peugeot", "Audi", "Volkswagen", "Chevrolet", "Ford" };

            foreach(string brand in brands)
            {
                Brands.Add(new BrandModel(brand));
            }
            
        }
    }
}
