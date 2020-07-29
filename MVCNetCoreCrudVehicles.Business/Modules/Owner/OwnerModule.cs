using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MVCNetCoreCrudVehicles.Business.Modules.Owner.Models;
using Newtonsoft.Json;

namespace MVCNetCoreCrudVehicles.Business.Modules.Owner
{
    public class OwnerModule : IOwnerModule
    {
        private readonly string _uri;

        public OwnerModule(string uri)
        {
            _uri = uri;
        }

        public async Task<ICollection<OwnerModel>> GetOwners()
        {
            var list = new List<OwnerModel>();

            try
            {
                using (HttpClient client = new HttpClient())
                {

                    var response = await client.GetAsync(_uri);
                    response.EnsureSuccessStatusCode();
                    
                    var json = await response.Content.ReadAsStringAsync();
                    var users = JsonConvert.DeserializeObject<UsersModel>(json);

                    if(users != null)
                    {
                        foreach(var user in users.data)
                        {
                            list.Add(new OwnerModel
                            {
                                Avatar = user.avatar,
                                FirstName = user.first_name,
                                LastName = user.last_name
                            });
                        }
                    }
                    
                    
                }
            }
            catch
            {
                //TODO
            }
            return list;
        }
    }
}
