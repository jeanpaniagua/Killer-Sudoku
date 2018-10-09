using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku
{
    class Piezas
    {

        private Coords[] pieza;

        public Piezas(int p, int x, int y, byte r)
        {
            this.pieza = crearPieza(p, x, y, r);
        }

        public Coords[] getPieza()
        {
            return this.pieza;
        }
        private Coords[] crearPieza(int p, int x, int y, byte r)
        {
            Coords[] pieza = new Coords[4];
            switch (p){
                case 1: // Pieza L
                    switch (r){
                        case 0: // Base abajo.
                            pieza[0] = new Coords(x, y);
                            pieza[1] = new Coords(x + 1, y);
                            pieza[2] = new Coords(x + 2, y);
                            pieza[3] = new Coords(x + 2, y + 1);
                            break;
                        case 1: // Base izq.
                            pieza[0] = new Coords(x, y);
                            pieza[1] = new Coords(x + 1, y);
                            pieza[2] = new Coords(x, y + 1);
                            pieza[3] = new Coords(x, y + 2);
                            break;
                        case 2: // Base arriba.
                            pieza[0] = new Coords(x, y);
                            pieza[1] = new Coords(x, y + 1);
                            pieza[2] = new Coords(x + 1, y + 1);
                            pieza[3] = new Coords(x + 2, y + 1);
                            break;
                        case 3: // Base der.
                            pieza[0] = new Coords(x, y);
                            pieza[1] = new Coords(x, y + 1);
                            pieza[2] = new Coords(x, y + 2);
                            pieza[3] = new Coords(x - 1, y + 2);
                            break;
                    }
                    break;
                case 2: // Pieza L invertida
                    switch (r)
                    {
                        case 0: // Base abajo.
                            pieza[0] = new Coords(x, y);
                            pieza[1] = new Coords(x + 1, y);
                            pieza[2] = new Coords(x + 2, y);
                            pieza[3] = new Coords(x + 2, y - 1);
                            break;
                        case 1: // Base izq.
                            pieza[0] = new Coords(x, y);
                            pieza[1] = new Coords(x + 1, y);
                            pieza[2] = new Coords(x + 1, y + 1);
                            pieza[3] = new Coords(x + 1, y + 2);
                            break;
                        case 2: // Base arriba.
                            pieza[0] = new Coords(x, y);
                            pieza[1] = new Coords(x, y + 1);
                            pieza[2] = new Coords(x + 1, y);
                            pieza[3] = new Coords(x + 2, y);
                            break;
                        case 3: // Base der.
                            pieza[0] = new Coords(x, y);
                            pieza[1] = new Coords(x, y + 1);
                            pieza[2] = new Coords(x, y + 2);
                            pieza[3] = new Coords(x + 1, y + 2);
                            break;
                    }
                    break;
                case 3: // Pieza T
                    switch (r)
                    {
                        case 0: // Base abajo.
                            pieza[0] = new Coords(x, y);
                            pieza[1] = new Coords(x, y + 1);
                            pieza[2] = new Coords(x, y + 2);
                            pieza[3] = new Coords(x - 1, y + 1);
                            break;
                        case 1: // Base izq.
                            pieza[0] = new Coords(x, y);
                            pieza[1] = new Coords(x + 1, y);
                            pieza[2] = new Coords(x + 2, y);
                            pieza[3] = new Coords(x + 1, y + 1);
                            break;
                        case 2: // Base arriba.
                            pieza[0] = new Coords(x, y);
                            pieza[1] = new Coords(x, y + 1);
                            pieza[2] = new Coords(x, y + 2);
                            pieza[3] = new Coords(x + 1, y + 1);
                            break;
                        case 3: // Base der.
                            pieza[0] = new Coords(x, y);
                            pieza[1] = new Coords(x + 1, y);
                            pieza[2] = new Coords(x + 2, y);
                            pieza[3] = new Coords(x + 1, y - 1);
                            break;
                    }
                    break;
                case 4: // Pieza S
                    switch (r)
                    {
                        case 0: // Lado.
                            pieza[0] = new Coords(x, y);
                            pieza[1] = new Coords(x, y + 1);
                            pieza[2] = new Coords(x + 1, y);
                            pieza[3] = new Coords(x + 1, y - 1);
                            break;
                        case 1: // Arriba.
                            pieza[0] = new Coords(x, y);
                            pieza[1] = new Coords(x + 1, y);
                            pieza[2] = new Coords(x + 1, y + 1);
                            pieza[3] = new Coords(x + 2, y + 1);
                            break;
                        case 2: // Lado.
                            pieza[0] = new Coords(x, y);
                            pieza[1] = new Coords(x, y + 1);
                            pieza[2] = new Coords(x + 1, y);
                            pieza[3] = new Coords(x + 1, y - 1);
                            break;
                        case 3: // Arriba.
                            pieza[0] = new Coords(x, y);
                            pieza[1] = new Coords(x + 1, y);
                            pieza[2] = new Coords(x + 1, y + 1);
                            pieza[3] = new Coords(x + 2, y + 1);
                            break;
                    }
                    break;
                case 5: // Pieza Z
                    switch (r)
                    {
                        case 0: // Lado.
                            pieza[0] = new Coords(x, y);
                            pieza[1] = new Coords(x, y + 1);
                            pieza[2] = new Coords(x + 1, y + 1);
                            pieza[3] = new Coords(x + 1, y + 2);
                            break;
                        case 1: // Arriba.
                            pieza[0] = new Coords(x, y);
                            pieza[1] = new Coords(x + 1, y);
                            pieza[2] = new Coords(x + 1, y - 1);
                            pieza[3] = new Coords(x + 2, y - 1);
                            break;
                        case 2: // Lado.
                            pieza[0] = new Coords(x, y);
                            pieza[1] = new Coords(x, y + 1);
                            pieza[2] = new Coords(x + 1, y + 1);
                            pieza[3] = new Coords(x + 1, y + 2);
                            break;
                        case 3: // Arriba.
                            pieza[0] = new Coords(x, y);
                            pieza[1] = new Coords(x + 1, y);
                            pieza[2] = new Coords(x + 1, y - 1);
                            pieza[3] = new Coords(x + 2, y - 1);
                            break;
                    }
                    break;
                case 6: // Pieza |
                    switch (r)
                    {
                        case 0: // Lado.
                            pieza[0] = new Coords(x, y);
                            pieza[1] = new Coords(x + 1, y);
                            pieza[2] = new Coords(x + 2, y);
                            pieza[3] = new Coords(x + 3, y);
                            break;
                        case 1: // Arriba.
                            pieza[0] = new Coords(x, y);
                            pieza[1] = new Coords(x, y + 1);
                            pieza[2] = new Coords(x, y + 2);
                            pieza[3] = new Coords(x, y + 3);
                            break;
                        case 2: // Lado.
                            pieza[0] = new Coords(x, y);
                            pieza[1] = new Coords(x + 1, y);
                            pieza[2] = new Coords(x + 2, y);
                            pieza[3] = new Coords(x + 3, y);
                            break;
                        case 3: // Arriba.
                            pieza[0] = new Coords(x, y);
                            pieza[1] = new Coords(x, y + 1);
                            pieza[2] = new Coords(x, y + 2);
                            pieza[3] = new Coords(x, y + 3);
                            break;
                    }
                    break;
                case 7: // Pieza Cuadro
                    pieza[0] = new Coords(x, y);
                    pieza[1] = new Coords(x, y + 1);
                    pieza[2] = new Coords(x + 1, y);
                    pieza[3] = new Coords(x + 1, y + 1);
                    break;
                case 8: // Pieza Singular
                    pieza[0] = new Coords(x, y);
                    break;
            }
            return pieza;
        }

    }
}
