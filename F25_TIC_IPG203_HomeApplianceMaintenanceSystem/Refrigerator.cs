public class Refrigerator : Appliance
{
    private int capacityLiters;
    private int ageYears;
    private int compressorIssues;

    public int CapacityLiters
    {
        get => capacityLiters;
        private set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Capacity must be greater than zero.");
            capacityLiters = value;
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

    public int CompressorIssues
    {
        get => compressorIssues;
        private set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Compressor issues cannot be negative.");
            compressorIssues = value;
        }
    }

    public Refrigerator(string serialNumber, string brand, int capacityLiters, int ageYears, int compressorIssues)
        : base(serialNumber, brand)
    {
        CapacityLiters = capacityLiters;
        AgeYears = ageYears;
        CompressorIssues = compressorIssues;
    }

    public override double CalculateRepairCost()
    {
        decimal baseRepairCost = 180m;
        decimal capacityCost = CapacityLiters * 0.35m;
        decimal ageCost = AgeYears * 18m;
        decimal compressorCost = CompressorIssues * 120m;

        decimal total = baseRepairCost + capacityCost + ageCost + compressorCost;
        return (double)total;
    }

    public override string GetStatusDetails()
    {
        return $"Refrigerator {Brand} ({SerialNumber}) - Capacity: {CapacityLiters}L, Age: {AgeYears} years, Status: {Status}";
    }
}
