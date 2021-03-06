﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Killer_Sudoku
{
    class generarTablero
    {
        
        private Boolean[,] disponibles;
        private int regs = 0;
        private static Random aleatorio = new Random();
        private List<int> omitir;

        public generarTablero(byte tamanho)
        {
            Program.tablero = new tablero(tamanho);
            disponibles = new Boolean[tamanho, tamanho];
            llenaDisponibles(tamanho);
            cargarRegiones(tamanho);
        }

        private void cuenta()
        {
            int c = 0;
            foreach(region reg in Program.tablero.regiones)
            {
                if (reg != null)
                {
                    foreach (Coords co in reg.getPieza())
                    {
                        c++;
                    }
                }
            }
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
                if (rot < 3)
                {
                    creaRegiones(tamanho, fila, columna, figura, (byte)(rot + 1));
                }
                else if (rot >= 3)
                {
                    omitir.Add(figura);
                    int next = buscar(omitir);
                    //Console.WriteLine(next);
                    creaRegiones(tamanho, fila, columna, next, 0);
                }
            }
            else if(pasa)
            {
                Program.tablero.regiones.Add(region);
                foreach (Coords cord in region.getPieza())
                {
                    if (cord != null)
                    {
                        disponibles[cord.getX(), cord.getY()] = false;   
                    }
                }
            }
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
