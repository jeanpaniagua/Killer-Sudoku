using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Killer_Sudoku
{
    class generarTablero
    {
        public tablero tablero;
        private Boolean[,] disponibles;
        private int regs = 0;
        private static Random aleatorio = new Random();
        private List<int> omitir;

        public generarTablero(byte tamanho)
        {
            tablero = new tablero(tamanho);
            disponibles = new Boolean[tamanho, tamanho];
            llenaDisponibles(tamanho);
            cargarRegiones(tamanho);
            //cuenta();
        }

        private void cuenta()
        {
            int c = 0;
            foreach(region reg in tablero.regiones)
            {
                if (reg != null)
                {
                    foreach (Coords co in reg.getPieza())
                    {
                        c++;
                    }
                }
            }
            //Console.WriteLine("Total: " + c);
        }

        private void llenaDisponibles(byte tamanho)
        {
            for(int fila = 0; fila < tamanho; fila++)
            {
                for(int columna = 0; columna < tamanho; columna++)
                {
                    disponibles[fila, columna] = true;
                }
            }
        }

        private void cargarRegiones(byte tamanho)
        {
            for (int fila = 0; fila < tamanho; fila++)
            {
                for (int columna = 0; columna < tamanho; columna++)
                {
                    if (disponibles[fila, columna] == true)
                    {
                        omitir = new List<int>();
                        int figura = aleatorio.Next(1, 8);
                        creaRegiones(tamanho, fila, columna, figura, 0);
                    }
                }
            }
        }

        private void creaRegiones(byte tamanho, int fila, int columna, int  figura, byte rot)
        {
            //Console.WriteLine("Entra pieza #" + figura);
            region region = new region(figura, new Coords(fila, columna), rot);
            Boolean pasa = true;
            foreach (Coords cord in region.getPieza())
            {
                if (cord != null)
                {
                    if (cord.getX() < 0 || cord.getY() < 0 || cord.getX() >= tamanho || cord.getY() >= tamanho)
                    {
                        pasa = false;
                    }
                    else if (!(disponibles[cord.getX(), cord.getY()]))
                    {
                        pasa = false;
                    }
                    /*else
                    { 
                        pasa = true;
                    }*/
                }
            }
            if (!pasa)
            {
                Console.WriteLine("No pasa, rot: " + rot);
                if (rot < 3)
                {
                    creaRegiones(tamanho, fila, columna, figura, (byte)(rot + 1));
                }
                else if (rot >= 3)
                {
                    omitir.Add(figura);
                    int next = buscar(omitir);
                    Console.WriteLine(next);
                    creaRegiones(tamanho, fila, columna, next, 0);
                }
            }
            else if(pasa)
            {
                //Console.WriteLine(figura);
                tablero.regiones.Add(region);
                foreach (Coords cord in region.getPieza())
                {
                    if (cord != null)
                    {
                        //Console.WriteLine("Coordenada X: " + cord.getX() + " Y: " + cord.getY());
                        disponibles[cord.getX(), cord.getY()] = false;   
                    }
                }
            }
           /* else
            {
                omitir.Add(figura);
                int next = buscar(omitir);
                creaRegiones(tamanho, fila, columna, next, 0);
            }*/
        }
        private int buscar(List<int> lista)
        {
            Random rnd = new Random();

            int next = aleatorio.Next(1, 8);

            return buscarAux(lista, next);
        }


        private int buscarAux(List<int> lista, int num)
        {
            if (lista.Count() == 7)
            {
                return 8;
            }
            else if (lista.Any(x => x == num))
            {
                int next = aleatorio.Next(1, 8);

                return buscarAux(lista, next);
            }
            
            else
            {
                return num;
            }
        }
    }


}
