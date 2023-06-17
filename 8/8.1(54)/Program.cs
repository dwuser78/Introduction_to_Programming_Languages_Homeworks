static void Swap<T>(ref T xVal, ref T yVal)
{
    T tmp = xVal;
    xVal = yVal;
    yVal = tmp;
}

int Partition(int[,] array, int row, int l, int h)
{
    int i;
    int p;
    int firsthigh;

    p = h;
    firsthigh = l;

    for (i = l; i < h; i++)
    {
        if (array[row,i] > array[row,p])
        {
            Swap(ref array[row,i], ref array[row,firsthigh]);
            firsthigh++;
        }
    }

    Swap(ref array[row,p], ref array[row,firsthigh]);

    return firsthigh;
}

void QuickSort(int[,] array, int row, int l, int h)
{ 
    int p;

    if ((h - l) > 0)
    {
        p = Partition(array, row, l, h);
        QuickSort(array, row, l, p - 1);
        QuickSort(array, row, p + 1, h);
    }
}

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

void SortLines(int[,] array)
{
    for (int row = 0; row < array.GetLength((int) Pos.row); row++)
    {
        QuickSort(array, row, 0, array.GetLength((int) Pos.column) - 1);
    }
}

const int ROWS = 3;
const int COLUMNS = 4;

int[,] array = new int[ROWS, COLUMNS];

FillArray(array);

Console.WriteLine("Source array:");
PrintArray(array);

SortLines(array);
Console.WriteLine("\nSorted array:");
PrintArray(array);

enum Pos
{
    row,
    column
}