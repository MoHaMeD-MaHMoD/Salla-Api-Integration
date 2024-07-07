namespace SallaIntegration.Models
{
    public class UserInformation
    {
        public class Data
        {
            public int id { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string mobile { get; set; }
            public string role { get; set; }
            public string created_at { get; set; }
            public Merchant merchant { get; set; }
        }

        public class Merchant
        {
            public int id { get; set; }
            public string username { get; set; }
            public string name { get; set; }
            public string avatar { get; set; }
            public string store_location { get; set; }
            public string plan { get; set; }
            public string status { get; set; }
            public string domain { get; set; }
            public string tax_number { get; set; }
            public string commercial_number { get; set; }
            public string created_at { get; set; }
        }

        public class Root
        {
            public int status { get; set; }
            public bool success { get; set; }
            public Data data { get; set; }
        }

    }
}
