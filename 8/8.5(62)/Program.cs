void FillArray(int[,] array)
{
    int m = array.GetLength((int) Pos.row);
    int n = array.GetLength((int) Pos.column);
    int currVal = 1;
    int row = 0;
    int col = 0;
    int rowBeg = 0;
    int rowEnd = 0;
    int colBeg = 0;
    int colEnd = 0;

    while (currVal <= n * m)
    {
        array[row, col] = currVal;
        if (row == rowBeg && col < m - colEnd - 1)
            col++;
        else if (col == m - colEnd - 1 && row < n - rowEnd - 1)
            row++;
        else if (row == n - rowEnd - 1 && col > colBeg)
            col--;
        else
            row--;

        if ((row == rowBeg + 1) && (col == colBeg) &&
            (colBeg != m - colEnd - 1))
        {
            rowBeg++;
            rowEnd++;
            colBeg++;
            colEnd++;
        }
        currVal++;
    }
}

void PrintArray(int[,] array)
{
    for (int m = 0; m < array.GetLength((int) Pos.row); m++)
    {
        for (int n = 0; n < array.GetLength((int) Pos.column); n++)
        {
            if (n == array.GetLength((int) Pos.column) - 1)
                Console.Write("{0}\n", array[m,n]);
            else
                Console.Write("{0} ", array[m,n]);
        }
    }
}

const int ROWS = 4;
const int COLUMNS = 4;

int[,] array = new int[ROWS, COLUMNS];

FillArray(array);
PrintArray(array);

enum Pos
{
    row,
    column
}