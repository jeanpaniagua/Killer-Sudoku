using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku
{
    class killerSudoku
    {
        private byte tamanho;

        public killerSudoku(byte tamanho)
        {
            this.tamanho = tamanho;
        }

        public void start()
        { 
            generarTablero table = new generarTablero(tamanho);

            Program.casillas = new casilla[tamanho, tamanho];

            foreach (region reg in Program.tablero.regiones)
            {
                if (reg != null)
                {
                    foreach (Coords cord in reg.getPieza())
                    {
                        if (cord != null)
                        {
                            Program.casillas[cord.getX(), cord.getY()] = new casilla(0);
                            Program.casillas[cord.getX(), cord.getY()].setColor(reg.getColor());
                            Program.casillas[cord.getX(), cord.getY()].setOperador(" ");
                        }
                    }
                }
            }

            //Generar sudoku
        }
    }
}
