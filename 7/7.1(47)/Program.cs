void FillArray(double[,] array)
{
    Random rndDgt = new Random();

    for (int m = 0; m < array.GetLength((int) Pos.row); m++)
        for (int n = 0; n < array.GetLength((int) Pos.column); n++)
            array[m,n] = rndDgt.NextDouble();
}

void PrintArray(double[,] array)
{
    const int ACCURACY = 1;

    for (int m = 0; m < array.GetLength((int) Pos.row); m++)
    {
        for (int n = 0; n < array.GetLength((int) Pos.column); n++)
        {
            Console.Write("{0}", Math.Round(array[m,n], ACCURACY));

            if (n == array.GetLength((int) Pos.column) - 1)
                Console.Write("\n");
            else
                Console.Write(" ");
        }
    }
}

int m = 0;
int n = 0;

Console.Write("Enter number of rows = ");
m = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter number of columns = ");
n = Convert.ToInt32(Console.ReadLine());

double[,] array = new double[m, n];

FillArray(array);
PrintArray(array);

enum Pos
{
    row,
    column
}