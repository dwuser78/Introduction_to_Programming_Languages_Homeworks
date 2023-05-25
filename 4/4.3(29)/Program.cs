void FillArray(int[] numArr)
{
    for (int i = 0; i < numArr.Length; i++)
    {
        Console.Write($"Enter the number [{i + 1}]: ");
        numArr[i] = Convert.ToInt32(Console.ReadLine());
    }
}

void PrintArray(int[] numArr)
{
    Console.Write("Your array: [");

    for (int i = 0; i < numArr.Length; i++)
    {
        Console.Write($"{numArr[i]}");

        if (i < numArr.Length - 1)
            Console.Write(", ");
        else
            Console.Write("]");
    }
}

int totalDgts = 8;
int[] numArr = new int[totalDgts];

Console.WriteLine($"Enter {totalDgts} numbers.");
FillArray(numArr);

PrintArray(numArr);