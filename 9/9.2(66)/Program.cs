int CalcSum (int begin, int end)
{
    if (begin == end)
        return begin;
    else
    {
        begin += CalcSum(begin + 1, end);
        return begin;
    }
}

Console.Write("Enter the beginning of the range [M]: ");
int m = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter the end of the range [N]: ");
int n = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("The sum of natural numbers in the range from M to N: {0}",
                  CalcSum(m, n));