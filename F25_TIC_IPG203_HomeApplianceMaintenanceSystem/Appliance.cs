public abstract class Appliance : IMaintainable
{
    private string serialNumber;
    private string brand;
    private string status;

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
        set { status = value; }
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

    public abstract string GetStatusDetails();
}