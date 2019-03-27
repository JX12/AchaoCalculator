using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_calculator
{
    class Program
    {
        static void Main(string[] args)
        {

            My_calcula c = new My_calcula(1000000);
            c.Cal_1();
            Console.ReadKey();
        }
    }
   public class Oprate
    {
        public Oprate(char op, int la)
        {
            opre = op;
            label = la;
        }
        public char opre;
        public int label;
    }
   public class My_calcula
    {
        public My_calcula(int n)
        {
            N = n;
        }
        private int N;
        Random R = new Random();
        public Oprate[] Opre = new Oprate[4];
        int[] Num = new int[5];
        public void Cal_1()
        {
            for (int i = 1; i <= N; i++)
            {
                lab:
                int Num_opre = R.Next(2,4);
                int x, j, result;
                for (j = 0; j < Num_opre; j++)
                {
                    Opre[j] = Func_ope();
                }
            
                for (x = 0; x <= Num_opre; x++)
                {
                    int num = R.Next(0, 100);
                    Num[x] = num;
                }
                result = Cal(x,Num,Opre);
                if (result != -1)
                {
                    Console.Write("第" + i + "道题 ：");
                    OutPut(x - 1);
                    Console.WriteLine(result);
                }
                else
                {
                    goto lab;
                }
            }
        }
        private Oprate Func_ope()
        {
            int a = R.Next(1, 4);
            Oprate b;
            if (a == 1)
            {
                b = new Oprate('+', 0);
                return b;
            }
            else if (a == 2)
            {
                b = new Oprate('-', 0);
                return b;
            }
            else if (a == 3)
            {
                b = new Oprate('*', 1);
                return b;
            }
            else
            {
                b = new Oprate('/', 1);
                return b;
            }
        }
        private void OutPut(int i)
        {
            int k, x = 0;
            for (k = 0; k < i; k++)
            {
                Console.Write(Num[k]);
                for (; x <= k; x++)
                {
                    Console.Write(Opre[x].opre);
                }
            }
            Console.Write(Num[k]);
            Console.Write("=");
            Console.WriteLine('\n');
        }
       public int Cal(int x,int [] w,Oprate [] Ot)
        {
            int[] a = new int[4];
            int top = 1, Otop = 0, i = 0;
            char[] b = new char[4];
            char q;
            a[0] = w[0];
            int j = 1;
            while (i < x - 1 || Otop != 0)
            {
                if (i < x - 2 && Ot[i].label < Ot[i + 1].label)
                {
                    b[Otop++] = Ot[i].opre;
                    a[top++] = Num[j++];
                }

                else if (i < x - 1)
                {
                    q = Ot[i].opre;
                    switch (q)
                    {
                        case '+': a[top - 1] += Num[j++]; break;
                        case '-': a[top - 1] -= Num[j++]; break;
                        case '*': a[top - 1] *= Num[j++]; break;
                        case '/':
                            int g, h; g = a[top - 1]; h = j; a[top - 1] /= Num[j++];
                            if (g %a[top - 1] != 0)
                                return -1;
                            else
                                break;
                    }
                }
                else
                {
                    char u;
                    u = b[--Otop];
                    switch (u)
                    {
                        case '+': a[top - 2] += a[top - 1]; break;
                        case '-': a[top - 2] -= a[top - 1]; break;
                        case '*': a[top - 2] *= a[top - 1]; break;
                        case '/':
                            int g; g = a[top - 2]; a[top - 2] /= a[top - 1];
                            if (g % a[top - 2] != 0 )
                                return -1;
                            else
                                break;
                    }

                }
                i++;
            }
            if (a[0] > 0)
                return a[0];
            else
                return -1;
        }

    }
}
