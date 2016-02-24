using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALGORITMI
{
    class Program
    {
        static void Main()
        {
            Matrice();

            int num = int.Parse(Console.ReadLine());
            ConversieDinBaza10InBaza2(num);
            Generator();
            MatricePataritica();

        
        }



        public static void Generator()
        {
            Console.WriteLine("Introduceti numarul de elemente ale matricei:");

            int k = int.Parse(Console.ReadLine());

            float[] a = new float[k + 1];
            a[0] = 1;
            float[] b = new float[k];
            for (int i = 0; i < k; i++)
            {
                a[i + 1] = (5 * a[i] + 3) / (a[i] + 3);
                b[i] = (a[i] + 3) / (a[i] + 1);
            }

            for (int i = 0; i < a.Length; i++)
            {

                Console.WriteLine(a[i]);
            }
            for (int i = 0; i < b.Length; i++)
            {
                Console.WriteLine(b[i]);
            }
        }



        private static void ConversieDinBaza10InBaza2(int numb)
        {

            int n = numb;
            int d = n;
            int c = d / 2; /* cˆatul ˆımp˘art¸irii ˆıntregi a lui d la 2 */
            int r = d % 2; /* restul ˆımp˘art¸irii ˆıntregi a lui d la 2 */
            Console.WriteLine(r);
            while (c != 0)
            {
                d = c;
                c = d / 2; /* cˆatul ˆımp˘art¸irii ˆıntregi a lui d la 2 */
                r = d % 2; /* restul ˆımp˘art¸irii ˆıntregi a lui d la 2 */
                Console.WriteLine(r);
            }
        }


        private static void Matrice()
        {

            int[][] matrice = new int[4][];
            matrice[0] = new int[3];
            matrice[1] = new int[3];
            matrice[2] = new int[3];
            matrice[3] = new int[3];
            matrice[0][0] = 1;
            matrice[0][1] = 1;
            matrice[0][2] = 1;
            matrice[1][0] = 2;
            matrice[1][1] = 2;
            matrice[1][2] = 2;
            matrice[2][0] = 3;
            matrice[2][1] = 3;
            matrice[2][2] = 3;
            matrice[3][0] = 4;
            matrice[3][1] = 4;
            matrice[3][2] = 4;

            StringBuilder sbmat = new StringBuilder();
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 3; i++)
                {

                    sbmat.Append(matrice[j][i]);

                }
                Console.WriteLine(sbmat);

                sbmat.Clear();

            }
            Console.WriteLine(matrice.Length);
        }


        public static void MatricePataritica()
        {
            int dim = int.Parse(Console.ReadLine());

            int[][] matricePatratica = new int[dim][];

            StringBuilder sbMatrice = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < dim; i++)
            {
                matricePatratica[i] = new int[dim];
                for (int j = 0; j < dim; j++)
                {
                    int rand = rnd.Next(0, 9);
                    matricePatratica[i][j] = rand;
                    sbMatrice.Append(matricePatratica[i][j] + " ");

                }

                Console.WriteLine(sbMatrice);
                sbMatrice.Clear();

            }
            Console.WriteLine("Matricea cu elementele de pe coloana principala aranjate crescator");



            List<int> diagonala = new List<int>();

            for (int k = 0; k < dim; k++)
            {


                diagonala.Add(matricePatratica[k][k]);
                Console.WriteLine(diagonala[k]);
            }


            diagonala.Sort();
            foreach (int sort in diagonala)
            {
                Console.WriteLine(sort);

            }

            for (int k = 0; k < dim; k++)
            {
                matricePatratica[k][k] = diagonala[k];
                Console.WriteLine("Number" + matricePatratica[k][k]);
            }


            for (int i = 0; i < dim; i++)
            {

                for (int j = 0; j < dim; j++)
                {

                    sbMatrice.Append(matricePatratica[i][j] + " ");

                }

                Console.WriteLine(sbMatrice);
                sbMatrice.Clear();

            }

        }


        
           

       




    }
}

