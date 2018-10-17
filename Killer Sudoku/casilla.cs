using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Killer_Sudoku
{
    class casilla
    {
        private byte valor;
        private int resultado;
        private Color color;
        private String operador;

        public casilla(byte valor)
        {
            this.valor = valor;
        }

        public void setValor(byte valor)
        {
            this.valor = valor;
        }

        public void setResultado(int resultado)
        {
            this.resultado = resultado;
        }

        public int getResultado()
        {
            return resultado;
        }

        public byte getValor()
        {
            return valor;
        }

        public void setOperador(String operador)
        {
            this.operador = operador;
        }

        public String getOperador()
        {
            return operador;
        }

        public void setColor(Color color)
        {
            this.color = color;
        }

        public Color getColor()
        {
            return color;
        }
    }
}
