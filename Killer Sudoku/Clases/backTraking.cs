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
        private List<region> regSolucion = new List<region>();

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
                    int[] solved = new int[4];
                    solved[0] = reg.getResultado();
                    reg.soluciones.Add(solved);
                }
                else
                {
                    int[] solucion = new int[4];
                    backTrack(reg, solucion, 0);
                    //imprime(reg);
                }
            }
            int[,] mPrueba = new int[tam, tam];
            //resuelveBT(mPrueba, regList, 0);
        }

        private void imprime(region reg) //imprime todas las soluciones posibles de una region
        {
            Console.WriteLine("Cantidad de soluciones: " + reg.soluciones.Count);
            foreach (int[] obj in reg.soluciones)
            {
                Console.WriteLine("Solución para " + reg.getOperador() + " " + reg.getResultado() + ":");
                Console.WriteLine(obj[0] + ", " + obj[1] + ", " + obj[2] + ", " + obj[3] + ".");
            }
        }

        private void backTrack(region reg, int[] sol, int pos)
        {
            for(int i = 1; i <= tam; i++)
            {
                if (i >= reg.getResultado())
                {
                    break;
                }
                else if (pos == 3)
                {
                    int[] newSolution = new int[4];
                    sol[pos] = i;
                    int res = 0;
                    if (reg.getOperador() == '+')
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            res += sol[j];
                            newSolution[j] = sol[j];
                        }
                        //Console.WriteLine("Operador +; res = " + res + ", RES " + reg.getResultado());
                    }
                    else if (reg.getOperador() == 'X')
                    {
                        res = 1;
                        for (int j = 0; j < 4; j++)
                        {
                            res = res * sol[j];
                            newSolution[j] = sol[j];
                        }
                        //Console.WriteLine("Operador X; res = " + res + ", RES " + reg.getResultado());
                    }
                    if (reg.getResultado() == res)
                    {
                        //Console.WriteLine("Check");
                        //for(int x = 0; x < 4; x++)
                        //{
                        //    Console.Write(newSolution[x] + ", ");
                        //}
                        reg.soluciones.Add(newSolution);
                        break;
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
                        //Console.WriteLine("pos = " + pos + ", i = " + i);
                        sol[pos] = i;
                        backTrack(reg, sol, (pos+1));
                    }
                }
            }
        }

        private Boolean resuelveBT(int[,] mPrueba, List<region> regList, int pos)
        {
            region reg = regList[pos];
            int next = 0;
            for(int i = 0; i < reg.soluciones.Count; i++)
            {
                foreach (Coords cord in reg.getPieza())
                {
                    if(cord != null)
                    {
                        mPrueba[cord.getX(), cord.getY()] = reg.soluciones[i][next];
                        if(!checker(mPrueba, cord))
                        {
                            break;
                        }
                    }
                }
                if(resuelveBT(mPrueba, regList, (pos + 1)))
                {
                    return true;
                }
            }
            return true;
        }

        private Boolean checker(int[,] mPrueba, Coords cord)
        {
            for(int i = 0; i < tam; i++)
            {
                if (i == cord.getX())
                    continue;
                if(mPrueba[i,cord.getY()] != null)
                {
                    if (mPrueba[i, cord.getY()] == mPrueba[cord.getX(), cord.getY()])
                        return false;
                }
            }
            for (int i = 0; i < tam; i++)
            {
                if (i == cord.getY())
                    continue;
                if (mPrueba[cord.getX(), i] != null)
                {
                    if (mPrueba[cord.getX(), i] == mPrueba[cord.getX(), cord.getY()])
                        return false;
                }
            }
            return true;
        }

    }
}
