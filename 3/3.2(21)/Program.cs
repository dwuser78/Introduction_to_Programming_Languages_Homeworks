void FillCoordinates(int[] point)
{
    for(int i = 0; i < (int) Axis.length; i++)
    {
        Console.Write("Enter {0} = ", Enum.GetName(typeof(Axis), i));
        point[i] = Convert.ToInt32(Console.ReadLine());
    }
}

double CalcDistance(int[] point1, int[] point2)
{
    double summSqrDiff = 0;

    for(int i = 0; i < (int) Axis.length; i++)
        summSqrDiff += Math.Pow(Convert.ToDouble(point2[i] - point1[i]), 2);

    return Math.Sqrt(summSqrDiff);
}

const int accuracy = 2;
int[] point1 = new int[(int) Axis.length];
int[] point2 = new int[(int) Axis.length];

Console.WriteLine("Enter the coordinates of the first point:");
FillCoordinates(point1);

Console.WriteLine("Enter the coordinates of the second point:");
FillCoordinates(point2);

Console.WriteLine("Distance between points: {0}",
                  Math.Round(CalcDistance(point1, point2), accuracy));

enum Axis
{
    x,
    y,
    z,
    length
}