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
        public FormTablero()
        {
            InitializeComponent();
            cargarMatriz();
        }

        /*private void cargarCoordenadas()
        {
            byte tamanhoTablero = Program.tamanho;

            generarTablero table = new generarTablero(tamanhoTablero);

            Program.casillas = new casilla[tamanhoTablero, tamanhoTablero];

            byte cont = 0;

            foreach (region reg in table.tablero.regiones)
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
                            cont++;
                        }
                    }
                }
            }
            cargarMatriz();
        }*/
     

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


            for (int i = 0; i < tamanhoTablero; i++)
            {
                for (int j = 0; j < tamanhoTablero; j++)
                {
                    if (Program.casillas[i, j] != null)
                    {
                        var panel = new FlowLayoutPanel();
                        panel.Width = tamanhoCelda;
                        panel.Height = tamanhoCelda;

                        panel.BackColor = Program.casillas[i, j].getColor();

                        var label = new Label();

                        if(Program.casillas[i, j].getResultado() > 0)
                        {
                            label.Name = Program.casillas[i, j].getResultado().ToString();
                            label.Text = Program.casillas[i, j].getOperador() + " " + Program.casillas[i, j].getResultado().ToString();
                        }

                        panel.Controls.Add(label);

                        var label2 = new Label();

                        if (Program.casillas[i, j].getValor() > 0)
                        {
                            label2.Name = Program.casillas[i, j].getValor().ToString();
                            label2.Text = Program.casillas[i, j].getValor().ToString();
                        }

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
