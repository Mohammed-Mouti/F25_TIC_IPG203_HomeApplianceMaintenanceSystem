public class AirConditioner : Appliance
{
    public decimal CoolingCapacityKw { get; }
    public int AgeYears { get; }
    public int FilterIssues { get; }

    public AirConditioner(string serialNumber, string brand, decimal coolingCapacityKw, int ageYears, int filterIssues)
        : base(serialNumber, brand)
    {
        if (coolingCapacityKw <= 0)
            throw new ArgumentOutOfRangeException(nameof(coolingCapacityKw), "Cooling capacity must be greater than zero.");

        if (ageYears < 0)
            throw new ArgumentOutOfRangeException(nameof(ageYears), "Age cannot be negative.");

        if (filterIssues < 0)
            throw new ArgumentOutOfRangeException(nameof(filterIssues), "Filter issues cannot be negative.");

        CoolingCapacityKw = coolingCapacityKw;
        AgeYears = ageYears;
        FilterIssues = filterIssues;
    }

    public override double CalculateRepairCost()
    {
        decimal baseRepairCost = 170m;
        decimal capacityCost = CoolingCapacityKw * 75m;
        decimal ageCost = AgeYears * 20m;
        decimal filterCost = FilterIssues * 60m;

        decimal total = baseRepairCost + capacityCost + ageCost + filterCost;
        return (double)total;
    }

    public override string GetStatusDetails()
    {
        return $"Air conditioner {Brand} ({SerialNumber}) - Capacity: {CoolingCapacityKw}kW, Age: {AgeYears} years, Status: {Status}";
    }
}
