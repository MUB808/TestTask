namespace ProductManagementAPI.Models
{
    public class ProductAudit: EntityBase
    {
        public int ProductId { get; set; }
        public string Changes { get; set; }
    }
}
