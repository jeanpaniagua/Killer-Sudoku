using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku
{
    class tablero
    {
        private byte tamanho;
        //private casilla[,] tableroMatriz;
        public List<region> regiones = new List<region>();

        public tablero(byte tamanho)
        {
            this.tamanho = tamanho;
            //tableroMatriz = new casilla[tamanho,tamanho];
        }

    }
}
