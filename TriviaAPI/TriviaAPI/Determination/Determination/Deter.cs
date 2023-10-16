using System.Runtime.InteropServices;

public static class Deter
{
    private static int[,] dd = new int[2,2];
    private static int counter = 0;
    public static int DetTwoOnTwo(int[,] d)
    {
        Console.WriteLine(d[0,0] * d[1,1] - d[0, 1] * d[1,0]);
        return d[0, 0] * d[1, 1] - d[0, 1] * d[1, 0];
    }

    public static void DetThreeOnThree(int[,] d)
    {
        int number = 0;
        for (int i = 0; i < d.GetLength(0); i++)
        {
            if (i == 0)
            {
                for (int j = 0; j < dd.GetLength(1); j++)
                {
                    for (int k = 0; k < dd.GetLength(0); k++)
                    {
                        dd[j, k] = d[j+1, k+1];
                    }
                }
                number = d[0,0] * DetTwoOnTwo(dd);
            }
            else if (i == 1)
            {
                dd[0, 0] = d[1, 0];
                dd[0, 1] = d[1, 2];
                dd[1, 0] = d[2, 0];
                dd[1, 1] = d[2, 2];

                number -= d[0, 1] * DetTwoOnTwo(dd);
            }
            else
            {
                dd[0, 0] = d[1, 0];
                dd[0, 1] = d[1, 1];
                dd[1, 0] = d[2, 0];
                dd[1, 1] = d[2, 1];
                number += d[0, 2] * DetTwoOnTwo(dd);
            }
        }
        Console.WriteLine(number);
    }
}