namespace MyChessProj;

internal class Program
{
    static void Main(string[] args)
    {
        int n = 8;
        char[,] matrix = new char[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == j)
                {
                    matrix[i, j] = '#';
                }
                else
                {
                    matrix[i, j] = '*';
                }
            }
        }


        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        } 
    }


        public static bool CanRookMove(int x1, int y1, int x2, int y2)
    {
        if (x1 == x2 || y1 == y2)
        {
            return true;
        }

        return false;
    }

}
