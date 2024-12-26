using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace nonlinearEquations
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = -1;
            try
            {
                a = Convert.ToDouble(textBox3.Text);
            }
            catch
            {
                MessageBox.Show("Input a", "Worning");
                return;
            }
            double b = 1;
            try
            {
                b = Convert.ToDouble(textBox4.Text);
            }
            catch
            {
                MessageBox.Show("Input b", "Worning");
                return;
            }
            double eps = 0;
            try
            {
                eps = Convert.ToDouble(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Input infelicity", "Worning");
                return;
            }
            f func;
            double res;
            if (radioButton1.Checked)
            {
                func = f1;
                res = DichotomyMethod(a, b, func, eps);
            }
            else if (radioButton2.Checked)
            {
                func = f2;
                res = DichotomyMethod(a, b, func, eps);
            }
            else if (radioButton3.Checked)
            {
                func = f3;
                res = DichotomyMethod(a, b, func, eps);
            }
            else
            {
                MessageBox.Show("Check function", "Worning");
                return;
            }
            textBox2.Text = Convert.ToString(res);
        }
        public double DichotomyMethod(double a, double b, f func, double eps)
        {
            double x = (b+a)/2;
            if(func(x) == 0)
            {
                return x;
            }
            else if(func(a) == 0)
            {
                return a;
            }
            else if (func(b) == 0)
            {
                return b;
            }
            if (func(a)*func(x) < 0)
            {
                b=x;
            }
            else if(func(x)*func(b) < 0)
            {
                a=x;
            }
            else
            {
                a /= 2;
                b /= 2;
            }
            if(Math.Abs(func(x)) < eps)
            {
                return x;
            }
            else
            {
                return DichotomyMethod(a, b, func, eps);
            }
        }
        public double ChordMethod(double x1, double x0, double h, f func)
        {
            if(x1 == x0)
            {
                return x1;
            }
            return x1 - func(x1)*(x1-x0)/(func(x1)-func(x0));
        }
        public delegate double f(double x);
        public double f1(double x)
        {
            return x*x*x + 4*x*x - 19*x + 14;
        }
        public double f2(double x)
        {
            return x*x + x - 12;
        }
        public double f3(double x)
        {
            return 2*x+1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox3.Text = "-10";
            textBox4.Text = "10";
            textBox1.Text = "0,001";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double a = -1;
            try
            {
                a = Convert.ToDouble(textBox3.Text);
            }
            catch
            {
                MessageBox.Show("Input a", "Worning");
                return;
            }
            double b = 1;
            try
            {
                b = Convert.ToDouble(textBox4.Text);
            }
            catch
            {
                MessageBox.Show("Input b", "Worning");
                return;
            }
            double eps = 0;
            try
            {
                eps = Convert.ToDouble(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Input infelicity", "Worning");
                return;
            }
            f func;
            double h = 0.0001;
            double x0;
            double xNext = b;
            if (radioButton1.Checked)
            {
                func = f1;
            }
            else if (radioButton2.Checked)
            {
                func = f2;
            }
            else if (radioButton3.Checked)
            {
                func = f3;
            }
            else
            {
                MessageBox.Show("Check function", "Worning");
                return;
            }
            do
            {
                x0 = xNext;
                xNext = ChordMethod(xNext, a, h, func);
            } while (Math.Abs(xNext - x0) >= eps);
            textBox2.Text = Convert.ToString(xNext);
        }
        private void radioButton1_MouseDown(object sender, MouseEventArgs e)
        {
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }

        private void radioButton2_MouseDown(object sender, MouseEventArgs e)
        {
            radioButton1.Checked = false;
            radioButton3.Checked = false;
        }

        private void radioButton3_MouseDown(object sender, MouseEventArgs e)
        {
            radioButton2.Checked = false;
            radioButton1.Checked = false;
        }
    }
}
