Console.Write("Enter a number: ");
int currNum = Convert.ToInt32(Console.ReadLine());

if ((currNum % 2) == 0)
    Console.WriteLine($"The number {currNum} is even.");
else
    Console.WriteLine($"The number {currNum} is odd.");