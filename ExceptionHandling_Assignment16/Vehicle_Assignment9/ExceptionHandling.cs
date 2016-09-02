using System;
using System.Runtime.Serialization;
using System.Text;
using System.Configuration;
using System.IO;

[Serializable]
class IsCarDeadException : Exception
{
    private float _carSpeed;
    private string _explodeTime;

    public float CarSpeed
    {
        get { return _carSpeed; }
        set { _carSpeed = value; }
    }

    public string ExplodeTime
    {
        get { return _explodeTime; }
        set { _explodeTime = value; }
    }

    public void PrintDetails()
    {
        Console.WriteLine("The car exploded at speed: {0} and time: {1}", CarSpeed, ExplodeTime);
    }

    public void LogData()
    {
        string FilePath = ConfigurationManager.AppSettings["FilePath"];
        if (!File.Exists(FilePath))
        {
            string DirectoryPath = FilePath.Substring(0, FilePath.LastIndexOf(@"\"));
            DirectoryInfo directory = new DirectoryInfo(DirectoryPath);
            directory.Create();
            File.Create(FilePath).Dispose();
        }
        if (File.Exists(FilePath))
        {
            using (FileStream fileStream = new FileStream(FilePath, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    var message = new StringBuilder(this.GetType().Name)
                    .Append(": ")
                    .Append(this.Message);

                    streamWriter.WriteLine(message.ToString());
                    streamWriter.Flush();
                }
            }
        }
    }

    public IsCarDeadException() : base() { }
    public IsCarDeadException(string message) : base(message) { }
    public IsCarDeadException(string message, Exception innerException) : base(message, innerException) { }
    public IsCarDeadException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}

class Vehicle
{
    private string _make;
    private int _yearOfManufacture;
    private string _model;
    private float _speed;

    public string Make
    {
        get { return _make; }
        set { _make = value; }
    }

    public int YearOfManufacture
    {
        get { return _yearOfManufacture; }
        set { _yearOfManufacture = value; }
    }

    public string Model
    {
        get { return _model; }
        set { _model = value; }
    }

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public Vehicle(string make, int yearOfManufacture, string model, float speed)
    {
        this.Make = make;
        this.YearOfManufacture = yearOfManufacture;
        this.Model = model;
        this.Speed = speed;
    }

    /// <summary>
    /// Function used to accelerate the vehicle
    /// </summary>
    /// <param name="accelerationSpeed"> contains acceleration speed</param>
    public void Accelerate(int accelerationSpeed, object vehicle)
    {
        try
        {
            if (vehicle.GetType() == typeof(Car) && this.Speed + accelerationSpeed > 100)
            {
                throw new IsCarDeadException("Car has Overheated");
            }
            else
            {
                this.Speed += accelerationSpeed;
                Console.WriteLine("Accelerated Speed is: {0}", this.Speed);
            }
        }
        catch (IsCarDeadException ex)
        {
            Console.WriteLine(ex.Message);
            ex.ExplodeTime = DateTime.Now.ToString("h:mm:ss tt");
            ex.CarSpeed = this.Speed + accelerationSpeed;
            ex.PrintDetails();
            ex.LogData();
        }
    }

    /// <summary>
    /// Function used to deaccelerate the vehicle. If speed is already 0 or reaches negative, 
    /// then deacceleration speed is
    /// returned as 0.
    /// </summary>
    /// <param name="deaccelerationSpeed"> contains deacceleration speed</param>
    public void Deaccelerate(int deaccelerationSpeed)
    {
        try
        {
            if (this.Speed - deaccelerationSpeed < 0)
            {
                throw new IsCarDeadException("Speed cannot be less than 0.");
            }
            else
            {
                this.Speed -= deaccelerationSpeed;
                Console.WriteLine("Deaccelerated Speed is: {0}", this.Speed);
            }
        }
        catch (IsCarDeadException ex)
        {
            Console.WriteLine(ex.Message);
            ex.LogData();
        }
    }

    /// <summary>
    /// Set speed of vehicle as 0.
    /// </summary>
    public void Stop()
    {
        this.Speed = 0;
    }

    /// <summary>
    /// Checks if the vehicle is moving or not.
    /// </summary>
    /// <returns></returns>
    public Boolean IsMoving()
    {
        if (this.Speed == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}

class Bicycle : Vehicle
{
    private string _color;

    public string Color
    {
        get { return _color; }
        set { _color = value; }
    }

    public Bicycle(string make, int yearOfManufacture, string model, float speed)
        : base(make, yearOfManufacture, model, speed)
    { }

    public void GetDetails()
    {
        var bicycleDetails = new StringBuilder("The Details of bicycle are: Make: ")
            .Append(Make)
            .Append(", Model: ")
            .Append(Model)
            .Append(", YearOfManufacture: ")
            .Append(YearOfManufacture)
            .Append(", Speed: ")
            .Append(Speed)
            .Append(", Color: ")
            .Append(Color);

        Console.WriteLine(bicycleDetails.ToString());
    }
}

class Bike : Vehicle
{
    private string _bikeColor;

    public string BikeColor
    {
        get { return _bikeColor; }
        set { _bikeColor = value; }
    }

    public Bike(string make, int yearOfManufacture, string model, float speed)
        : base(make, yearOfManufacture, model, speed)
    { }

    public void GetDetails()
    {
        var bikeDetails = new StringBuilder("The Details of bike are: Make: ")
            .Append(Make)
            .Append(", Model: ")
            .Append(Model)
            .Append(", YearOfManufacture: ")
            .Append(YearOfManufacture)
            .Append(", Speed: ")
            .Append(Speed)
            .Append(", Color: ")
            .Append(BikeColor);

        Console.WriteLine(bikeDetails.ToString());
    }
}

class Car : Vehicle
{
    private string _carColor;

    public string CarColor
    {
        get { return _carColor; }
        set { _carColor = value; }
    }

    public Car(string make, int yearOfManufacture, string model, float speed)
        : base(make, yearOfManufacture, model, speed)
    { }

    public void GetDetails()
    {
        var carDetails = new StringBuilder("The Details of car are: Make: ")
            .Append(Make)
            .Append(", Model: ")
            .Append(Model)
            .Append(", YearOfManufacture: ")
            .Append(YearOfManufacture)
            .Append(", Speed: ")
            .Append(Speed)
            .Append(", Color: ")
            .Append(CarColor);

        Console.WriteLine(carDetails.ToString());
    }
}

class Truck : Vehicle
{
    private string _truckColor;

    public string TruckColor
    {
        get { return _truckColor; }
        set { _truckColor = value; }
    }

    public Truck(string make, int yearOfManufacture, string model, float speed)
        : base(make, yearOfManufacture, model, speed)
    { }

    public void GetDetails()
    {
        var truckDetails = new StringBuilder("The Details of car are: Make: ")
            .Append(Make)
            .Append(", Model: ")
            .Append(Model)
            .Append(", YearOfManufacture: ")
            .Append(YearOfManufacture)
            .Append(", Speed: ")
            .Append(Speed)
            .Append(", Color: ")
            .Append(TruckColor);

        Console.WriteLine(truckDetails.ToString());
    }
}

public class program
{
    private static void Main()
    {
        Bicycle bicycle = new Bicycle("Chicago Bicycle", 2011, "K-10", 100);
        bicycle.Color = "Red";
        bicycle.GetDetails();
        bicycle.Accelerate(50, bicycle);
        bicycle.Deaccelerate(10);
        if (bicycle.IsMoving())
        {
            Console.WriteLine("Bicycle is moving");
        }
        else
        {
            Console.WriteLine("Bicycle is not moving");
        }

        Console.WriteLine("");

        Bike bike = new Bike("Hero Bike", 2015, "H712", 200);
        bike.BikeColor = "Blue";
        bike.GetDetails();
        bike.Accelerate(30, bike);
        bike.Deaccelerate(40);
        bike.Stop();
        if (bike.IsMoving())
        {
            Console.WriteLine("Bike is moving");
        }
        else
        {
            Console.WriteLine("Bike is not moving");
        }

        Console.WriteLine("");

        Car car = new Car("Honda Amaze", 2016, "VXi", 250);
        car.CarColor = "White";
        car.GetDetails();
        car.Accelerate(10, car);
        car.Deaccelerate(10);
        if (car.IsMoving())
        {
            Console.WriteLine("Car is moving");
        }
        else
        {
            Console.WriteLine("Car is not moving");
        }

        Console.WriteLine("");

        Truck truck = new Truck("Aven", 2010, "Z-20", 200);
        truck.TruckColor = "Orange";
        truck.GetDetails();
        truck.Accelerate(10, truck);
        truck.Deaccelerate(250);
        if (truck.IsMoving())
        {
            Console.WriteLine("Truck is moving");
        }
        else
        {
            Console.WriteLine("Truck is not moving");
        }

        Console.ReadKey();

    }
}

