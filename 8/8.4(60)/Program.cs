bool CheckValue(int[] values, int value)
{
    return values[value - LimitsConst.minRndVal] == LimitsConst.exist;
}

void SetValue(int[] values, int value)
{
    values[value - LimitsConst.minRndVal] = LimitsConst.exist;
}

void FillArray(int[,,] array)
{
    int value;
    int[] exValues = new int[LimitsConst.maxRndVal - LimitsConst.minRndVal];
    Random rndDgt = new Random();

    for (int z = 0; z < array.GetLength((int) Pos.z); z++)
    {
        for (int y = 0; y < array.GetLength((int) Pos.y); y++)
        {
            for (int x = 0; x < array.GetLength((int) Pos.x); x++)
            {
                do
                {
                    value = rndDgt.Next(LimitsConst.minRndVal,
                                        LimitsConst.maxRndVal);
                } while (CheckValue(exValues, value));

                array[z, y, x] = value;
                SetValue(exValues, value);
            }
        }
    }
}

void PrintArray(int[,,] array)
{
    for (int z = 0; z < array.GetLength((int) Pos.z); z++)
    {
        for (int y = 0; y < array.GetLength((int) Pos.y); y++)
        {
            for (int x = 0; x < array.GetLength((int) Pos.x); x++)
            {
                if (x == array.GetLength((int) Pos.x) - 1)
                Console.Write($"{array[z, y, x]}({z}, {y}, {x})\n");
            else
                Console.Write($"{array[z, y, x]}({z}, {y}, {x}) ");
            }
        }
    }
}

Console.WriteLine("Enter the size of the array [x, y, z]:");
Console.Write("X = ");
int maxX = Convert.ToInt32(Console.ReadLine());
Console.Write("Y = ");
int maxY = Convert.ToInt32(Console.ReadLine());
Console.Write("Z = ");
int maxZ = Convert.ToInt32(Console.ReadLine());

if ((maxX * maxY * maxZ) > (LimitsConst.maxRndVal - LimitsConst.minRndVal))
{
    Console.WriteLine("The array sizes are set too large.");
    Environment.Exit(1);
}

int[,,] array = new int[maxZ, maxY, maxX];

FillArray(array);
PrintArray(array);

static class LimitsConst
{
    public const int minRndVal = 10;
    public const int maxRndVal = 99;
    public const int exist = 1;
}
enum Pos
{
    z,
    y,
    x
}