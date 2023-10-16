class Program
{
    static void Main(string[] args)
    {
        int[,] m = new int[,] { { 2, 2, -6}, { -4, 1, 3 }, { 1, 4, 0 } };
        Deter.DetThreeOnThree(m);
    }
}
