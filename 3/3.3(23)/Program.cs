void AddCubicDegree(ref string str, int num)
{
    const int degree = 3;

    if (str.Length > 0)
        str += ", ";

    str += Convert.ToString(Math.Pow(num, degree));
}

Console.Write("Enter a number: ");
int inNum = Convert.ToInt32(Console.ReadLine());

string outStr = String.Empty;

for (int i = 0; i < inNum; i++)
    AddCubicDegree(ref outStr, i + 1);

Console.WriteLine($"Table of cubes for numbers [1-{inNum}]: {outStr}");