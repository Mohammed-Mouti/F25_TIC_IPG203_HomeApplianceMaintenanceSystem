public class WashingMachine : Appliance
{
    public decimal DrumCapacityKg { get; }
    public int AgeYears { get; }
    public int MotorIssues { get; }
    public bool IsFrontLoader { get; }

    public WashingMachine(string serialNumber, string brand, decimal drumCapacityKg, int ageYears, int motorIssues, bool isFrontLoader)
        : base(serialNumber, brand)
    {
        if (drumCapacityKg <= 0)
            throw new ArgumentOutOfRangeException(nameof(drumCapacityKg), "Drum capacity must be greater than zero.");

        if (ageYears < 0)
            throw new ArgumentOutOfRangeException(nameof(ageYears), "Age cannot be negative.");

        if (motorIssues < 0)
            throw new ArgumentOutOfRangeException(nameof(motorIssues), "Motor issues cannot be negative.");

        DrumCapacityKg = drumCapacityKg;
        AgeYears = ageYears;
        MotorIssues = motorIssues;
        IsFrontLoader = isFrontLoader;
    }

    public override double CalculateRepairCost()
    {
        decimal baseRepairCost = 220m;
        decimal capacityCost = DrumCapacityKg * 12m;
        decimal ageCost = AgeYears * 22m;
        decimal motorCost = MotorIssues * 150m;
        decimal doorTypeCost = IsFrontLoader ? 35m : 0m;

        decimal total = baseRepairCost + capacityCost + ageCost + motorCost + doorTypeCost;
        return (double)total;
    }

    public override string GetStatusDetails()
    {
        string type = IsFrontLoader ? "Front-load" : "Top-load";
        return $"Washing machine {Brand} ({SerialNumber}) - Type: {type}, Capacity: {DrumCapacityKg}kg, Age: {AgeYears} years, Status: {Status}";
    }
}
