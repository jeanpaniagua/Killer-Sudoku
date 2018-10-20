using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku
{
    class killerSudoku
    {
        private byte tamanho;
        private static char[] operadores = { '+', 'X' };
        private static Random aleatorio = new Random();
        private static byte[,] matrizAleatoria;
  


        public killerSudoku(byte tamanho)
        {
            this.tamanho = tamanho;
        }

        public int resultado(int valor1, int valor2, int valor3, int valor4, char op)
        {
            switch (op)
            {
                case '+':
                    return valor1 + valor2 + valor3 + valor4;
                case 'X':
                    return valor1 * valor2 * valor3 * valor4;
                default:
                    return 0;
            }
        }

        private List<byte> llenarLista()
        {
            List<byte> lista = new List<byte>();
            for(byte i = 0; i < tamanho; i++)
            {
                lista.Add(i);
            }
            return lista;
        }

        private void llenarFila(byte fila, byte contador)
        {
            for (byte columna = 0; columna < tamanho; columna++)
            {
                matrizAleatoria[fila, columna] = contador;
                if (contador == tamanho)
                {
                    contador = 1;
                }
                else
                {
                    contador++;
                }
            }
        }

        private void llenarColumnas(byte columna, byte siguiente)
        {
            for (byte fila = 0; fila < tamanho; fila++)
            {
                Program.casillas[fila, siguiente] = new casilla(matrizAleatoria[fila, columna]);
            }
        }



        private void llenarMatriz()
        {
            matrizAleatoria = new byte[tamanho, tamanho];

            List<byte> disponible = llenarLista();

            byte contador = 1;
            for (byte fila = 0; fila < tamanho; fila++)
            {
                byte siguiente = disponible[(byte)aleatorio.Next(0, disponible.Count)];
                llenarFila(siguiente, contador);
                disponible.Remove(siguiente);
                contador++;
            }

            disponible = llenarLista();

            byte[,] matrizResultado = new byte[tamanho, tamanho];

            for (byte columna = 0; columna < tamanho; columna++)
            {
                byte siguiente = disponible[(byte)aleatorio.Next(0, disponible.Count)];
                llenarColumnas(columna, siguiente);
                disponible.Remove(siguiente);
            }
        }



        public void start()
        {
            generarTablero table = new generarTablero(tamanho);

            Program.casillas = new casilla[tamanho, tamanho];

            List<byte> disponible = llenarLista();

            llenarMatriz();


            foreach (region reg in Program.tablero.regiones)
            {
                if (reg != null)
                {
                    if (reg.getPieza()[1] != null)
                    {
                        char op = operadores[aleatorio.Next(0, 2)];
                        reg.setOperador(op);
                        reg.setResultado(resultado(Program.casillas[reg.getPieza()[0].getX(), reg.getPieza()[0].getY()].getValor(), Program.casillas[reg.getPieza()[1].getX(), reg.getPieza()[1].getY()].getValor(),
                            Program.casillas[reg.getPieza()[2].getX(), reg.getPieza()[2].getY()].getValor(), Program.casillas[reg.getPieza()[3].getX(), reg.getPieza()[3].getY()].getValor(), op));
                        foreach (Coords cord in reg.getPieza())
                        {
                            if (cord != null)
                            {
                                Program.casillas[cord.getX(), cord.getY()].setValor(0);
                                Program.casillas[cord.getX(), cord.getY()].setColor(reg.getColor());
                            }
                        }
                    }
                    else
                    {
                        foreach (Coords cord in reg.getPieza())
                        {
                            if (cord != null)
                            {
                                Program.casillas[cord.getX(), cord.getY()].setColor(reg.getColor());
                            }
                        }
                    }

                    Program.casillas[reg.getPieza()[0].getX(), reg.getPieza()[0].getY()].setOperador(Convert.ToString(reg.getOperador()));
                    Program.casillas[reg.getPieza()[0].getX(), reg.getPieza()[0].getY()].setResultado(reg.getResultado());
                }
            }
        }
    }
}