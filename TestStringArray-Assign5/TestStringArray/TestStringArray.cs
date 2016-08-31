using System;

internal class TestStringArray
{
    private string[] _testStringArray;
    private string[] _testPrintArray;

    private string[] GetStringArray()
    {
        _testStringArray = new string[5];
        _testStringArray[0] = "Mike";
        _testStringArray[1] = "Rob";
        _testStringArray[2] = "Fed";
        _testStringArray[3] = "Mark";
        _testStringArray[4] = "Ted";

        return _testStringArray;
    }
    
    private static void Main()
    { 
        TestStringArray test = new TestStringArray();
        test._testPrintArray = test.GetStringArray();

        foreach (string TestPrint in test._testPrintArray)
        {
            Console.WriteLine(TestPrint);
        }

        Console.ReadKey();
    }
}

