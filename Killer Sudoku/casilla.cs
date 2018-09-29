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
        private region region;

        public casilla(byte valor, region region)
        {
            this.valor = valor;
            this.region = region;
        }

        public void setValor(byte valor)
        {
            this.valor = valor;
        }

        public byte getValor()
        {
            return valor;
        }

        public void setRegion(region region)
        {
            this.region = region;
        }

        public region getRegion()
        {
            return region;
        }
    }
}
