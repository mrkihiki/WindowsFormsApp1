using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void рассчитатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                float A = float.Parse(textBox1.Text);
                float B = float.Parse(textBox2.Text);
                float E = float.Parse(textBox3.Text);
                string F = textBox4.Text;
                Function f = new Function(F);

                dichotomy(A, B, E, f);
            }
            catch (Exception)
            {
                label1.Text = "Содержит недопустимые символы";
            }

        }
        private void dichotomy(float A, float B, float E, Function f)
        {
            chart1.Series[0].Points.Clear();
            for (float i = A; i <= B; i+=1)
            {
              
                chart1.Series[0].Points.AddXY((i), f.calculate(i));
            }
            if (A < B)
            {
                float soj;
                    soj=(A + B) / 2;
                float r;
                while ((B-A) > E )
                {
                    soj = (A + B) / 2;
                     r = 0.01f*(B-A);
                    if (f.calculate(soj - r) > f.calculate(soj + r))
                    {
                        A = soj - r;
                    }
                    else
                    {
                        B = soj + r;
                    }
                }
                chart1.Series[1].Points.AddXY((soj), f.calculate(soj));
                label1.Text = "x= " + soj + " F(x)= " + f.calculate(soj); // вывод результатов 
            }
            else
            {
                MessageBox.Show("Введите корректные значения", "Ошибка ввода!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }


        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "f(x)=";
            label1.Text = "";
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
        }
    }
}
