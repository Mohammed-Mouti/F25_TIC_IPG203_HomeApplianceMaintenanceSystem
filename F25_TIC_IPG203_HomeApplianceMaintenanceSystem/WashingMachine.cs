public class WashingMachine : Appliance
{
    private decimal drumCapacityKg;
    private int ageYears;
    private int motorIssues;
    private bool isFrontLoader;

    public decimal DrumCapacityKg
    {
        get => drumCapacityKg;
        private set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Drum capacity must be greater than zero.");
            drumCapacityKg = value;
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

    public int MotorIssues
    {
        get => motorIssues;
        private set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Motor issues cannot be negative.");
            motorIssues = value;
        }
    }

    public bool IsFrontLoader
    {
        get => isFrontLoader;
        private set => isFrontLoader = value;
    }

    public WashingMachine(string serialNumber, string brand, decimal drumCapacityKg, int ageYears, int motorIssues, bool isFrontLoader)
        : base(serialNumber, brand)
    {
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
