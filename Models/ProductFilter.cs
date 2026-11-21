namespace MVC_01.Models
{
    public class ProductFilter
    {
        public string? term { get; set; }
        public decimal? minprice { get; set; }
        public int page { get; set; }
    }
}
