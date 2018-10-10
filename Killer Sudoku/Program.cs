using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Killer_Sudoku
{
    static class Program
    {
        public static byte tamanho = 0;
        public static casilla[,] casillas;
        public static tablero tablero;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Interfaz());
        }


        public static void guardarTablero()
        {
            Random rnd = new Random();
            int name = rnd.Next(9999, 999999999);
            
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("tableros\\" + tamanho + "x" + tamanho + "-"+  name + ".txt");

                //Write a line of text
                sw.WriteLine(tamanho);

                foreach (region reg in Program.tablero.regiones)
                {
                    String linea = reg.getOperador().ToString() + "," + reg.getResultado().ToString();

                    if (reg != null)
                    {
                        foreach (Coords cord in reg.getPieza())
                        {
                            if (cord != null)
                            {
                                linea = linea + "," + cord.getX().ToString() + "," + cord.getY().ToString();
                            }
                        }
                    }
                    sw.WriteLine(linea);
                }

                    //Close the file
                    sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

        }

        public static void cargarTablero(String name)
        {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(name);

                //Read the first line of text
                line = sr.ReadLine();

                tamanho = System.Text.Encoding.ASCII.GetBytes(line)[0];

                tablero = new tablero(tamanho);

                //Continue to read until you reach end of file
                while (line != null)
                {
                    //Read the next line
                    line = sr.ReadLine();

                    //write the lie to console window
                    //Console.WriteLine(line);
                    if(line != null)
                    {
                        String[] region = line.Split(',');

                        char operador = region[0][0];

                        int resultado = Int32.Parse(region[1]);

                        Coords[] coordenadas = new Coords[4];

                        byte cont = 0;

                        for (byte i = 0; i < region.Length; i += 2)
                        {
                            if (i > 1)
                            {
                                Console.WriteLine(i + " x: " + Int32.Parse(region[i]) + " y: " + Int32.Parse(region[i + 1]));
                                coordenadas[cont] = new Coords(Int32.Parse(region[i]), Int32.Parse(region[i + 1]));

                                cont++;
                            }
                        }

                        region pieza = new region(operador, resultado, coordenadas);

                        tablero.regiones.Add(pieza);
                        Console.WriteLine("Región creada");
                    }
                }

                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            //generarTablero table = new generarTablero(tamanho);

            Program.casillas = new casilla[tamanho, tamanho];

            foreach (region reg in Program.tablero.regiones)
            {
                if (reg != null)
                {
                    foreach (Coords cord in reg.getPieza())
                    {
                        if (cord != null)
                        {
                            Program.casillas[cord.getX(), cord.getY()] = new casilla(0);
                            Program.casillas[cord.getX(), cord.getY()].setColor(reg.getColor());
                            Program.casillas[cord.getX(), cord.getY()].setOperador(" ");
                        }
                    }
                }
            }
        }

    }
}
