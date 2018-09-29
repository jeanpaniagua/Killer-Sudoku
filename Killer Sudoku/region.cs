using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku
{
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
    class region
    {
        private byte pieza;
        private byte posicion;
        private char operador;
        private int resultado;
        private casilla[] zona;

        public region(byte pieza)
        {
            this.pieza = pieza;
            if (pieza != 8)
            {
                zona = new casilla[4];
            }
            else
            {
                zona = new casilla[1];
            }
            posicion = 0;
            operador = '+';
            resultado = 0;
        }

        public byte getPieza()
        {
            return pieza;
        }

        public void girar()
        {
            if (posicion < 3)
            {
                posicion++;
            }
            else
            {
                posicion = 0;
            }
        }

        public byte getPosicion()
        {
            return posicion;
        }

        public void setOperador(char operador)
        {
            this.operador = operador;
        }

        public char getOperador()
        {
            return operador;
        }

        public void setPosZona(byte numero, byte i)
        {
            this.zona[i].setValor(numero);
        }

        public void setZona(casilla[] zona)
        {
            this.zona = zona;
        }

        public casilla[] getZona()
        {
            return zona;
        }
    }
}
