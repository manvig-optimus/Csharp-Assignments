using System;

public enum WeekDays
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday
}

internal class TestEnum
{
    private string[] _weekDays;
    private int _weekday;
    

    private void GetWeekDays()
    {
        Console.WriteLine("The weekdays present in enum are:");

        _weekDays = Enum.GetNames(typeof(WeekDays));

        foreach (string day in _weekDays)
        {
            Console.WriteLine(day);
        }
        Console.WriteLine("");
    }

    private void GetWeekDayMessage()
    {
        _weekday = (int)WeekDays.Wednesday;
        switch (_weekday)
        {
            case 0:
                Console.WriteLine("The selected day is {0}.", WeekDays.Monday);
                break;
            case 1:
                Console.WriteLine("The selected day is {0}.", WeekDays.Tuesday);
                break;
            case 2:
                Console.WriteLine("The selected day is {0}.", WeekDays.Wednesday);
                break;
            case 3:
                Console.WriteLine("The selected day is {0}.", WeekDays.Thursday);
                break;
            case 4:
                Console.WriteLine("The selected day is {0}.", WeekDays.Friday);
                break;
            default:
                Console.WriteLine("No weekday is selected.");
                break;
        }
    }
    
    private static void Main(string[] args)
    {
        TestEnum test = new TestEnum();
        test.GetWeekDays();
        test.GetWeekDayMessage();

        Console.ReadKey();
    }
}
