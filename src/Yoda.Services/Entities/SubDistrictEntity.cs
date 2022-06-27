namespace Yoda.Services.Entities;

public class SubDistrictEntity
{
    public int Id { get; set; }
    public int DistrictId { get; set; }
    public string Name { get; set; }
    public bool EnabledFlag { get; set; }

    public DistrictEntity District { get; set; }
}
