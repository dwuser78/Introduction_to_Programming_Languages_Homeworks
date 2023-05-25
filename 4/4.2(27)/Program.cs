int CalcNumDigits(int num)
{
    int digitCnt = 0;

    while (num > 0)
    {
        num /= 10;
        digitCnt++;
    }
 
    return digitCnt;
}

void ParseNumber(int num, int[] digits)
{
    for (int i = digits.Length; i > 0; i--)
    {
        digits[i - 1] = num % 10;
        num /= 10;
    }
}

int CalcSumm(int[] digits)
{
    int digitsSumm = 0;

    for (int i = 0; i < digits.Length; i++)
        digitsSumm += digits[i];

    return digitsSumm;
}

Console.Write("Enter the number: ");
int num = Convert.ToInt32(Console.ReadLine());

int[] digits = new int[CalcNumDigits(num)];

ParseNumber(num, digits);

Console.WriteLine("Sum of digits in a number: {0}", CalcSumm(digits));