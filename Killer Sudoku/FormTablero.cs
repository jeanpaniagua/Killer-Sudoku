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



            int count = 0;

            TableLayoutPanel[] tableroCeldas = new TableLayoutPanel[tamanhoTablero * tamanhoTablero];

            for (int i = 0; i < tamanhoTablero; i++)
            {
                for (int j = 0; j < tamanhoTablero; j++)
                {
                    count++;

                    var panel = new FlowLayoutPanel();
                    panel.Width = tamanhoCelda;
                    panel.Height = tamanhoCelda;
                    panel.BackColor = Color.GreenYellow;

                    var label = new Label();

                    label.Name = "" + count + "";
                    label.Text = "" + count + "";

                    panel.Controls.Add(label);

                    var label2 = new Label();

                    label2.Name = "" + count + "";
                    label2.Text = "2_" + count + "";

                    panel.Controls.Add(label2);

                    tablero.Controls.Add(panel, j, i);


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
    }
}
