using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku
{
    class casilla
    {
        private byte valor;
        private String color;
        private String operador;
        private Coords posicion;
        
        public casilla(byte valor, region region)
        {
            this.valor = valor;
        }

        public void setValor(byte valor)
        {
            this.valor = valor;
        }

        public byte getValor()
        {
            return valor;
        }

        public void setOperador(String operador)
        {
            this.color = operador;
        }

        public String getOperador()
        {
            return operador;
        }

        public void setColor(String color)
        {
            this.color = color;
        }

        public String getColor()
        {
            return color;
        }
    }
}
