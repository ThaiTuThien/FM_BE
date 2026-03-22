using FM.Domain.Entities;
using System.Text.Json.Serialization;

namespace FM.API.DTO
{
    public class ProductDTO
    {
        public Guid Productid { get; set; }
        public string? Productname { get; set; }
        public string? CategoryName { get; set; }
        public string? SupplierName { get; set; }
    }

    public class AddProductDTO
    {
        public string? Productname { get; set; }
        public string? Categoryid { get; set; }
        public string? Supplierid { get; set; }
        public string? Prodes { get; set; }
    }
    public class UpdateProductDTO
    {
        public string Productid { get; set; }
        public string? Productname { get; set; }
        public string? Categoryid { get; set; }
        public string? Supplierid { get; set; }
        public string? Prodes { get; set; }
    }
}
