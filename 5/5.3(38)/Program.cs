void FillArrayRandom(double[] numArr)
{
    Random rndDgt = new Random();

    for (int i = 0; i < numArr.Length; i++)
        numArr[i] = rndDgt.NextDouble();
}

void FindExtremum(double[] numArr, ref double maxVal, ref double minVal)
{
    for (int i = 0; i < numArr.Length; i++)
    {
        if ((i == 0) || (numArr[i] > maxVal))
            maxVal = numArr[i];

        if ((i == 0) || (numArr[i] < minVal))
            minVal = numArr[i];
    }
}

double maxVal = 0;
double minVal = 0;

Console.Write("Enter the number of numbers: ");
int arrSize = Convert.ToInt32(Console.ReadLine());

double[] numArr = new double[arrSize];

FillArrayRandom(numArr);
FindExtremum(numArr, ref maxVal, ref minVal);

Console.WriteLine("Difference between the max and min array elements: {0}",
                  maxVal - minVal);