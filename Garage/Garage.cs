// garage.cs
using System;

// Vehicle class implicitly inherits from the Object class 
public class Vehicle
{
    // define local variables - these built-in, primitive types get placed on the heap
    private const string VEHICLETYPE = "N/A"; // Instance field
    public bool classic; // Instance field
    public string make = "N/A"; // Instance field
    public string model = "N/A";  // Instance field
    public int year = 1885;  // Instance field
    public static int totalVehicles;   // Static field

    // Properties
    protected string VIN { get; set; }
    protected int Mileage { get; set; }
    protected bool SalvageTitle { get; set; }
    protected string VehicleType { get; set; }

    // Default constructor. If a derived class does not invoke a base- 
    // class constructor explicitly, the default constructor is called implicitly  
    public Vehicle()
    {
        VIN = "";
        Mileage = 0;
        SalvageTitle = false;
        totalVehicles++;   // Increment the static Population field
    }

    // Instance constructor that has three parameters
    public Vehicle(string vehicleIdentificationNumber, int mileage, bool salvageTitle)
    {
        this.VIN = vehicleIdentificationNumber;
        this.Mileage = mileage;
        this.SalvageTitle = salvageTitle;
    }

    // Declare a Make property of type string:
    public string Make
    {
        get
        {
            return make;
        }
        set
        {
            make = value;
        }
    }

    // Declare a Model property of type string:
    public string Model
    {
        get
        {
            return model;
        }
        set
        {
            model = value;
        }
    }

    // Declare a Year property of type int:
    public int Year
    {
        get
        {
            return year;
        }
        set
        {
            year = value;
        }
    }

    public override string ToString()
    {
        return "Type = " + VehicleType + ", Make = " + Make + ", Model = " + Model + ", Year = " + Year + ", Classic = " + classic + ", VIN = " + VIN;
    }
}

public class Automobile : Vehicle
{
    private const string VEHICLETYPE = "Automobile";
    protected string transmissionType { get; set; }

    // Constructors. Because neither constructor calls a base-class  
    // constructor explicitly, the default constructor in the base class 
    // is called implicitly. The base class must contain a default constructor. 

    // Default constructor for the derived class. 
    public Automobile() { }

    // Instance constructor that has four parameters. 
    public Automobile(string vehicleIdentificationNumber, int mileage, bool salvageTitle, string transmission)
    {
        // The following properties and the GetNexID method are inherited from Vehicle. 
        this.VIN = vehicleIdentificationNumber;
        this.Mileage = mileage;
        this.SalvageTitle = salvageTitle;
        this.VehicleType = VEHICLETYPE;

        // Property transmissionType is a member of Automobile, but not of Vehicle. 
        this.transmissionType = transmission;
    }
}

public class Motorcycle : Vehicle
{
    private const string VEHICLETYPE = "Motorcycle";

    // Constructors. Because neither constructor calls a base-class  
    // constructor explicitly, the default constructor in the base class 
    // is called implicitly. The base class must contain a default constructor. 

    // Default constructor for the derived class. 
    public Motorcycle() { }

    // Instance constructor that has four parameters. 
    public Motorcycle(string vehicleIdentificationNumber, int mileage, bool salvageTitle)
    {
        // The following properties and the GetNexID method are inherited from Vehicle. 
        this.VIN = vehicleIdentificationNumber;
        this.Mileage = mileage;
        this.SalvageTitle = salvageTitle;
        this.VehicleType = VEHICLETYPE;
    }
}

class Program
{
    public static void Main()
    {
        Console.WriteLine("Simple Properties");

/*
        // Vehicle objects

        // Create some new Vehicle objects:
        Vehicle vehicle = new Vehicle();

        // Print out the mode and the year associated with the vehicle:
        Console.WriteLine("Vehicle details - {0}", vehicle);

        // Set some values on the vehicle object:
        vehicle.model = "test vehicle";
        vehicle.year = 2015;
        Console.WriteLine("Vehicle details - {0}", vehicle);
*/

        // Automobile objects

        // Create some new Automobile objects:
        Automobile automobile = new Automobile("36041", 48000, false, "Manual");
        Automobile automobile2 = new Automobile("04965", 92000, false, "Automatic");

        // Print out the mode and the year associated with the automobile:
        //Console.WriteLine("Vehicle details - {0}", automobile);

        // Set some values on the vehicle object:
        automobile.make = "Nissan";
        automobile.model = "300ZX";
        automobile.year = 1993;
        Console.WriteLine("Vehicle details - {0}", automobile);

        // Set some values on the vehicle object:
        automobile2.make = "BMW";
        automobile2.model = "X5 4.4i";
        automobile2.year = 2000;
        Console.WriteLine("Vehicle details - {0}", automobile2);

        // Motorcycle objects

        // Create some new Motorcycle objects:
        Motorcycle motorcycle = new Motorcycle("01581", 9000, false);

        // Set some values on the motorcycle object:
        motorcycle.make = "Yamaha";
        motorcycle.model = "R1";
        motorcycle.year = 2006;
        Console.WriteLine("Vehicle details - {0}", motorcycle);

        // Show number of vehicles in garage:
        Console.WriteLine("Vehicles in garage = " + Vehicle.totalVehicles);

        // Prompt user to exit:
        Console.WriteLine("Press any key to conitnue...");
        string test = Console.ReadLine();
    }

}