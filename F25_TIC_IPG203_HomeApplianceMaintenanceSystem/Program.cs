// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

List<Appliance> appliances = new()
{
    new Refrigerator("RF-1001", "Samsung", 420, 5, 2),
    new WashingMachine("WM-2005", "LG", 9.5m, 3, 1, true),
    new AirConditioner("AC-3007", "Daikin", 2.8m, 4, 3)
};

Console.WriteLine("Home Appliance Maintenance System - Inheritance and Polymorphism Demo");
Console.WriteLine(new string('-', 72));

decimal totalRepairCost = 0m;

foreach (Appliance appliance in appliances)
{
    appliance.StartMaintenance();
    double repairCost = appliance.CalculateRepairCost();
    totalRepairCost += (decimal)repairCost;

    Console.WriteLine(appliance.GetStatusDetails());
    Console.WriteLine($"Repair cost: {repairCost} SYP");
    Console.WriteLine();
}

Console.WriteLine(new string('-', 72));
Console.WriteLine($"Total repair cost: {totalRepairCost} SYP");
