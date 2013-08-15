// TODO: deconstructor, base keyword (change default constructor on subclass), polymorphism vs method hiding (ParentClass vs. ChildClass), method overloading

// garage.cs
using System;

// Vehicle class implicitly inherits from the Object class
// in C# class is a reference type (so are Interface, delegates, arrays)
public class Vehicle
{
    /// <summary>
    /// Vehicle class defines a generic vehicle
    /// </summary>

    //// Start Class Members

    //// Start Properties

    // Static Properties - shared among all Vehicle objects (points to same memory location).  When a class member includes a static modifier, the member
    // is called as static member.  NOTE:  No matter how many Vehicle Object instances are created there will only ever be once copy of a static member.
    public static int totalVehicles;   // Static field, built-in, primitive types get placed on the heap

    // Instance Properties - created on a per-object basis (discrete memory location for each object)
    // When no static modifier is present the member is called a non static member (or instance member)
    private const string VEHICLETYPE = "N/A"; // Instance field
    public bool classic; // Instance field
    public string make = null; // Instance field
    public string model = null;  // Instance field
    // in C# int, float, double structs, enums are value types which are non-nullable by default without '?'
    public int? year = null;  // Instance field
    public int wheels; // Instance field

    //// Start Accessors
    // the accessor of a property contains the executable statements associated with getting (reading or computing) or setting (writing) the property. 
    // The accessor declarations can contain a get accessor, a set accessor, or both.

    // Define instance properties using newer style automatic properties { get; set; } syntax reduces boiler plate code
    protected string VIN { get; set; }
    protected int Mileage { get; set; }
    protected bool SalvageTitle { get; set; }
    protected string VehicleType { get; set; }

    //// End Properties

    // boiler plate property accessors (old style)
    // declare a Make property of type string:
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

    // declare a Model property of type string:
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

    // declare a Year property of type int:
    public int? Year // no implicit conversion between non-nullable types and nullable types
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

    //// End Accessors

    //// Start Constructors

    // static constructor - this is only run once when the first Vehicle object is created, it is shared by all Vehicle objects
    static Vehicle() // access modifiers are not allowed on static constructors
    {
        Console.WriteLine("Vehicle static constructor called");
        totalVehicles = 0;
    }

    // Default constructor. If a derived class does not invoke a base class constructor explicitly, the default constructor is called implicitly
    // the contrsuctor will be called automatically each time when we create and instance of the Vehicle class
    public Vehicle() 
    {
        Console.WriteLine("Vehicle default constructor called");
        VIN = "";
        Mileage = 0;
        SalvageTitle = false;
        totalVehicles++;   // Increment the static Population field
    }

    // Instance constructor that has three parameters
    // constructore can be identified by having the same name as the class, there is no return type and paramaters can optionally be passed in
    public Vehicle(string vehicleIdentificationNumber, int mileage, bool salvageTitle)
    {
        Console.WriteLine("Vehicle constructor called");
        // optionally use the "this" keyword to enhance readbility, it refers to an instance / object of the Vehicle class
        // class property = field
        this.VIN = vehicleIdentificationNumber;
        this.Mileage = mileage;
        this.SalvageTitle = salvageTitle;
    }

    //// End Constructors

    //// Start Methods

    // non-primitive types get placed on the stack

    // static method, parameter passed by reference (variable points to the same memory location)
    public static void Accelerate(ref int speed)
    {
        Console.WriteLine("Vehicle Accelerate() called");
        speed = speed * 2;
    }

    // instance method, default pass by value (variable is copied)
    public int Brake(int speed)
    {
        Console.WriteLine("Vehicle Brake() called");
        speed = speed / 2;
        return speed;
    }

    // accept a string list as parameters for shifting function
    public void Shift(params string[] selected)
    {
        Console.WriteLine("Vehicle Shift() called");
    }

    // output parameter example
    public static void GPSFix(out double X, out double Y)
    {
        Console.WriteLine("Vehicle GPSFix() called");
        X = 37.774929;
        Y = -122.419416;
    }

    public void PrintWheels()
    {
        Console.WriteLine("Number of wheels on vehicle: {0}", wheels);
    }

    // polymorphism example - polymorphism enables you to invoke derived class methods through base class reference variable at run-time
    public virtual void PrintVehicleType() // a method with the virtual keyword allows a subclass to override the inherited method
    {
        Console.WriteLine("Vehicle has no type");
    }

    // the override modifier is required to extend or modify the abstract or virtual implementation of an inherited method, property, indexer, or event.
    public override string ToString()
    {
        return "Type = " + VehicleType + ", Wheels = " + wheels + ", Make = " + Make + ", Model = " + Model + ", Year = " + Year + ", Classic = " + classic + ", VIN = " + VIN;
    }

    //// End Methods

    //// End Class Members
}

public class Automobile : Vehicle  // Automobile Class inherits from Vehicle Class
{
    /// <summary>
    /// Automobile class extends Vehicle class
    /// </summary>
    
    //// Start Class Members

    //// Start Properties / Accessors

    private const string VEHICLETYPE = "Automobile";
    protected string transmissionType { get; set; }

    //// End Properties / Accessors

    //// Start Constructors

    // Constructors. Because neither constructor calls a base-class  
    // constructor explicitly, the default constructor in the base class 
    // is called implicitly. The base class must contain a default constructor. 

    // Default constructor for the derived class. 
    public Automobile() 
    {
        Console.WriteLine("Automobile default constructor called");
    }

    // Instance constructor that has four parameters. 
    public Automobile(string vehicleIdentificationNumber, int mileage, bool salvageTitle, string transmission)
    {
        Console.WriteLine("Automobile constructor called");
        // The following properties are inherited from Vehicle. 
        this.VIN = vehicleIdentificationNumber;
        this.Mileage = mileage;
        this.SalvageTitle = salvageTitle;
        this.VehicleType = VEHICLETYPE;

        // Property transmissionType is a member of Automobile, but not of Vehicle. 
        this.transmissionType = transmission;
    }

    // polymorphism example
    public override void PrintVehicleType() // a method with the "override" keyword overrides the inherited method from the parent class
    {
        Console.WriteLine("Vehicle type is Automobile");
    }

    //// End Constructors

    //// End Automobile Class Members
}

public class SUV : Automobile  // SUV Class inherits from Automobile Class
{
    /// <summary>
    /// SUV class extends Automobile class, which extends Vehicle class
    /// </summary>

    //// Start Class Members

    //// Start Properties

    private static string VEHICLETYPE = "SUV";

    //// End Properties

    //// Start Constructors    

    // Default constructor for the derived class. 
    public SUV()
    {
        Console.WriteLine("SUV default constructor called");
    }

    // Instance constructor that has four parameters. 
    public SUV(string vehicleIdentificationNumber, int mileage, bool salvageTitle, string transmission)
    {
        Console.WriteLine("SUV constructor called");
        // The following properties are inherited from Vehicle. 
        this.VIN = vehicleIdentificationNumber;
        this.Mileage = mileage;
        this.SalvageTitle = salvageTitle;
        this.VehicleType = VEHICLETYPE;

        // Property transmissionType is a member of Automobile, but not of Vehicle. 
        this.transmissionType = transmission;
    }

    // polymorphism example
    public override void PrintVehicleType() // a method with the "override" keyword overrides the inherited method from the parent class
    {
        Console.WriteLine("Vehicle type is SUV");
    }
}

public sealed class Motorcycle : Vehicle  // Motorcycle Class inherits from Vehicle Class, sealed keywords means the class cannot be subclassed
{
    /// <summary>
    /// Motorcycle class extends Vehicle class
    /// </summary>

    //// Start Class Members

    //// Start Properties

    private static string VEHICLETYPE = "Motorcycle";

    //// End Properties

    //// Start Constructors

    // Constructors. Because neither constructor calls a base-class  
    // constructor explicitly, the default constructor in the base class 
    // is called implicitly. The base class must contain a default constructor. 

    // Default constructor for the derived class. 
    public Motorcycle()
    {
        Console.WriteLine("Motorcycle default constructor called");
    }

    // Instance constructor that has four parameters. 
    public Motorcycle(string vehicleIdentificationNumber, int mileage, bool salvageTitle)
    {
        Console.WriteLine("Motorcycle constructor called");
        // The following properties and the GetNexID method are inherited from Vehicle. 
        this.VIN = vehicleIdentificationNumber;
        this.Mileage = mileage;
        this.SalvageTitle = salvageTitle;
        this.VehicleType = VEHICLETYPE;
    }

    //// End Constructors

    //// Start Methods

    // method hiding example use the "new" keyword if hiding was intended, otherwise you will get a compiler warning
    public /* new */ void PrintWheels()
    {
        Console.WriteLine("Motorcycle has {0} wheels", wheels);
    }

    // polymorphism example
    public override void PrintVehicleType() // a method with the "override" keyword overrides the inherited method from the parent class
    {
        Console.WriteLine("Vehicle type is Motorcycle");
    }

    //// End Methods

    //// End Class Members
}

class Program
{
    public static void Main()
    {
        // Automobile objects

        // Create some new Automobile Class instances (objects) - they each occupy a seperate memory space
        Automobile automobile = new Automobile("36041", 48000, false, "Manual");
        //Automobile automobile2 = new Automobile("N/A", 32000, false, "Manual");
        
        int s = 60;
        Console.WriteLine("Speed is: {0}", s);
        Automobile.Accelerate(ref s); // static method invocation is called without creating an object instance of the class, Automobile child class inherits the Accelerate() method from Vehicle parent class
        automobile.Shift("2"); // 2 is passed as an argument to the method, Automobile child class inherits the Shift() method from Vehicle parent class
        Console.WriteLine("Accelerate - Speed is: {0}", s);

        // instance method invocation, Automobile child class inherits the Brake() method from Vehicle parent class
        s = automobile.Brake(0);
        Console.WriteLine("Brake - Speed is: {0}", s);
        double X;
        double Y;
        Automobile.GPSFix(out X, out Y); // Automobile child class inherits the GPSFix() method from Vehicle parent class
        Console.WriteLine("GPS coordinates are: " + X.ToString() + ", " + Y.ToString());

        // Set some values on the vehicle object:
        automobile.make = "Nissan";
        automobile.model = "300ZX";
        automobile.year = 1993;
        automobile.wheels = 4;
        Console.WriteLine("Vehicle details - {0}", automobile);

        // Create a new SUV Class instance (object)
        SUV suv = new SUV("04965", 92000, false, "Automatic");

        // Set some values on the vehicle object:
        suv.make = "BMW";
        suv.model = "X5 4.4i";
        suv.year = 2000;
        suv.wheels = 4;
        Console.WriteLine("Vehicle details - {0}", suv);

        // Motorcycle objects

        // Create some new Motorcycle objects:
        Motorcycle motorcycle = new Motorcycle("01581", 9000, false);

        // Set some values on the motorcycle object:
        motorcycle.make = "Yamaha";
        motorcycle.model = "R1";
        motorcycle.year = 2006;
        motorcycle.wheels = 2;
        Console.WriteLine("Vehicle details - {0}", motorcycle);

        // Show number of vehicles in garage referencing the Vehicle class static property shared by all Vehicle objects created
        // example of invoking a static member using class name
        Console.WriteLine("Vehicles in garage = " + Vehicle.totalVehicles);

        // NOTE: a parent class reference variable can point to a child class reference variable but NOT vice-versa
        // ParentClass PC = new ChildClass()
        // PC.HiddenMethod()
        Vehicle motorcycle2 = new Motorcycle("12345", 13000, false);  // we can assign an object of Motorcycle type to reference of type Vehicle

        // method hiding example & object casting
        motorcycle.PrintWheels(); // static method invocation, Automobile child class inherits the Accelerate() method from Vehicle parent class
        ((Vehicle)motorcycle).PrintWheels(); // object casting - cast child type to parent type - a child Motorcycle object can fulfill all the responsibilities of a parent Vehicle object

        // Polymorphism example
        Vehicle[] vehicles = new Vehicle[4];

        vehicles[0] = new Vehicle();
        vehicles[1] = new Automobile();
        vehicles[2] = new SUV();
        vehicles[3] = new Motorcycle();

        foreach (Vehicle v in vehicles)
        {
            v.PrintVehicleType();
        }

        // Prompt user to exit:
        Console.WriteLine("Press any key to conitnue...");
        string test = Console.ReadLine();
    }

}