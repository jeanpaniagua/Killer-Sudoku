using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku
{
    class Coords
    {

        private int x;
        private int y;
        private int valor;

        public Coords(int x, int y){

            this.x = x;
            this.y = y;

        }

        public void setValor(int val)
        {
            valor = val;
        }

        public int getValor()
        {
            return valor;
        }

        public int getX(){
            return x;
        }

        public int getY(){
            return y;
        }

    }
}
