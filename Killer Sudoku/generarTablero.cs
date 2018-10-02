using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku
{
    class generarTablero
    {
        private tablero tablero;
        /* Piezas válidas
        * 1)
        * -
        * -
        * -
        * -
        * 
        * 2) 
        * -
        * -
        * - -
        * 
        * 3)
        *   -
        *   -
        * - -
        * 
        * 4)
        * - -
        * - -
        * 
        * 5)
        *  - -
        * - -
        * 
        * 6)
        * 
        * - -
        *   - -
        * 
        * 7)
        * 
        *   -
        * - - -
        * 
        * 8
        * 
        * -
        * 
        * ----------------------------------------------------------------------------
        * Un 0 en posición significa que la pieza no tiene ninguna rotación
        * Un 1 significa una rotación en sentido del reloj, así sucesivamente hasta 3.
        * 
        * ----------------------------------------------------------------------------
        * Por default el operador es una suma.
        */

        public generarTablero(byte tamanho)
        {
            tablero = new tablero(tamanho);
            cargarRegiones(tamanho);
        }

        private void cargarRegiones(byte tamanho)
        {
            byte fila = 0;
            byte columna = 0;
            Boolean completo = false;
            while (!completo)
            {
                Random rnd = new Random();
                byte next = (byte)rnd.Next(1, 8);
                region region = new region(next);
                //if(tablero.getCasilla(fila,columna));

            }
        }


    }
}
