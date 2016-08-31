using System;

internal class TestStrings
{
    private string _firstString;
    private string _secondString;
    private string _thirdString;
    private int _comparePosition;
    private string[] _joinStrings;
    private string _testFormat;

    //Function to implement String operations present in String class.
    private void StringOperations()
    {
        _joinStrings = new string[2];       

        Console.WriteLine("Provide first string for comparison.");
        _firstString = Console.ReadLine();

        Console.WriteLine("Provide second string for comparison.");
        _secondString = Console.ReadLine();
        
        //Concatenate two strings and print the result.
        Console.WriteLine("//String Concatenation: {0}", String.Concat(_firstString, " ", _secondString));

        //Return a copy of the string provided in Copy method
        Console.WriteLine("//String Copy: {0}", String.Copy(String.Concat(_firstString, " ", _secondString)));

        //Checks if two given strings are equal or not. Returns boolean value.
        Console.WriteLine("//String Equals: {0}", String.Equals(_firstString, _secondString));

        //Joins all the string given in the passed array and separate them using a separator like ",".
        _joinStrings[0] = _firstString;
        _joinStrings[1] = _secondString;
        Console.WriteLine("//String Join: {0}", String.Join(",", _joinStrings));

        //Checks if string is empty or null.
        if (_firstString == String.Empty)
        { 
            Console.WriteLine("First String is Empty.");
        }

        //Checks if string is empty or null.
        if (String.IsNullOrEmpty(_secondString))
        {
            Console.WriteLine("Second String is Null or Empty.");
        }

        //Replaces the provided string format with the two strings and returns a string.
        _testFormat = String.Format("Hi..This is a String Format Method with first string as {0} and second string as {1}", _firstString, _secondString);
        Console.WriteLine(_testFormat);

        //Replaces the provided string format with the string array and returns a string.
        _testFormat = String.Format("Hi..The first String is {0} {1}.", _joinStrings[0],": Format test");
        Console.WriteLine(_testFormat);

        //Returns a clone of the provided string.
        _thirdString = String.Concat(_firstString, " ", _secondString).Clone().ToString();
        Console.WriteLine("//String Clone: {0}", _thirdString);

        //Returns true if first string contains the second string else false. 
        Console.WriteLine("//First String Contains Second String: {0}", _firstString.Contains(_secondString));

        //Returns position of the passed string into the first string. Index position starts from 0.
        Console.WriteLine("//String Index of 'e' character in first string: {0}", _firstString.IndexOf("e"));

        //Compare thw two strings after sorting them.
        _comparePosition = String.Compare(_firstString, _secondString, true);

        if (_comparePosition > 0)
        {
            Console.WriteLine("//Compare: First String follows Second String.");
        }
        else if (_comparePosition < 0)
        {
            Console.WriteLine("//Compare: First String precedes Second String.");
        }
        else
        {
            Console.WriteLine("//Compare: Both strings are same.");
        }          
    }
    
    private static void Main(string[] args)
    {
        TestStrings test = new TestStrings();
        test.StringOperations();

        Console.ReadKey();
    }
}

