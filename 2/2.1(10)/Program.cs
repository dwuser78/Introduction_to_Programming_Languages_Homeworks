int showNum = 2;

Console.Write("Enter a 3-digit number: ");
string currDigitStr = Console.ReadLine();

Console.WriteLine($"The digit {showNum} is: {currDigitStr[showNum - 1]}");