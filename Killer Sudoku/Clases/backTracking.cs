﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku
{
    class backTracking
    {
        private byte tam;
        
        private int[,] mPrueba;

        public backTracking(byte tamanho)
        {
            this.tam = tamanho;
            this.mPrueba = new int[tamanho, tamanho];
        }

        public void resuelveReg(List<region> regList)
        {
            foreach (region reg in regList)
            {
                if (reg.getPieza()[1] == null)
                {
                    Program.pistas.Add(reg);
                }
                else
                {
                    int[] solucion = new int[4];
                    backTrack(reg, solucion, 0);
                    //imprime(reg);
                }
            }

            foreach (region reg in Program.pistas)
            {
                regList.Remove(reg); //Elimina las pistas de la lista de regiones
            }

            agregaPistas();
            if(resuelveBT(regList, 0))
            {
                Console.WriteLine("Resuelto:");
                aux();
            }
            else
            {
                Console.WriteLine("Sorry mae, le fallé....");
            }
        }

        private void imprime(region reg) //imprime todas las soluciones posibles de una region
        {
            Console.WriteLine("Cantidad de soluciones: " + reg.soluciones.Count);
            foreach (int[] obj in reg.soluciones)
            {
                Console.WriteLine("Solución para " + reg.getOperador() + " " + reg.getResultado() + ":");
                Console.WriteLine(obj[0] + ", " + obj[1] + ", " + obj[2] + ", " + obj[3] + ".");
            }
        }

        private Boolean checkPiezas(int p, int r, int[] sol)
        {
            switch (p)
            {
                case 1: // Pieza L
                    switch (r)
                    {
                        case 0: // Base abajo.
                            if (sol[0] == sol[1] || sol[0] == sol[2] || sol[1] == sol[2] || sol[2] == sol[3])
                                return false;
                            return true;
                        case 1: // Base izq.
                            if (sol[0] == sol[1] || sol[0] == sol[2] || sol[0] == sol[3] || sol[2] == sol[3])
                                return false;
                            return true;
                        case 2: // Base arriba.
                            if (sol[0] == sol[1] || sol[1] == sol[2] || sol[1] == sol[3] || sol[2] == sol[3])
                                return false;
                            return true;
                        case 3: // Base der.
                            if (sol[0] == sol[1] || sol[0] == sol[2] || sol[1] == sol[2] || sol[2] == sol[3])
                                return false;
                            return true;
                    }
                    break;
                case 2: // Pieza L invertida
                    switch (r)
                    {
                        case 0: // Base abajo.
                            if (sol[0] == sol[1] || sol[0] == sol[2] || sol[1] == sol[2] || sol[2] == sol[3])
                                return false;
                            return true;
                        case 1: // Base izq.
                            if (sol[0] == sol[1] || sol[1] == sol[2] || sol[1] == sol[3] || sol[2] == sol[3])
                                return false;
                            return true;
                        case 2: // Base arriba.
                            if (sol[0] == sol[1] || sol[0] == sol[2] || sol[0] == sol[3] || sol[2] == sol[3])
                                return false;
                            return true;
                        case 3: // Base der.
                            if (sol[0] == sol[1] || sol[0] == sol[2] || sol[1] == sol[2] || sol[2] == sol[3])
                                return false;
                            return true;
                    }
                    break;
                case 3: // Pieza T
                    if (sol[0] == sol[1] || sol[0] == sol[2] || sol[1] == sol[2] || sol[3] == sol[1])
                        return false;
                    return true;
                case 4: // Pieza S
                    switch (r)
                    {
                        case 0: // Lado.
                            if (sol[0] == sol[1] || sol[0] == sol[2] || sol[2] == sol[3])
                                return false;
                            return true;
                        case 1: // Arriba.
                            if (sol[0] == sol[1] || sol[1] == sol[2] || sol[2] == sol[3])
                                return false;
                            return true;
                        case 2: // Lado.
                            if (sol[0] == sol[1] || sol[0] == sol[2] || sol[2] == sol[3])
                                return false;
                            return true;
                        case 3: // Arriba.
                            if (sol[0] == sol[1] || sol[1] == sol[2] || sol[2] == sol[3])
                                return false;
                            return true;
                    }
                    break;
                case 5: // Pieza Z
                    if (sol[0] == sol[1] || sol[1] == sol[2] || sol[2] == sol[3])
                        return false;
                    return true;
                case 6: // Pieza |
                    if (sol[0] == sol[1] || sol[0] == sol[2] || sol[0] == sol[3] || sol[1] == sol[2] || sol[1] == sol[3] || sol[2] == sol[3])
                        return false;
                    return true;
                case 7: // Pieza Cuadro
                    if (sol[0] == sol[1] || sol[0] == sol[2] || sol[1] == sol[3] || sol[2] == sol[3])
                        return false;
                    return true;
            }
            return true;
        }

        private void backTrack(region reg, int[] sol, int pos)
        {
            for(int i = 1; i <= tam; i++)
            {
                if (i >= reg.getResultado())
                {
                    break;
                }
                else if (pos == 3)
                {
                    sol[pos] = i;
                    if (checkPiezas(reg.tPieza, reg.tRot, sol))
                    {
                        int[] newSolution = new int[4];
                        int res = 0;
                        if (reg.getOperador() == '+')
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                res += sol[j];
                                newSolution[j] = sol[j];
                            }
                        }
                        else if (reg.getOperador() == 'X')
                        {
                            res = 1;
                            for (int j = 0; j < 4; j++)
                            {
                                res = res * sol[j];
                                newSolution[j] = sol[j];
                            }
                        }
                        if (reg.getResultado() == res)
                        {
                            reg.soluciones.Add(newSolution);
                            break;
                        }
                        else if (reg.getResultado() < res)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    if (pos < 3)
                    {
                        sol[pos] = i;
                        backTrack(reg, sol, (pos+1));
                    }
                }
            }
        }

        private void agregaPistas()
        {
            foreach(region reg in Program.pistas)
            {
                mPrueba[reg.getPieza()[0].getX(), reg.getPieza()[0].getY()] = reg.getResultado();
            }
        }

        private void aux()
        {
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
                {
                    if (Program.casillas[i, j] == null)
                    {
                        Program.casillas[i, j] = new casilla((byte)mPrueba[i, j]);
                    }
                    else
                    {
                        Program.casillas[i, j].setValor((byte)mPrueba[i, j]);
                    }
                    
                    Console.Write(mPrueba[i, j] + " ");
                }
                Console.WriteLine("");
            }
        }

        private void cleaner(Coords[] pieza)
        {
            foreach (Coords clean in pieza)
            {
                mPrueba[clean.getX(), clean.getY()] = 0;
            }
        }

        private Boolean llenarRegion(int[] solucion, Coords[] cord)
        {
            int next = 0;
            foreach (Coords cords in cord)
            {
                mPrueba[cords.getX(), cords.getY()] = solucion[next];
                if (!checker(cords))
                {
                    cleaner(cord);
                    return false;
                }
                next = next + 1;
            }
            return true;
        }

        private Boolean resuelveBT(List<region> regList, int pos)
        {
            region reg = regList[pos];
            int x = 0;
            foreach(int[] solucion in reg.soluciones)
            {
                //Console.WriteLine("En la pos " + pos + " con solucion #" + x + " de " + reg.soluciones.Count);
                if (llenarRegion(solucion, reg.getPieza()))
                {
                    if (pos < (regList.Count-1))
                    {
                        if (resuelveBT(regList, (pos + 1)))
                        {
                            return true;
                        }
                        else
                        {
                            cleaner(reg.getPieza());
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
                x = x + 1;
            }
            return false;
        }

        private Boolean checker(Coords cord)
        {
            for(int i = 0; i < tam; i++)
            {
                if (i == cord.getX())
                    continue;
                if(mPrueba[i,cord.getY()] != 0)
                {
                    if (mPrueba[i, cord.getY()] == mPrueba[cord.getX(), cord.getY()])
                        return false;
                }
            }
            for (int i = 0; i < tam; i++)
            {
                if (i == cord.getY())
                    continue;
                if (mPrueba[cord.getX(), i] != 0)
                {
                    if (mPrueba[cord.getX(), i] == mPrueba[cord.getX(), cord.getY()])
                        return false;
                }
            }
            return true;
        }

    }
}
