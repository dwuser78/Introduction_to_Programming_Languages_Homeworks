int dayOfWeek;
const int daysInWeek = 7;

Console.Write("Enter the number of the day of the week [1-7]: ");
dayOfWeek = Convert.ToInt32(Console.ReadLine());

if ((dayOfWeek > daysInWeek) || (dayOfWeek == 0))
    Console.WriteLine("There is no such day of the week");
else if (dayOfWeek < 6)
    Console.WriteLine($"Day of week {dayOfWeek} is a weekday");
else
    Console.WriteLine($"Day of week {dayOfWeek} is a weekend");