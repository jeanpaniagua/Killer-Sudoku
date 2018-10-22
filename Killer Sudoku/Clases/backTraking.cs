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

        public void resuelveReg(region[] regList)
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
                    solucion = backTrack(reg, solucion, 0);
                }
            }
        }

        public int[] backTrack(region reg, int[] sol, int pos)
        {
            Boolean success = false; 
            for(int i = 1; i < tam; i++)
            {
                if(i > reg.getResultado())
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
                    }
                    else if (reg.getOperador() == 'X')
                    {
                        res = 1;
                        for (int j = 0; j < 4; j++)
                        {
                            res = res * sol[j];
                        }
                    }
                    if (reg.getResultado() == res)
                    {
                        success = true;
                        break;
                    }
                    else
                    {
                        if (reg.getResultado() < res)
                        {
                            break;
                        }
                    }
                }
            }
            if (success)
                return sol;
            else
                return null;
        }

    }
}
