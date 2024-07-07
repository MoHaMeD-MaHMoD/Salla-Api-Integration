using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SallaIntegration.Models
{
    public class OrderJsonResponse
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Customized
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Date
        {
            public string date { get; set; }
            public int timezone_type { get; set; }
            public string timezone { get; set; }
        }

        public class Datum
        {
            public int id { get; set; }
            public int reference_id { get; set; }
            public Total total { get; set; }
            public Date date { get; set; }
            public Status status { get; set; }
            public bool can_cancel { get; set; }
            public bool can_reorder { get; set; }
            public string payment_method { get; set; }
            public bool is_pending_payment { get; set; }
            public int pending_payment_ends_at { get; set; }
            public List<Item> items { get; set; }
        }

        public class Item
        {
            public string name { get; set; }
            public int quantity { get; set; }
            public string thumbnail { get; set; }
        }

        public class Links
        {
        }

        public class Pagination
        {
            public int count { get; set; }
            public int total { get; set; }
            public int perPage { get; set; }
            public int currentPage { get; set; }
            public int totalPages { get; set; }
           // public Links links { get; set; }
        }

        public class Root
        {
            public int status { get; set; }
            public bool success { get; set; }
            public List<Datum> data { get; set; }
            public Pagination pagination { get; set; }
        }

        public class Status
        {
            public int id { get; set; }
            public string name { get; set; }
            public string slug { get; set; }
            public Customized customized { get; set; }
        }

        public class Total
        {
            public int amount { get; set; }
            public string currency { get; set; }
        }


    }
}
