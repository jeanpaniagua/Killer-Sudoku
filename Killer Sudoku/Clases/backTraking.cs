using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku.Clases
{
    class backTraking
    {

        private byte tam;

        public backTraking(byte tamanho)
        {
            this.tam = tamanho;
        }

        public void resuelveReg(List<region> regList)
        {
            foreach (region reg in regList)
            {
                if (reg.getPieza()[1] == null)
                {
                    reg.getPieza()[0].setValor(reg.getResultado());
                }
                else
                {
                    int[] solucion = new int[4];
                    Console.WriteLine("Va a entrar.");
                    backTrack(reg, solucion, 0);
                    Console.WriteLine("Sale.");
                    imprime(reg);
                    break;//Este se elimina, lo puse para que lo hiciera con una sola región....
                }
            }
        }

        public void imprime(region reg)
        {
            Console.WriteLine("imprime");
            foreach (int[] obj in reg.soluciones)
            {
                Console.WriteLine("Entra 4E");
                Console.WriteLine("Solución para " + reg.getOperador() + " " + reg.getResultado() + ":");
                Console.WriteLine(obj[0] + ", " + obj[1] + ", " + obj[2] + ", "+ obj[3] + ".");
            }
        }

        public Boolean backTrack(region reg, int[] sol, int pos)
        {
            for(int i = 1; i <= tam; i++)
            {
                Console.WriteLine("Entra con pos = " + pos + ", i = " + i);
                if (i >= reg.getResultado())
                {
                    break;
                }
                else if (pos == 3)
                {
                    sol[3] = i;
                    int res = 0;
                    if (reg.getOperador() == '+')
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            res += sol[j];
                        }
                        Console.WriteLine("Operador +; res = " + res + ", RES " + reg.getResultado());
                    }
                    else if (reg.getOperador() == 'X')
                    {
                        res = 1;
                        for (int j = 0; j < 4; j++)
                        {
                            res = res * sol[j];
                        }
                        Console.WriteLine("Operador X; res = " + res + ", RES " + reg.getResultado());
                    }
                    if (reg.getResultado() == res)
                    {
                        Console.WriteLine("Check");
                        for(int x = 0; x < 4; x++)
                        {
                            Console.Write(sol[0] + ", ");
                        }
                        reg.soluciones.Add(sol);
                        return true;
                    }
                    else if (reg.getResultado() < res)
                    {
                        break;
                    }
                }
                else
                {
                    if (pos < 3)
                    {
                        Console.WriteLine("pos = " + pos + ", i = " + i);
                        sol[pos] = i;
                        backTrack(reg, sol, (pos+1));
                    }
                }
            }
            return false;
        }

    }
}
