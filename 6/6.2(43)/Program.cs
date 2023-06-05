void InputValues(double[] values)
{
    for (int i = 0; i < values.Length; i++)
    {
        Console.Write("Enter {0} = ", Enum.GetName(typeof(Vars), i));
        values[i] = Convert.ToDouble(Console.ReadLine());
    }
}

void CalcIntersectionPoint(double[] values, ref double x, ref double y)
{
    x = (values[(int) Vars.b2] - values[(int) Vars.b1]) /
        (values[(int) Vars.k1] - values[(int) Vars.k2]);

    y = values[(int) Vars.k1] * ((values[(int) Vars.b2] - values[(int) Vars.b1]) /
        (values[(int) Vars.k1] - values[(int) Vars.k2])) + values[(int) Vars.b1];
}

double x = 0;
double y = 0;
int accuracy = 1;

double[] values = new double[(int) Vars.length];

Console.WriteLine("Find the intersection point of two straight lines given " +
                  "by the equations:\ny = k1 * x + b1;\ny = k2 * x + b2;");
InputValues(values);

if (values[(int) Vars.k1] == values [(int) Vars.k2])
{
    Console.WriteLine("The lines are parallel and have no intersection point.");
}
else
{
    CalcIntersectionPoint(values, ref x, ref y);
    Console.WriteLine("The lines intersect at a point (x, y): ({0}, {1})",
                      Math.Pow(x, accuracy), Math.Pow(y, accuracy));
}

enum Vars
{
    k1,
    b1,
    k2,
    b2,
    length
}