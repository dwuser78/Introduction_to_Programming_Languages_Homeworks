Console.Write("Enter the number: ");
int num = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter the degree of number: ");
int degree = Convert.ToInt32(Console.ReadLine());

int result = num;

for (int i = 0; i < degree - 1; i++)
    result *= num;

Console.WriteLine($"Number {num} in the {degree} degree is equal to {result}");