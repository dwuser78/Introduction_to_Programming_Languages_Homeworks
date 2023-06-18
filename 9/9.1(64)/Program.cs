int NextNum (int begin, int end)
{
    Console.Write($"{begin}");

    if (begin == end)
    {
        return begin;
    }
    else
    {
        Console.Write(", ");
        begin += 1;
        return NextNum(begin, end);
    }
}

Console.Write("Enter the beginning of the range [M]: ");
int m = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter the end of the range [N]: ");
int n = Convert.ToInt32(Console.ReadLine());

Console.Write("Natural numbers in the range from M to N: ");
NextNum(m, n);