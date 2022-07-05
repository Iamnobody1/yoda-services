namespace Yoda.Services.Customer.Models;

public class DisWithPosAndSubModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<SubDistrictModel> SubDistricts { get; set; }
    public IEnumerable<PostalCodeModel> PostalCodes { get; set; }
}
