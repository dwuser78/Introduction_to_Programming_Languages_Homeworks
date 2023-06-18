uint Ackermann(uint m, uint n)
{
    if (m == 0)
        return n + 1;
    else if (m > 0 && n == 0)
        return Ackermann(m - 1, 1);
    else
        return Ackermann(m - 1, Ackermann(m, n - 1));
}

Console.Write("Enter the first argument [M]: ");
uint m = Convert.ToUInt32(Console.ReadLine());
Console.Write("Enter the second argument [N]: ");
uint n = Convert.ToUInt32(Console.ReadLine());

Console.WriteLine("The result of the Ackermann function for M and N: {0}",
                  Ackermann(m, n));