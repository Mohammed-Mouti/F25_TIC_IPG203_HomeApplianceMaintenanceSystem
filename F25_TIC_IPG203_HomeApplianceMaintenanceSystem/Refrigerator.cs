public class Refrigerator : Appliance
{
    public int CapacityLiters { get; }
    public int AgeYears { get; }
    public int CompressorIssues { get; }

    public Refrigerator(string serialNumber, string brand, int capacityLiters, int ageYears, int compressorIssues)
        : base(serialNumber, brand)
    {
        if (capacityLiters <= 0)
            throw new ArgumentOutOfRangeException(nameof(capacityLiters), "Capacity must be greater than zero.");

        if (ageYears < 0)
            throw new ArgumentOutOfRangeException(nameof(ageYears), "Age cannot be negative.");

        if (compressorIssues < 0)
            throw new ArgumentOutOfRangeException(nameof(compressorIssues), "Compressor issues cannot be negative.");

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
