void FillArray(int[,] array)
{
    Random rndDgt = new Random();

    for (int m = 0; m < array.GetLength((int) Pos.row); m++)
        for (int n = 0; n < array.GetLength((int) Pos.column); n++)
            array[m,n] = rndDgt.Next();
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

const int ROWS = 3;
const int COLUMNS = 4;
int row = 0;
int column = 0;

int[,] array = new int[ROWS, COLUMNS];

FillArray(array);
PrintArray(array);

Console.Write("Enter the row number = ");
row = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter the column number = ");
column = Convert.ToInt32(Console.ReadLine());

if ((row > 0 && column > 0) && (row <= ROWS && column <= COLUMNS))
{
    Console.WriteLine("Value of the array element [{0},{1}] = {2}", row,
                      column, array[row - 1,column - 1]);
}
else
{
    Console.WriteLine("There is no such element.");
}


enum Pos
{
    row,
    column
}