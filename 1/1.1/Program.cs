int numVal = 2;
int currVal = 0;
int maxVal = 0;

for (int i = 0; i < numVal; i++)
{
    Console.Write($"Enter value [{i + 1}] = ");
    currVal = Convert.ToInt32(Console.ReadLine());
    
    if ((i == 0) || (currVal > maxVal))
        maxVal = currVal;
}

Console.WriteLine($"The maximum number: {maxVal}");