int startSeq = 1;

Console.Write("Enter the upper bound of the sequence: ");
int endSeq = Convert.ToInt32(Console.ReadLine());

Console.Write($"Even numbers in the sequence [{startSeq}-{endSeq}]:");

for (int i = startSeq; i <= endSeq; i++)
{
    if ((i % 2) == 0)
        Console.Write($" {i}");
}