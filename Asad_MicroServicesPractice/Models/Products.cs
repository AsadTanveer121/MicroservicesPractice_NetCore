namespace PRODUCT_MICROSERVICES.Models
{
    public class Products
    {
        public int Id { get; set; } 
        public string? ProductName { get; set; }     
        public string? ProductDescription { get; set; }
        public string? ProductPrice { get; set; }
        public string? CategoryId { get; set;}
    }
}
