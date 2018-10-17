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
        private static char[] operadores = { '+', '*'};
        private static Random aleatorio = new Random();


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
                case '*':
                    return valor1 * valor2 * valor3 * valor4;
                default:
                    return 0;
            }
        }

        public void start()
        {
            generarTablero table = new generarTablero(tamanho);

            Program.casillas = new casilla[tamanho, tamanho];

            foreach (region reg in Program.tablero.regiones)
            {
                if (reg != null)
                {
                    char op = operadores[aleatorio.Next(0, 2)];
                    reg.setOperador(op);
                    reg.setResultado(this.resultado(aleatorio.Next(1, 19), aleatorio.Next(1, 19), aleatorio.Next(1, 19), aleatorio.Next(1, 19), op));
                    Console.WriteLine();
                    Console.WriteLine(op);
                    Console.WriteLine(reg.getResultado());

                    foreach (Coords cord in reg.getPieza())
                    {
                        if (cord != null)
                        {
                            Program.casillas[cord.getX(), cord.getY()] = new casilla(0);
                            Program.casillas[cord.getX(), cord.getY()].setColor(reg.getColor());
                        }
                    }
                    Program.casillas[reg.getPieza()[0].getX(), reg.getPieza()[0].getY()].setOperador(Convert.ToString(reg.getOperador()));
                    Program.casillas[reg.getPieza()[0].getX(), reg.getPieza()[0].getY()].setResultado(reg.getResultado());
                }
            }
            //Generar sudoku
        }
    }
}