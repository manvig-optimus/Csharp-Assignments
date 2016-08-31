using System;
using System.Text;
using System.Threading;

internal class Student
{
    private int _id;
    private string _name;
    private string _gender;
    private int _age;
    private int _enrolmentNumber;

    public int ID
    {
        get
        {
            return this._id;
        }
        set
        {
            this._id = value;
        }
    }

    public string Name
    {
        get
        {
            return this._name;
        }
        set
        {
            this._name = value;
        }
    }

    public string Gender
    {
        get
        {
            return this._gender;
        }
        set
        {
            this._gender = value;
        }
    }

    public int Age
    {
        get
        {
            return this._age;
        }
        set
        {
            this._age = value;
        }
    }

    public int EnrolmentNumber
    {
        get
        {
            return this._enrolmentNumber;
        }
        set
        {
            this._enrolmentNumber = value;
        }
    }

    public Student(int id, string name, string gender, int age)
    {
        this.ID = id;
        this.Name = name;
        this.Gender = gender;
        this.Age = age;
    }


    public void GetEnrolNum()
    {
        Random r = new Random();
        this.EnrolmentNumber = r.Next(1, 1000);
    }

    public void PrintDetails()
    {
        Console.WriteLine("Welcome! You have been successfully enrolled for this session.");

        var studentDetails = new StringBuilder("The details of enrolled Student are: ");
        studentDetails.Append("Name: ")
        .Append(this.Name)
        .Append(", Age: ")
        .Append(this.Age)
        .Append(", Gender: ")
        .Append(this.Gender)
        .Append(", ID: ")
        .Append(this.ID)
        .Append(", Enrollment Number: ")
        .Append(this.EnrolmentNumber);

        Console.WriteLine(studentDetails.ToString());
    }

    public void PrintDetails(int choice)
    {
        switch (choice)
        {
            case 0:
                Console.WriteLine("The name of student is : {0}", this.Name);
                break;
            case 1:
                Console.WriteLine("The age of student is : {0}", this.Age);
                break;
            case 2:
                Console.WriteLine("The gender of student is : {0}", this.Gender);
                break;
            case 3:
                Console.WriteLine("The id of student is : {0}", this.ID);
                break;
            case 4:
                Console.WriteLine("The enrollment number of student is : {0}", this.EnrolmentNumber);
                break;
        }
    }
}

public enum StudentAttribute
{
    Name,
    Age,
    Gender,
    ID,
    EnrolNumber
}

class Program
{
    public static void Main()
    {
        int _userChoice = (int)StudentAttribute.Age;

        var s1 = new Student[4];
        s1[0] = new Student(101, "Mark", "Male", 25);
        s1[1] = new Student(102, "Fedy", "Female", 40);
        s1[2] = new Student(103, "Simmy", "Female", 30);
        s1[3] = new Student(104, "John", "Male", 42);

        foreach (Student student in s1)
        {
            student.GetEnrolNum();
            Thread.Sleep(10);
            student.PrintDetails();
            student.PrintDetails(_userChoice);
            Console.WriteLine("");
        }  

        Console.ReadKey();
    }
}
