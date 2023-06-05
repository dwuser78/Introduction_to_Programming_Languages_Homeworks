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

void CalcAvg(int[,] array, double[] avgValues)
{
    const int ACCURACY = 1;

    for (int m = 0; m < array.GetLength((int) Pos.row); m++)
    {
        for (int n = 0; n < array.GetLength((int) Pos.column); n++)
        {
            if (m < array.GetLength((int) Pos.row) - 1)
            {
                avgValues[n] += array[m,n];
            }
            else
            {
                avgValues[n] += array[m,n];
                avgValues[n] /= (m + 1);
            }
        }
    }

    Console.WriteLine("Average values by columns:");
    for (int n = 0; n < avgValues.Length; n++)
    {
        Console.Write("{0}", Math.Round(avgValues[n], ACCURACY));

        if (n == avgValues.Length - 1)
            Console.Write("\n");
        else
            Console.Write(" ");
    }
}

const int ROWS = 3;
const int COLUMNS = 4;

int[,] array = new int[ROWS, COLUMNS];
double[] avgValues = new double[COLUMNS];

FillArray(array);
PrintArray(array);
CalcAvg(array, avgValues);

enum Pos
{
    row,
    column
}