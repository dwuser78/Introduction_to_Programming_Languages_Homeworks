void CalcRange(int digitNum, ref int startRange, ref int endRange)
{
    int tmpBuf = 1;

    for (int i = 0; i < digitNum; i++)
        tmpBuf *= 10;

    startRange = tmpBuf / 10;
    endRange = tmpBuf - 1;
}

void FillArrayRandom(int[] numArr, int startRange, int endRange)
{
    Random rndDgt = new Random();

    for (int i = 0; i < numArr.Length; i++)
        numArr[i] = rndDgt.Next(startRange, endRange);
}

int EvenCalc(int[] numArr)
{
    int evenCntr = 0;

    for (int i = 0; i < numArr.Length; i++)
    {
        if ((numArr[i] % 2) == 0)
            evenCntr++;
    }

    return evenCntr;
}

int digitNum = 3;
int startRange = 0;
int endRange = 0;

Console.Write($"Enter the number of {digitNum}-digit numbers: ");
int arrSize = Convert.ToInt32(Console.ReadLine());

int[] numArr = new int[arrSize];

CalcRange(digitNum, ref startRange, ref endRange);
FillArrayRandom(numArr, startRange, endRange);

Console.WriteLine($"Number of even numbers: {EvenCalc(numArr)}");