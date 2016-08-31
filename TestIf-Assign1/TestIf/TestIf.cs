using System;

class TestIf
{
    private string _languageSelected;
    
    private void SelectLanguage()
    {
        Console.WriteLine("Please enter your preferred choice for language:");
        _languageSelected = Console.ReadLine().ToUpper();

        if (_languageSelected == "VB")
        {
            Console.WriteLine("VB .NET: OOP, multithreading and more!");
        }
        else if (_languageSelected == "C#")
        {
            Console.WriteLine("Good Choice. C# is a fine language.");
        }
        else if (_languageSelected.Length == 0)
        {
            Console.WriteLine("No language has been selected.");
        }
        else
        {
            Console.WriteLine("Well... good luck with that!");
        }        
    }
        
    
    private static void Main()
    {
        TestIf test = new TestIf();
        test.SelectLanguage();

        Console.ReadKey();
    }
}

