using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku
{
    class region
    {
        private Coords[] pieza;
        private char operador;
        private int resultado;
        private Color color;

        public region(int checker, Coords pos, byte rot)
        {
            pieza = new Piezas(checker, pos.getX(), pos.getY(), rot).getPieza();
            operador = '+';
            resultado = 0;
            Random r = new Random();
            color = Color.FromArgb(r.Next(0, 256),r.Next(0, 256), r.Next(0, 256));
        }

        public Coords[] getPieza()
        {
            return this.pieza;
        } 

        public Color getColor()
        {
            return color;
        }

        public void setOperador(char operador)
        {
            this.operador = operador;
        }

        public char getOperador()
        {
            return operador;
        }

        public void setResultado(int resultado)
        {
            this.resultado = resultado;
        }

        public int getResultado()
        {
            return resultado;
        }
    }
}
