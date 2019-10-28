using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;

namespace Formulario
{
    public partial class MinimosCuadrados : Form
    {
        public MinimosCuadrados(DatosParametros datos)
        {
            InitializeComponent();
        }
        private bool VerificarDatosMetodo(List<TextBox> lista)
        {
            bool variable = true;

            foreach (var item in lista)
            {
                if (item.Text == "")
                {
                    variable = false;
                }
            }
            return variable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "")
            {
                int numero = Convert.ToInt32(this.textBox1.Text);

                int num = numero;
                int pointx = 40;
                int pointy = 10;
                this.panel1.Controls.Clear();
                for (int j = 0; j < 2; j++)
                {
                    for (int i = 0; i < num; i++)
                    {
                        TextBox nuevo = new TextBox();
                        nuevo.Name = Convert.ToString((i + 1) + (j + 1));
                        nuevo.Size = new Size(41, 20);
                        nuevo.Location = new Point(pointx, pointy);
                        panel1.Controls.Add(nuevo);
                        pointx += 50;
                    }
                    pointx = 40;
                    pointy += 30;
                }               
                pointx = 10;
                pointy = 15;
                Label nuevo2 = new Label();
                nuevo2.Text = "X:";
                nuevo2.Width = 20;
                nuevo2.Location = new Point(pointx, pointy);
                panel1.Controls.Add(nuevo2);
                pointx = 10;
                pointy = 45;
                Label nuevo3 = new Label();
                nuevo3.Text = "Y:";
                nuevo3.Width = 20;
                nuevo3.Location = new Point(pointx, pointy);
                panel1.Controls.Add(nuevo3);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool band = true;

            int numero = Convert.ToInt32(this.textBox1.Text);

            double[] vecx = new double[numero];
            double[] vecy = new double[numero];

            List<TextBox> lista = panel1.Controls.OfType<TextBox>().ToList();

            if (VerificarDatosMetodo(lista) == true)
            {
                for (int i = 0; i < numero; i++)
                {
                    vecx[i] = Convert.ToDouble(lista.ElementAt(i).Text);
                }
                int c = 0;
                int n = numero * 2;
                for (int j = numero; j < n; j++)
                {
                    vecy[c] = Convert.ToDouble(lista.ElementAt(j).Text);
                    c++;
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos");

                band = false;
            }
            if (band == true)
            {
                DatosParametros datos = new DatosParametros();

                datos.NumPares = numero;
                datos.X = vecx;
                datos.Y = vecy;

                ResultadoRegresion NuevoResultado = new ResultadoRegresion();

                FormularioPrincipal formularioprincipal = this.Owner as FormularioPrincipal;
                if (formularioprincipal != null)
                {
                    NuevoResultado = formularioprincipal.MinimosCuadrados(datos);

                    string variable = "";

                    variable = Convert.ToString("EFECTIVIDAD: " + NuevoResultado.Efectividad + "     ORDENADA ORIGEN: " + NuevoResultado.OrdenadaOrigen + "     PENDIENTE: " + NuevoResultado.Pendiente);

                    MessageBox.Show(variable);
                }
            }
        }
    }
}