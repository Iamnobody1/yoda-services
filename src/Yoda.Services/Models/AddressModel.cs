namespace Yoda.Services.Models
{
    public class AddressModel
    {
        public int CustomerId { get; set; }
        public int SubDistrictId { get; set; }
        public string Address { get; set; }
        public bool EnabledFlag { get; set; }
        public int PostalCode { get; set; }
    }
}
