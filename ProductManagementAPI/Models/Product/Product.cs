namespace ProductManagementAPI.Models
{
    public class Product : EntityBase
    {
        public string Title { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
