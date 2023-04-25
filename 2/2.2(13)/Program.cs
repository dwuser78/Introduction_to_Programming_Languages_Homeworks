int showNum = 3;

Console.Write("Enter a number: ");
string currDigitStr = Console.ReadLine();

if (currDigitStr.Length < showNum)
    Console.WriteLine($"The number {currDigitStr} is not {showNum}-digit");
else
    Console.WriteLine($"The digit {showNum} is: {currDigitStr[showNum - 1]}");