namespace Yoda.Services.Entities;

public class DistrictEntity
{
    public int Id { get; set; }
    public int Provinceld { get; set; }
    public string Name { get; set; }
    public bool EnabledFlag { get; set; }

    public ProvinceEntity Province { get; set; }
}
