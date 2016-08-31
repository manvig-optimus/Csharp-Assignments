using System;

internal class TestSwitch
{
    private string _languageSelected;

    private void SelectLanguage()
    {
        Console.WriteLine("Please enter your preferred choice for language:");
        _languageSelected = Console.ReadLine().ToUpper();

        switch (_languageSelected)
        {
            case "VB":
                Console.WriteLine("VB .NET: OOP, multithreading and more!");
                break;
            case "C#":
                Console.WriteLine("Good Choice. C# is a fine language.");
                break;
            case "":
                Console.WriteLine("No language has been selected.");
                break;
            default:
                Console.WriteLine("Well... good luck with that!");
                break;
        }        
    }


    private static void Main()
    {
        TestSwitch test = new TestSwitch();
        test.SelectLanguage();

        Console.ReadKey();
    }
}

