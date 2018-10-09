using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku
{
    class generarTablero
    {
        public tablero tablero;
        private Boolean[,] disponibles;
        private int regs = 0;
        private static Random aleatorio = new Random();

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
            Console.WriteLine("Total: " + c);
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
                        int figura = aleatorio.Next(1, 9);
                        Console.WriteLine("Va a crear pieza #" + figura);
                        creaRegiones(tamanho, fila, columna, figura, 0);
                    }
                }
            }
        }

        private void creaRegiones(byte tamanho, int fila, int columna, int  figura, byte rot)
        {
            Console.WriteLine("Entra pieza #" + figura);
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
                }
            }
            if (!pasa)
            {
                if (rot < 4)
                {
                    Console.WriteLine("No pasa. Entra ROT.");
                    creaRegiones(tamanho, fila, columna, figura, (byte)(rot + 1));
                }
                else
                {
                    Random rnd = new Random();
                    int next= aleatorio.Next(1, 9);
                    Console.WriteLine("No pasa. Entra Nueva Fig #" + next);
                    creaRegiones(tamanho, fila, columna, next, 0);
                }
            }
            else if(pasa)
            {
                foreach (Coords cord in region.getPieza())
                {
                    if (cord != null)
                    {
                        Console.WriteLine("PASA!!");
                        Console.WriteLine("X: " + cord.getX() + " Y: " + cord.getY());
                        disponibles[cord.getX(), cord.getY()] = false;
                        tablero.regiones[regs] = region;
                        regs++;
                    }
                }
            }
            //for(int i = 0; i < tamanho; i++)
            //{
            //    for(int j = 0; j < tamanho; j++)
            //    {
            //        Console.Write(disponibles[i,j] + "");
            //    }
            //    Console.WriteLine("");
            //}
        }
    }

}
