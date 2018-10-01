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
    public partial class Interfaz : Form
    {

        private void cargarInferfaz()
        {
            TableLayoutPanel rowLayout = new TableLayoutPanel();

            rowLayout.RowCount = 10;
            rowLayout.ColumnCount = 10;

            tableTablero.Controls.Add(rowLayout, 1, 1);



            rowLayout.Dock = System.Windows.Forms.DockStyle.Fill;

            int count = 1;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                
                    var button = new Button();
                    button.Size = new Size(50, 50);
                    button.Name = "" + count + "";
                    button.Text = "" + count + "";
                    rowLayout.Controls.Add(button, j, i);

                    count++;
                }
            }

        }
        public Interfaz()
        {
            InitializeComponent();
            cargarInferfaz();
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
    }
}
