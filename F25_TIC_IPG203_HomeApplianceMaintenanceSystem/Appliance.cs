public delegate void StatusChangedHandler(string message);

public abstract class Appliance : IMaintainable
{
    private string serialNumber = string.Empty;
    private string brand = string.Empty;
    private string status = string.Empty;

    public event StatusChangedHandler? OnStatusChanged;

    public string SerialNumber
    {
        get => serialNumber;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Serial number cannot be null or empty.", nameof(value));
            serialNumber = value;
        }
    }

    public string Brand
    {
        get => brand;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Brand cannot be null or empty.", nameof(value));
            brand = value;
        }
    }

    public string Status
    {
        get => status;
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Status cannot be null or empty.", nameof(value));

            status = value;
            if (status == "Completed" || status == "Delayed")
            {
                OnStatusChanged?.Invoke($"[Notification] {Brand} ({SerialNumber}) maintenance status: {status}");
            }
        }
    }

    protected Appliance(string serialNumber, string brand)
    {
        SerialNumber = serialNumber;
        Brand = brand;
        Status = "Pending";
    }

    public abstract double CalculateRepairCost();

    public virtual void StartMaintenance()
    {
        Status = "Under Maintenance";
    }

    public virtual void CompleteMaintenance()
    {
        Status = "Completed";
    }

    public abstract string GetStatusDetails();
}
