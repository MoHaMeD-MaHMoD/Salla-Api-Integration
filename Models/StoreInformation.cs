namespace SallaIntegration.Models
{
    public class StoreInformation
    {
        public class Data
        {
            public int id { get; set; }
            public string name { get; set; }
            public string entity { get; set; }
            public string email { get; set; }
            public string avatar { get; set; }
            public string plan { get; set; }
            public string type { get; set; }
            public string status { get; set; }
            public bool verified { get; set; }
            public string currency { get; set; }
            public string domain { get; set; }
            public string description { get; set; }
            public Licenses licenses { get; set; }
            public Social social { get; set; }
        }

        public class Licenses
        {
            public string tax_number { get; set; }
            public object commercial_number { get; set; }
            public object freelance_number { get; set; }
        }

        public class Root
        {
            public int status { get; set; }
            public bool success { get; set; }
            public Data data { get; set; }
        }

        public class Social
        {
            public string telegram { get; set; }
            public string twitter { get; set; }
            public string facebook { get; set; }
            public string maroof { get; set; }
            public string youtube { get; set; }
            public string snapchat { get; set; }
            public string whatsapp { get; set; }
            public string appstore_link { get; set; }
            public string googleplay_link { get; set; }
        }

    }
}
