void FillArray(int[,] array)
{
    const int MIN_VAL = 1;
    const int MAX_VAL = 10;

    Random rndDgt = new Random();

    for (int m = 0; m < array.GetLength((int) Pos.row); m++)
        for (int n = 0; n < array.GetLength((int) Pos.column); n++)
            array[m,n] = rndDgt.Next(MIN_VAL, MAX_VAL);
}

void PrintArray(int[,] array)
{
    for (int m = 0; m < array.GetLength((int) Pos.row); m++)
    {
        for (int n = 0; n < array.GetLength((int) Pos.column); n++)
        {
            if (n == array.GetLength((int) Pos.column) - 1)
                Console.Write("{0}\n", array[m,n]);
            else
                Console.Write("{0} ", array[m,n]);
        }
    }
}

int GetColSum(int[,] array, int row)
{
    int sumValues = 0;

    for (int n = 0; n < array.GetLength((int) Pos.column); n++)
        sumValues += array[row,n];

    return sumValues;
}

int FindMinSumRow(int[,] array)
{
    int minRowPos = 0;
    int minVal = GetColSum(array, minRowPos);
    int currVal;

    for (int m = 0; m < array.GetLength((int) Pos.row); m++)
    {
        currVal = GetColSum(array, m);

        if (currVal < minVal)
        {
            minVal = currVal;
            minRowPos = m;
        }
    }

    return minRowPos + 1;
}

const int ROWS = 4;
const int COLUMNS = 4;

int[,] array = new int[ROWS, COLUMNS];

FillArray(array);
PrintArray(array);

Console.WriteLine("The row with the minimum sum: {0}", FindMinSumRow(array));

enum Pos
{
    row,
    column
}