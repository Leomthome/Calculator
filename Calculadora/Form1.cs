using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Calculadora
{
    public partial class Calculadora : Form
    {
        int operacao, virgula, n;
        double fat1, fat2, result, numNovo, numAntigo;
        bool apagadinho;

        public Calculadora()
        {
            InitializeComponent();
        }

        private void Botao(object sender, EventArgs e)
        {
            if (apagadinho)
            {
                Resultado.Text = "";
                apagadinho = false;
            }

                Button digito = sender as Button;
                Resultado.Text += digito.Text;
        }

        private void Soma(object sender, EventArgs e)
        {
            operacao = 1;
            fat1 = Convert.ToDouble(Resultado.Text);
            Resultado.Text = "";
            virgula = 0;
        }

        private void sub(object sender, EventArgs e)
        {
            operacao = 2;
            fat1 = Convert.ToDouble(Resultado.Text);
            Resultado.Text = "";
            virgula = 0;

        }

        private void mult(object sender, EventArgs e)
        {
            operacao = 3;
            fat1 = Convert.ToDouble(Resultado.Text);
            Resultado.Text = "";
            virgula = 0;
        }

        private void div(object sender, EventArgs e)
        {
            operacao = 4;
            fat1 = Convert.ToDouble(Resultado.Text);
            Resultado.Text = "";
            virgula = 0;
        }

        private void Resto(object sender, EventArgs e)
        {
            operacao = 5;
            fat1 = Convert.ToDouble(Resultado.Text);
            Resultado.Text = "";
            virgula = 0;
        }
        private void Pot(object sender, EventArgs e)
        {
            operacao = 6;
            fat1 = Convert.ToDouble(Resultado.Text);
            Resultado.Text = "";
            virgula = 0;
        }
        private void sin(object sender, EventArgs e)
        {
            operacao = 7;
            fat1 = Convert.ToDouble(Resultado.Text);
            virgula = 0;
            apagadinho = true;

            result = Math.Sin(fat1);

            Resultado.Text = Convert.ToString(result);
        }
        private void cos(object sender, EventArgs e)
        {
            operacao = 8;
            fat1 = Convert.ToDouble(Resultado.Text);
            virgula = 0;
            apagadinho = true;

            result = Math.Cos(fat1);

            Resultado.Text = Convert.ToString(result);
        }
        private void tg(object sender, EventArgs e)
        {
            operacao = 9;
            fat1 = Convert.ToDouble(Resultado.Text);
            virgula = 0;
            apagadinho = true;

            result = Math.Tan(fat1);

            Resultado.Text = Convert.ToString(result);
        }
        private void raiz(object sender, EventArgs e)
        {
            operacao = 10;
            fat1 = Convert.ToDouble(Resultado.Text);
            Resultado.Text = "";
            virgula = 0;
        }
        private void Porcento(object sender, EventArgs e)
        {
            operacao = 12;
            fat1 = Convert.ToDouble(Resultado.Text);
            Resultado.Text = "";
            virgula = 0;
        }
        private void C(object sender, EventArgs e)
        {
            Resultado.Text = null;
            operacao = 0;
            virgula = 0;
        }
        private void CE(object sender, EventArgs e)
        {
            Resultado.Text = null;  
        }

        private void Back(object sender, EventArgs e)
        {
            int tamanho = Resultado.Text.Length - 1;
            if (tamanho >= 0)
            {
                Resultado.Text = Resultado.Text.Substring(0, tamanho);
            }
        }
        private void Virgula(object sender, EventArgs e)
        {
            if (virgula == 0)
            {
                Button virg = sender as Button;
                Resultado.Text += virg.Text;
                virgula = 1;
            }
        }
        private void igual(object sender, EventArgs e)
        {
            fat2 = Convert.ToDouble(Resultado.Text);
            apagadinho = true;
            virgula = 0;

            if(operacao == 1){
                result = fat1 + fat2;
            }
            else if (operacao == 2){
                result = fat1 - fat2;
            }
            else if (operacao == 3)
            {
                result = fat1 * fat2;
            }
            else if (operacao == 4)
            {
                result = fat1 / fat2;
            }
            else if (operacao == 5)
            {
                result = fat1 % fat2;
            }
            else if (operacao == 6)
            {
                result = Math.Pow(fat1, fat2);
            }
            else if (operacao == 10)
            {
                result = Math.Pow(fat1, 1 / fat2);
            }
            else if (operacao == 12)
            {
                result = fat1 * fat2 / 100;
            } 
            Resultado.Text = Convert.ToString(result);
        }

        private void Iterativo_bt(object sender, EventArgs e)
        {
            result = iterativo_fact(Double.Parse(Resultado.Text));
            Resultado.Text = Convert.ToString(result);
        }

        private void recursivo_bt(object sender, EventArgs e)
        {
            result = recursivo_fact(Double.Parse(Resultado.Text));
            Resultado.Text = Convert.ToString(result);
        }

        private double iterativo_fact(double value)
        {
            double num = value;
            for (double i = num - 1; i > 1; i--)
            {
                num *= i;
            }
            //Debug.Print(Convert.ToString(num));
            return num;

        }

        //Recursivo Fatorial
        private double recursivo_fact(double value)
        {
            double num = value;
            if (num <= 1) return num = 1;
            return num = num * recursivo_fact(num - 1);
        }

        //Iterativa Fibonacci
        private void Iterativa_bt(object sender, EventArgs e)
        {
            if (Resultado.Text != "")
            {
                result = iterativa_fibo(Double.Parse(Resultado.Text));
                Resultado.Text = Convert.ToString(result);
            }
            else MessageBox.Show("Adicione algum valor, por favor.");
        }

        //Iterativa Fibonacci
        private double iterativa_fibo(double value)
        {
            if (value <= 2)
                return 1;

            double p = 1, s = 1;

            for (double i = 2; i < value; i++)
            {
                double temp = p + s;
                p = s;
                s = temp;
            }

            return s;

        }

        //bt_Recursiva Fibonacci
        private void Recursiva_fibo(object sender, EventArgs e)
        {
            result = Recursiva_fibo(Double.Parse(Resultado.Text));
            Resultado.Text = Convert.ToString(result);
        } 


        //Recursiva Fibonacci
        private double Recursiva_fibo(double x)
        {
            if (x <= 2)
            {
                return 1;
            }
            return Recursiva_fibo(x - 1) + Recursiva_fibo(x - 2);
        }  
    } 
}
