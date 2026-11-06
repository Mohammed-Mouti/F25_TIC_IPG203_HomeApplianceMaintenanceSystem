public delegate void StatusChangedHandler(string message);

public abstract class Appliance : IMaintainable
{
    private string serialNumber;
    private string brand;
    private string status;

    public event StatusChangedHandler? OnStatusChanged;

    public string SerialNumber
    {
        get { return serialNumber; }
        set { serialNumber = value; }
    }

    public string Brand
    {
        get { return brand; }
        set { brand = value; }
    }

    public string Status
    {
        get { return status; }
        set
        {
            status = value;
            if (status == "Completed" || status == "Delayed")
            {
                OnStatusChanged?.Invoke($"[Notification] {brand} ({serialNumber}) maintenance status: {status}");
            }
        }
    }

    protected Appliance(string serialNumber, string brand)
    {
        this.serialNumber = serialNumber;
        this.brand = brand;
        this.status = "Pending";
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
