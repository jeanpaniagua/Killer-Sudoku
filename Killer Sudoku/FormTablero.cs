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

        private void cargarMatriz()
        {
            byte tamanhoTablero = Program.tamanho;

            TableLayoutPanel tablero = new TableLayoutPanel();

            tablero.RowCount = tamanhoTablero;
            tablero.ColumnCount = tamanhoTablero;

            tablero.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            byte tamanhoCelda = (byte)((800 - 7* tamanhoTablero) / tamanhoTablero);

            tablePanel.Controls.Add(tablero, 1,0);

            generarTablero table = new generarTablero(Program.tamanho);

            TableLayoutPanel[] tableroCeldas = new TableLayoutPanel[tamanhoTablero * tamanhoTablero];


            foreach(region reg in table.tablero.regiones)
            {
                if (reg != null)
                {
                    foreach (Coords cord in reg.getPieza())
                    {
                        if (cord != null)
                        {
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
            }

            //for (int i = 0; i < tamanhoTablero; i++)
            //{
            //    for (int j = 0; j < tamanhoTablero; j++)
            //    {

            //        var panel = new FlowLayoutPanel();
            //        panel.Width = tamanhoCelda;
            //        panel.Height = tamanhoCelda;
            //        panel.BackColor = Color.GreenYellow;

            //        var label = new Label();

            //        label.Name = "" + i + "";
            //        label.Text = "" + i + "";

            //        panel.Controls.Add(label);

            //        var label2 = new Label();

            //        label2.Name = "" + j + "";
            //        label2.Text = "" + j + "";

            //        panel.Controls.Add(label2);

            //        tablero.Controls.Add(panel, j, i);

            //    }

            //    tablero.Dock = System.Windows.Forms.DockStyle.Fill;
             
            //}

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormTablero_Load(object sender, EventArgs e)
        {

        }
    }
}
