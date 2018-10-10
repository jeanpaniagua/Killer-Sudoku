using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Killer_Sudoku
{
    public partial class FormTablero : Form
    {
        private casilla[,] casillas;


        public FormTablero()
        {
            InitializeComponent();
            cargarCoordenadas();
        }

        private void cargarCoordenadas()
        {
            byte tamanhoTablero = Program.tamanho;

            generarTablero table = new generarTablero(tamanhoTablero);

            casillas = new casilla[tamanhoTablero, tamanhoTablero];

            byte cont = 0;

            foreach (region reg in table.tablero.regiones)
            {
                if (reg != null)
                {
                    foreach (Coords cord in reg.getPieza())
                    {
                        if (cord != null)
                        {
                            casillas[cord.getX(), cord.getY()] = new casilla(cont);
                            casillas[cord.getX(), cord.getY()].setColor(reg.getColor());
                            casillas[cord.getX(), cord.getY()].setOperador("+");
                            cont++;
                            //Console.WriteLine();
                        }
                    }
                }
                
                //Console.WriteLine(cont);
            }
            cargarMatriz();
        }



        private void cargarMatriz()
        {
            byte tamanhoTablero = Program.tamanho;

            TableLayoutPanel tablero = new TableLayoutPanel();

            tablero.RowCount = tamanhoTablero;
            tablero.ColumnCount = tamanhoTablero;

            tablero.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            byte tamanhoCelda = (byte)((800 - 7* tamanhoTablero) / tamanhoTablero);

            tablePanel.Controls.Add(tablero, 1,0);

           
            TableLayoutPanel[] tableroCeldas = new TableLayoutPanel[tamanhoTablero * tamanhoTablero];


            /*foreach(region reg in table.tablero.regiones)
            {
                if (reg != null)
                {
                    foreach (Coords cord in reg.getPieza())
                    {
                        if (cord != null)
                        {
                            Console.WriteLine("X: " + cord.getX()  + " Y: " + cord.getY());
                            var panel = new FlowLayoutPanel();
                            panel.Width = tamanhoCelda;
                            panel.Height = tamanhoCelda;
                            panel.BackColor = reg.getColor();

                            var label = new Label();

                            label.Name = "" + cord.getX() + "";
                            label.Text = "" + cord.getX() + "";

                            panel.Controls.Add(label);

                            var label2 = new Label();

                            label2.Name = "" + cord.getY() + "";
                            label2.Text = "" + cord.getY() + "";

                            panel.Controls.Add(label2);

                            tablero.Controls.Add(panel, cord.getY(), cord.getX());
                        }
                    }
                }
                tablero.Dock = System.Windows.Forms.DockStyle.Fill;
            }*/

            for (int i = 0; i < tamanhoTablero; i++)
            {
                for (int j = 0; j < tamanhoTablero; j++)
                {
                    //Console.WriteLine(casillas[i, j].getValor());

                    if (casillas[i, j] != null)
                    {
                        var panel = new FlowLayoutPanel();
                        panel.Width = tamanhoCelda;
                        panel.Height = tamanhoCelda;

                        panel.BackColor = casillas[i, j].getColor();

                        var label = new Label();

                        label.Name = casillas[i, j].getOperador();
                        label.Text = casillas[i, j].getOperador();

                        panel.Controls.Add(label);

                        var label2 = new Label();

                        label2.Name = casillas[i, j].getValor().ToString();
                        label2.Text = casillas[i, j].getValor().ToString();

                        panel.Controls.Add(label2);

                        tablero.Controls.Add(panel, j, i);
                    }
                }

                tablero.Dock = System.Windows.Forms.DockStyle.Fill;

            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormTablero_Load(object sender, EventArgs e)
        {

        }

        private void tablePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
