using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Kepler_tryhard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double mu = Convert.ToDouble(textBox1.Text);
            double a = Convert.ToDouble(textBox2.Text);
            double exs = Convert.ToDouble(textBox3.Text);
            int tp = Convert.ToInt32(textBox4.Text);
            int t = Convert.ToInt32(textBox5.Text);

            double p = a * (1 - exs * exs);
            double PI = 3.14159265;

            double[] M = new double[t - tp+1];
            double[] E = new double[t - tp+1];
            double[] teta = new double[t - tp+1];
            double[] radius = new double[t - tp+1];

            System.IO.StreamWriter textFile = new System.IO.StreamWriter("text.txt");
            textFile.WriteLine("Средняя аномалия");
            for (int i = 0; i<=t-tp; i++)
            {
                M[i] = (Math.Sqrt(mu / (a * a * a)))*(i+tp);
                textFile.WriteLine("M["+i+"] = " + M[i]);
            }

            textFile.WriteLine(" ");
            textFile.WriteLine("Эксцентрическая аномалия");
            E[0] = M[0];
            textFile.WriteLine("E[0] = " + E[0]);
            for (int i = 1; i <= t - tp; i++)
            {
                E[i] = M[i] + exs * Math.Sin(E[i - 1]*PI/180);
                textFile.WriteLine("E[" + i + "] = " + E[i]);
            }

            textFile.WriteLine(" ");
            textFile.WriteLine("Истинная аномалия(Teta)");
            for (int i = 0; i <= t-tp; i++)
            {
                teta[i] = 2 * Math.Atan((Math.Sqrt((1 + exs) / (1 - exs)) * Math.Tan(E[i]/2))*PI/180);
                textFile.WriteLine("teta[" + i + "] = " + teta[i]);
            }

            textFile.WriteLine(" ");
            textFile.WriteLine("Радиус вектор");
            for (int i = 0; i <= t - tp; i++)
            {
                radius[i] = a * (1 - exs * Math.Cos(E[i] * PI / 180));
                textFile.WriteLine("radius[" + i + "] = " + radius[i]);
            }

                textFile.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Displays an OpenFileDialog so the user can select a Cursor.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Cursor Files|*.txt";
            openFileDialog1.Title = "Select a Cursor File";

            // Show the Dialog.
            // If the user clicked OK in the dialog and
            // a .CUR file was selected, open it.
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Assign the cursor in the Stream to the Form's Cursor property.
                this.Cursor = new Cursor(openFileDialog1.OpenFile());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}