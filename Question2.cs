using System.Text;

// Time spent: 1h
public class Question2
{
    public static string UnrollMatrix(int[] matrix, int rows, int columns)
    {
        int rowMaxIndex = rows - 1;
        int colMaxIndex = columns - 1;
        int elementsCount = rows * columns;
        int padding = 0;
        int col = 0;
        int row = 0;
        StringBuilder result = new();

        for (int i = 0; i < elementsCount; i++)
        {
            result.AppendFormat(i < elementsCount - 1 ? "{0}," : "{0}", matrix[row * columns + col]);

            // Left
            if (col < colMaxIndex - padding && row == padding)
            {
                col++;
            }
            // Right
            else if (col > padding && row == rowMaxIndex - padding)
            {
                col--;
            }
            // Down
            else if (row < rowMaxIndex - padding && col == colMaxIndex - padding)
            {
                row++;
            }
            // Up
            else if (row > padding + 1 && col == padding)
            {
                row--;
            }
            // End of a circle
            else if (col == padding && row == padding + 1)
            {
                col++;
                padding++;
            }
        }

        return result.ToString();
    }
}
