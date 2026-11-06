public class AirConditioner : Appliance
{
    private decimal coolingCapacityKw;
    private int ageYears;
    private int filterIssues;

    public decimal CoolingCapacityKw
    {
        get => coolingCapacityKw;
        private set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Cooling capacity must be greater than zero.");
            coolingCapacityKw = value;
        }
    }

    public int AgeYears
    {
        get => ageYears;
        private set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Age cannot be negative.");
            ageYears = value;
        }
    }

    public int FilterIssues
    {
        get => filterIssues;
        private set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Filter issues cannot be negative.");
            filterIssues = value;
        }
    }

    public AirConditioner(string serialNumber, string brand, decimal coolingCapacityKw, int ageYears, int filterIssues)
        : base(serialNumber, brand)
    {
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
