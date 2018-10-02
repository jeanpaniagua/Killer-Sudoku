using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Killer_Sudoku
{
    public partial class Interfaz : Form
    {

        private void cargarMatriz()
        {
            byte tamanhoTablero = 19;

            TableLayoutPanel rowLayout = new TableLayoutPanel();

            rowLayout.RowCount = tamanhoTablero;
            rowLayout.ColumnCount = tamanhoTablero;

            rowLayout.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            //850 para 5x5 770 par 19x19
            byte tamanhoCelda = (byte)(850 / tamanhoTablero);

           this.Invoke((MethodInvoker)delegate ()
            {
                tableTablero.Controls.Add(rowLayout, 1, 1);
            });

            int count = 0;

            TableLayoutPanel[] tableroCeldas = new TableLayoutPanel[tamanhoTablero* tamanhoTablero];

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

                    this.Invoke((MethodInvoker)delegate ()
                    {
                        rowLayout.Controls.Add(panel, j, i);
                    });



                }
                this.Invoke((MethodInvoker)delegate ()
                {
                    rowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
                });
            }

        }
        public Interfaz()
        {
            InitializeComponent();

        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void label1_Click_3(object sender, EventArgs e)
        {

        }

        private void flpTablero_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        { 
            
        }

        private void tableTablero_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Thread matriz = new Thread(cargarMatriz);
            matriz.Start();
            //cargarMatriz();
         
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click_4(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
