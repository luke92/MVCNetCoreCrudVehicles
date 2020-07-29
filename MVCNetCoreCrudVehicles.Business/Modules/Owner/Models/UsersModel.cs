using System.Collections.Generic;


namespace MVCNetCoreCrudVehicles.Business.Modules.Owner.Models
{
    public class Datum
    {
        public int id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
    }

    public class Ad
    {
        public string company { get; set; }
        public string url { get; set; }
        public string text { get; set; }
    }

    public class UsersModel
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public IList<Datum> data { get; set; }
        public Ad ad { get; set; }
    }
}
