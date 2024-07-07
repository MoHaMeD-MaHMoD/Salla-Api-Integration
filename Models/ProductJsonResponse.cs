using static System.Net.Mime.MediaTypeNames;

namespace SallaIntegration.Models
{
    public class ProductJsonResponse
    {
        public class Ar
        {
            public string option_name { get; set; }
            public object description { get; set; }
            public string option_details_name { get; set; }
        }

        public class Category
        {
            public int id { get; set; }
            public string name { get; set; }
            public Urls urls { get; set; }
            public List<object> items { get; set; }
            public int parent_id { get; set; }
            public string status { get; set; }
            public int sort_order { get; set; }
          //  public UpdateAt update_at { get; set; }
        }

        public class CostPrice
        {
            public int amount { get; set; }
            public string currency { get; set; }
        }

        public class Datum
        {
            public int id { get; set; }
            public Promotion promotion { get; set; }
            public string sku { get; set; }
            public string thumbnail { get; set; }
            public object mpn { get; set; }
            public object gtin { get; set; }
            public string type { get; set; }
            public string name { get; set; }
            public string short_link_code { get; set; }
            public Urls urls { get; set; }
            public Price price { get; set; }
            public TaxedPrice taxed_price { get; set; }
            public PreTaxPrice pre_tax_price { get; set; }
            public Tax tax { get; set; }
            public string description { get; set; }
            public int? quantity { get; set; }
            public string status { get; set; }
            public bool is_available { get; set; }
            public int views { get; set; }
            public SalePrice sale_price { get; set; }
            public object sale_end { get; set; }
            public bool require_shipping { get; set; }
            public string cost_price { get; set; }
            public double weight { get; set; }
            public string weight_type { get; set; }
            public bool with_tax { get; set; }
            public string url { get; set; }
            public string main_image { get; set; }
            public List<Image> images { get; set; }
            public object sold_quantity { get; set; }
            public Rating rating { get; set; }
            public RegularPrice regular_price { get; set; }
            public int max_items_per_user { get; set; }
            public object maximum_quantity_per_order { get; set; }
            public bool show_in_app { get; set; }
            public object notify_quantity { get; set; }
            public bool hide_quantity { get; set; }
            public bool unlimited_quantity { get; set; }
            public bool managed_by_branches { get; set; }
            public ServicesBlocks services_blocks { get; set; }
            public object calories { get; set; }
            public bool customized_sku_quantity { get; set; }
            public List<string> channels { get; set; }
            public Metadata metadata { get; set; }
            public bool allow_attachments { get; set; }
            public bool is_pinned { get; set; }
            public string pinned_date { get; set; }
            public int sort { get; set; }
            public bool enable_upload_image { get; set; }
            public string updated_at { get; set; }
            public List<Option> options { get; set; }
            public List<Sku> skus { get; set; }
            public List<Category> categories { get; set; }
            public List<object> tags { get; set; }
            public object starting_price { get; set; }
            public object brand { get; set; }
        }

        public class Image
        {
            public int id { get; set; }
            public string url { get; set; }
            public bool main { get; set; }
            public string three_d_image_url { get; set; }
            public string alt { get; set; }
            public string video_url { get; set; }
            public string type { get; set; }
            public int sort { get; set; }
        }

        public class Links
        {
            public string previous { get; set; }
            public string next { get; set; }
        }

        public class Metadata
        {
            public object title { get; set; }
            public object description { get; set; }
            public object url { get; set; }
        }

        public class Option
        {
            public int id { get; set; }
            public string name { get; set; }
            public object description { get; set; }
            public string type { get; set; }
            public bool required { get; set; }
            public int associated_with_order_time { get; set; }
            public bool availability_range { get; set; }
            public bool not_same_day_order { get; set; }
            public object choose_date_time { get; set; }
            public object from_date_time { get; set; }
            public object to_date_time { get; set; }
            public object sort { get; set; }
            public bool advance { get; set; }
            public string display_type { get; set; }
            public string visibility { get; set; }
            public Translations translations { get; set; }
            public List<Value> values { get; set; }
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

        public class PreTaxPrice
        {
            public int amount { get; set; }
            public string currency { get; set; }
        }

        public class Price
        {
            public int amount { get; set; }
            public string currency { get; set; }
        }

        public class Promotion
        {
            public object title { get; set; }
            public object sub_title { get; set; }
        }

        public class Rating
        {
            public int total { get; set; }
            public int count { get; set; }
            public int rate { get; set; }
        }

        public class RegularPrice
        {
            public int amount { get; set; }
            public string currency { get; set; }
        }

        public class Root
        {
            public int status { get; set; }
            public bool success { get; set; }
            public List<Datum> data { get; set; }
            public Pagination pagination { get; set; }
        }

        public class SalePrice
        {
            public int amount { get; set; }
            public string currency { get; set; }
        }

        public class ServicesBlocks
        {
            public List<object> installments { get; set; }
        }

        public class Sku
        {
            public int id { get; set; }
            public Price price { get; set; }
            public RegularPrice regular_price { get; set; }
            public CostPrice cost_price { get; set; }
            public SalePrice sale_price { get; set; }
            public bool has_special_price { get; set; }
            public int? stock_quantity { get; set; }
            public bool unlimited_quantity { get; set; }
            public object notify_low { get; set; }
            public object barcode { get; set; }
            public object sku { get; set; }
            public object mpn { get; set; }
            public object gtin { get; set; }
            public List<int> related_options { get; set; }
            public List<int> related_option_values { get; set; }
            public object weight { get; set; }
            public string weight_type { get; set; }
            public string weight_label { get; set; }
            public bool is_user_subscribed_to_sku { get; set; }
            public bool is_default { get; set; }
        }

        public class Tax
        {
            public int amount { get; set; }
            public string currency { get; set; }
        }

        public class TaxedPrice
        {
            public int amount { get; set; }
            public string currency { get; set; }
        }

        public class Translations
        {
            public Ar ar { get; set; }
        }

      /*  public class UpdateAt
        {
            public string date { get; set; }
            public int timezone_type { get; set; }
            public string timezone { get; set; }
        }*/

        public class Urls
        {
            public string customer { get; set; }
            public string admin { get; set; }
        }

        public class Value
        {
            public int id { get; set; }
            public string name { get; set; }
            public Price price { get; set; }
            public string formatted_price { get; set; }
            public object display_value { get; set; }
            public bool advance { get; set; }
            public int option_id { get; set; }
            public object image_url { get; set; }
            public object hashed_display_value { get; set; }
            public Translations translations { get; set; }
            public bool is_default { get; set; }
            public bool is_out_of_stock { get; set; }
        }


    }
}