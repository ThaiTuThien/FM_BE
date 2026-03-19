namespace FM.API.DTO
{
    public class ProductDTO
    {
        public Guid Productid { get; set; }
        public string? Productname { get; set; }
        public string? CategoryName { get; set; }
        public string? SupplierName { get; set; }
    }
}
