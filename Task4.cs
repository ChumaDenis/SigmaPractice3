using System;

namespace ConsoleApp5
{
    class Matrix
    {
       private int[,] a;
       private int n;

        public Matrix()
        {
            n = 3;
            a = new int[n,n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    a[i, j] = 0;

                }
                

            }
        }
        public Matrix(int n)
        {
           this.n = n;
            a = new int[n, n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    a[i, j] = 0;

                }
                

            }
           
        }

        public void ShowMatr()
        {
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.Write("\n");

            }
            Console.Write("\n");
        }

        public void Magic()
        {
            int num = 1;
            int i = 0;
            int j = (n - 1) / 2;
            a[i,j] = num;
            
            for (num = 2; num <= n*n; num++)
            {
                int i1 = i;
                int j1 = j;
                i--;
                j++;

                 if (i < 0)
                 {
                     i = n - 1;
                 }

                 if (j >= n)
                 {
                     j = 0;
                 }

                if (a[i, j] == 0)
                {
                    a[i, j] = num;
                }
                else
                {
                    i = i1 + 1;
                    j = j1;
                    a[i, j] = num;
                }

                
            }
            
        }


        public void CheckSquare()
        {
            int MagConst = n * (n * n + 1) / 2;
            int[] SumOfRows = new int[n];
            int[] SumOfColmns = new int[n];
            int SumDiag1 = 0;
            Console.WriteLine($"Magic const = {MagConst}");
            for (int i=0;i<n;++i)
            {
                SumOfRows[i] = 0;
                SumOfColmns[i] = 0;
                for (int j=0;j<n;++j)
                {
                    SumOfRows[i] += a[i, j];
                    SumOfColmns[i] += a[j, i];
                    if (i == j)
                    {
                        SumDiag1 += a[i, j];
                    }
                }
                Console.WriteLine($"Sum rows = {SumOfRows[i]}");
                Console.WriteLine($"Sum collumns = {SumOfColmns[i]}");
            }
           
            
        }
    }
    class Program
    {
      
        static void Main(string[] args)
        {

            var matr = new Matrix(11);
            matr.Magic();
            
            matr.CheckSquare();
            
        }
    }
}
