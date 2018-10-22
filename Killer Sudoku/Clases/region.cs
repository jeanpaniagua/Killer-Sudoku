using System;
using System.Collections;
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
        private static Random aleatorio = new Random();
        public List<int[]> soluciones = new List<int[]>();

        public region(int checker, Coords pos, byte rot)
        {
            pieza = new Piezas(checker, pos.getX(), pos.getY(), rot).getPieza();
            operador = '+';
            resultado = 0;
            color = Color.FromArgb(aleatorio.Next(100, 255), aleatorio.Next(100, 255), aleatorio.Next(100, 255));
        }
        public region(char operador, int resultado, Coords[] pieza)
        {
            this.pieza = pieza;
            this.operador = operador;
            this.resultado = resultado;
            color = Color.FromArgb(aleatorio.Next(100, 255), aleatorio.Next(100, 255), aleatorio.Next(100, 255));
        }

        public Coords[] getPieza()
        {
            return this.pieza;
        } 

        public Color getColor()
        {
            return color;
        }
        
        public void setColor(Color color)
        {
            this.color = color;
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
