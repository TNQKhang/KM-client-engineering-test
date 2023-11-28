using System.Text;

// Time spent: 15'
public class Question1
{
    public static string FizzBuzz(int turns)
    {
        StringBuilder output = new();        
        
        for (int i = 1; i <= turns; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                output.AppendLine("FizzBuzz");
                continue;
            }

            if (i % 3 == 0)
            {
                output.AppendLine("Fizz");
                continue;
            }

            if (i % 5 == 0)
            {
                output.AppendLine("Buzz");
                continue;
            }

            output.AppendLine(i.ToString());
        }

        return output.ToString();
    }
}
