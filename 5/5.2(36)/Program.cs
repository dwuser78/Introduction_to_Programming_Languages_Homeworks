void FillArrayRandom(int[] numArr)
{
    Random rndDgt = new Random();

    for (int i = 0; i < numArr.Length; i++)
        numArr[i] = rndDgt.Next();
}

long CalcSumOddPos(int[] numArr)
{
    long oddPosSum = 0;

    for (int i = 0; i < numArr.Length; i++)
    {
        /*
         * If it is the position (see the task condition) that is meant, and
         * not its index, then +1, if the position = index, then +1 is not
         * necessary.
         */
        if (((i + 1) % 2) != 0)
            oddPosSum += numArr[i];
    }

    return oddPosSum;
}

Console.Write("Enter the number of numbers: ");
int arrSize = Convert.ToInt32(Console.ReadLine());

int[] numArr = new int[arrSize];

FillArrayRandom(numArr);

Console.WriteLine("The sum of the elements standing in odd positions: {0}",
                  CalcSumOddPos(numArr));