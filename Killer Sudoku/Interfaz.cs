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

            String value = comboBox1.Text;

            switch (value)
            {
                case "5x5":
                    Program.tamanho = 5;
                    break;
                case "6x6":
                    Program.tamanho = 6;
                    break;
                case "7x7":
                    Program.tamanho = 7;
                    break;
                case "8x8":
                    Program.tamanho = 8;
                    break;
                case "9x9":
                    Program.tamanho = 9;
                    break;
                case "10x10":
                    Program.tamanho = 10;
                    break;
                case "11x11":
                    Program.tamanho = 11;
                    break;
                case "12x12":
                    Program.tamanho = 12;
                    break;
                case "13x13":
                    Program.tamanho = 13;
                    break;
                case "14x14":
                    Program.tamanho = 14;
                    break;
                case "15x15":
                    Program.tamanho = 15;
                    break;
                case "16x16":
                    Program.tamanho = 16;
                    break;
                case "17x17":
                    Program.tamanho = 17;
                    break;
                case "18x18":
                    Program.tamanho = 18;
                    break;
                case "19x19":
                    Program.tamanho = 19;
                    break;
                default:
                    Console.WriteLine("Debe seleccionar un valor");
                    break;
            }

            killerSudoku sudoku = new killerSudoku(Program.tamanho);

            sudoku.start();


            FormTablero pTablero = new FormTablero();
            pTablero.Show();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }
    }
}
