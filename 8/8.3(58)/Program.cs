void CreateMatrix(int[,] matrix)
{
    const int MIN_VAL = 1;
    const int MAX_VAL = 10;

    Random rndDgt = new Random();

    for (int m = 0; m < matrix.GetLength((int) Pos.row); m++)
        for (int n = 0; n < matrix.GetLength((int) Pos.column); n++)
            matrix[m, n] = rndDgt.Next(MIN_VAL, MAX_VAL);
}

void PrintMatrix(int[,] matrix)
{
    for (int m = 0; m < matrix.GetLength((int) Pos.row); m++)
    {
        for (int n = 0; n < matrix.GetLength((int) Pos.column); n++)
        {
            if (n == 0)
                Console.Write("|{0} ", matrix[m, n]);
            else if (n == matrix.GetLength((int) Pos.column) - 1)
                Console.Write("{0}|\n", matrix[m, n]);
            else
                Console.Write("{0} ", matrix[m, n]);
        }
    }
}

bool CheckMatrices(int[,] matrixA, int[,] matrixB)
{
    if (matrixA.GetLength((int) Pos.column) == matrixB.GetLength((int) Pos.row))
        return true;
    else
        return false;
}

int GetNewDimension(int[,] matrix)
{
    int newDmtn;

    if (matrix.GetLength((int) Pos.column) > matrix.GetLength((int) Pos.row))
        newDmtn = matrix.GetLength((int) Pos.column);
    else
        newDmtn = matrix.GetLength((int) Pos.row);

    if (newDmtn % 2 != 0)
        newDmtn++;
    
    return newDmtn;
}

int GetResMatrixSize(int[,] matrixA, int[,] matrixB, bool trivialCalc)
{
    int matrixSise = 0;

    if (!trivialCalc)
    {
        int dimA = GetNewDimension(matrixA);
        int dimB = GetNewDimension(matrixB);

        if (dimA >= dimB)
            matrixSise = dimA;
        else
            matrixSise = dimB;
    }
    else
    {
        if (matrixA.Length >= matrixB.Length)
        {
            if (matrixA.GetLength((int) Pos.row) >=
                matrixA.GetLength((int) Pos.column))
            {
                matrixSise = matrixA.GetLength((int) Pos.row);
            }
            else
            {
                matrixSise = matrixA.GetLength((int) Pos.column);
            }
        }
        else
        {
            if (matrixB.GetLength((int) Pos.row) >=
                matrixB.GetLength((int) Pos.column))
            {
                matrixSise = matrixB.GetLength((int) Pos.row);
            }
            else
            {
                matrixSise = matrixB.GetLength((int) Pos.column);
            }
        }
    }

    return matrixSise;
}

int[,] AddMatrixDim(int[,] matrix, int newDim)
{
    int[,] newMatrix = new int [newDim, newDim];
    for (int m = 0; m < matrix.GetLength((int) Pos.row); m++)
    {
        for (int n = 0; n < matrix.GetLength((int) Pos.column); n++)
        {
            newMatrix[m, n] = matrix[m, n];
        }
    }

    return newMatrix;
}

void SplitMatrix(int[,] matrix, int[,] matrix11, int[,] matrix12,
                 int[,] matrix21, int[,] matrix22)
{
    int dim = matrix.GetLength((int) Pos.column) / 2;

    for (int m = 0; m < dim; m++)
    {
        for (int n = 0; n < dim; n++)
        {
            matrix11[m, n] = matrix[m, n];
            matrix12[m, n] = matrix[m, n + dim];
            matrix21[m, n] = matrix[m + dim, n];
            matrix22[m, n] = matrix[m + dim, n + dim];
        }
    }
}

int[,] JoinMatrix(int[,] matrix11, int[,] matrix12, int[,] matrix21,
                  int[,] matrix22)
{
    int dim = matrix11.GetLength((int) Pos.column);
    int size = dim * 2;
    int[,] matrix = new int[size, size];

    for (int m = 0; m < dim; m++)
    {
        for (int n = 0; n < dim; n++)
        {
            matrix[m, n] = matrix11[m, n];
            matrix[m, n + dim] = matrix12[m, n];
            matrix[m + dim, n] = matrix21[m, n];
            matrix[m + dim, n + dim] = matrix22[m, n];
        }
    }

    return matrix;
}

int[,] SumMatrix(int[,] matrixA, int[,] matrixB)
{
    int dim = matrixA.GetLength((int) Pos.column);

    int[,] matrixC = new int[dim, dim];

    for (var m = 0; m < dim; m++)
    {
        for (var n = 0; n < dim; n++)
        {
            matrixC[m, n] = matrixA[m, n] + matrixB[m, n];
        }
    }

    return matrixC;
}

int[,] SubtMatrix(int[,] matrixA, int[,] matrixB)
{
    int dim = matrixA.GetLength((int) Pos.column);

    int[,] matrixC = new int[dim, dim];

    for (var m = 0; m < dim; m++)
    {
        for (var n = 0; n < dim; n++)
        {
            matrixC[m, n] = matrixA[m, n] - matrixB[m, n];
        }
    }

    return matrixC;
}

int[,] CalcTrivialMultiply(int[,] matrixA, int[,] matrixB, int dimension)
{
    int[,] matrixAB = new int[dimension,dimension];

    for (int i = 0; i < matrixA.GetLength((int) Pos.row); i++)
    {
        for (int j = 0; j < matrixB.GetLength((int) Pos.column); j++)
        {
            for (int k = 0; k < matrixA.GetLength((int) Pos.column); k++)
            {
                matrixAB[i, j] += matrixA[i, k] * matrixB[k, j];
            }
        }
    }

    return matrixAB;
}

int[,] CalcStrassenMultiply(int[,] matrixA, int[,] matrixB, int dimension)
{
    if (dimension <= LimitsConst.matrixSeparationLimit)
        return CalcTrivialMultiply(matrixA, matrixB, dimension);

    int[,] a11 = new int[dimension, dimension];
    int[,] a12 = new int[dimension, dimension];
    int[,] a21 = new int[dimension, dimension];
    int[,] a22 = new int[dimension, dimension];

    int[,] b11 = new int[dimension, dimension];
    int[,] b12 = new int[dimension, dimension];
    int[,] b21 = new int[dimension, dimension];
    int[,] b22 = new int[dimension, dimension];

    SplitMatrix(matrixA, a11, a12, a21, a22);
    SplitMatrix(matrixB, b11, b12, b21, b22);

    int[,] p1 = CalcStrassenMultiply(SumMatrix(a11, a22), SumMatrix(b11, b22),
                                     dimension);
    int[,] p2 = CalcStrassenMultiply(SumMatrix(a21, a22), b11, dimension);
    int[,] p3 = CalcStrassenMultiply(a11, SubtMatrix(b12, b22), dimension);
    int[,] p4 = CalcStrassenMultiply(a22, SubtMatrix(b21, b11), dimension);
    int[,] p5 = CalcStrassenMultiply(SumMatrix(a11, a12), b22, dimension);
    int[,] p6 = CalcStrassenMultiply(SubtMatrix(a21, a11), SumMatrix(b11, b12),
                                     dimension);
    int[,] p7 = CalcStrassenMultiply(SubtMatrix(a12, a22), SumMatrix(b21, b22),
                                     dimension);

    int[,] c11 = SumMatrix(SumMatrix(p1, p4), SubtMatrix(p7, p5));
    int[,] c12 = SumMatrix(p3, p5);
    int[,] c21 = SumMatrix(p2, p4);
    int[,] c22 = SumMatrix(SubtMatrix(p1, p2), SumMatrix(p3, p6));

    return JoinMatrix(c11, c12, c21, c22);
}

Console.WriteLine("Enter the size of the matrix A [Row, Column]:");
Console.Write("Row = ");
int matrixARow = Convert.ToInt32(Console.ReadLine());
Console.Write("Column = ");
int matrixACol = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter the size of the matrix B [Row, Column]:");
Console.Write("Row = ");
int matrixBRow = Convert.ToInt32(Console.ReadLine());
Console.Write("Column = ");
int matrixBCol = Convert.ToInt32(Console.ReadLine());

int[,] matrixA = new int[matrixARow, matrixACol];
int[,] matrixB = new int[matrixBRow, matrixBCol];

bool trivialCalc;

if (!CheckMatrices(matrixA, matrixB))
{
    Console.WriteLine("The matrices are not consistent.");
    Environment.Exit(1);
}

/*
 * If the matrices have a large size, it is preferable to use the Strassen
 * algorithm for their multiplication (Skiena Steven, "The Algorithm Design
 * Manual")
 */
if (matrixA.Length >= LimitsConst.bigSizeMatrix ||
    matrixB.Length >= LimitsConst.bigSizeMatrix)
{
    trivialCalc = false;
}
else
{
    trivialCalc = true;
}

int newDim = GetResMatrixSize(matrixA, matrixB, trivialCalc);
int[,] matrixAB = new int[newDim, newDim];

CreateMatrix(matrixA);
CreateMatrix(matrixB);

Console.WriteLine("\nMatrix A:");
PrintMatrix(matrixA);

Console.WriteLine("\nMatrix B:");
PrintMatrix(matrixB);

if (trivialCalc)
{
    matrixAB = CalcTrivialMultiply(matrixA, matrixB, newDim);
}
else
{
    matrixA = AddMatrixDim(matrixA, newDim);
    matrixB = AddMatrixDim(matrixB, newDim);

    matrixAB = CalcStrassenMultiply(matrixA, matrixB, newDim);
}

Console.WriteLine("\nMatrix AB:");
PrintMatrix(matrixAB);

static class LimitsConst
{
    public const int bigSizeMatrix = 180;
    public const int matrixSeparationLimit = 64;
}
enum Pos
{
    row,
    column
}