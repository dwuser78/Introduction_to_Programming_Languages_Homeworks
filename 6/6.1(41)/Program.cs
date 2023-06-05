int numVal = 5; //This is "M" variable :)
int refVal = 0;
int countVal = 0;

int[] numArr = new int[numVal];

for (int i = 0; i < numVal; i++)
{
    Console.Write($"Enter value [{i + 1}] = ");
    numArr[i] = Convert.ToInt32(Console.ReadLine());

    if (numArr[i] > refVal)
        countVal++;
}

Console.WriteLine($"The number of values is greater than {refVal} = {countVal}");