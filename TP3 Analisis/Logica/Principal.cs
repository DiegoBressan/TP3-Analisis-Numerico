using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Principal
    {
        public ResultadosCalcular Calcular(DatosParametros Datos)
        {
            ResultadosCalcular resultados = new ResultadosCalcular();

            for (int i = 0; i < Datos.NumPares; i++)
            {
                resultados.SumaX = resultados.SumaX + Datos.X[i];
                resultados.SumaY = resultados.SumaY + Datos.Y[i];

                resultados.SumaXporY = resultados.SumaXporY + (Datos.X[i] * Datos.Y[i]);

                resultados.SumaXCuadrados = resultados.SumaXCuadrados + (Math.Pow(Datos.X[i], 2));
            }

            resultados.PromedioX = resultados.SumaX / Datos.NumPares;
            resultados.PromedioY = resultados.SumaY / Datos.NumPares;

            return resultados;
        }

        private double CalcularR(DatosParametros datos, ResultadosCalcular calculo, ResultadoRegresion regresion, double[] lista)
        {
            double st = 0;

            double sr = 0;
            double r = 0;

            foreach (var item in datos.Y)
            {
                double aux = calculo.PromedioY - item;
                st = st + Math.Pow(aux, 2);
            }

            //MINIMOS CUADRADOS
            /*  
            for (int i = 0; i < datos.NumPares; i++)
            {
                double aux2 = (regresion.Pendiente + datos.X[i]) - regresion.OrdenadaOrigen - datos.Y[i];
                sr = sr + Math.Pow(aux2, 2);
            }
            */

            double acu = 0;
            for (int i = 0; i < datos.NumPares; i++)
            {
                int potencia = 0;
                foreach (var item in lista)
                {
                    acu = acu - item * Math.Pow(datos.X[i], potencia);
                    potencia++;
                }
                sr = sr + Math.Pow((datos.Y[i] + acu), 2);
                acu = 0;
            }

            r = Math.Sqrt((st - sr) / st) * 100;


            return r;
        }

        //GAUSS-JORDAN
        public double[] ObtenerGaussJordan(double[,] matrizcargada, int grado)
        {
            double[] Resultado = new double[grado];
            double coeficiente = 0;

            for (int x = 0; x <= grado - 1; x++)
            {
                coeficiente = matrizcargada[x, x];

                for (int y = 0; y <= grado; y++)
                {
                    matrizcargada[x, y] = matrizcargada[x, y] / coeficiente;
                }

                for (int z = 0; z <= grado - 1; z++)
                {
                    if (x != z)
                    {
                        coeficiente = matrizcargada[z, x];

                        for (int t = 0; t <= grado; t++)
                        {
                            matrizcargada[z, t] = matrizcargada[z, t] - (coeficiente * matrizcargada[x, t]);
                        }
                    }
                }
            }

            for (int i = 0; i < grado; i++)
            {
                Resultado[i] = matrizcargada[i, grado];
            }

            return Resultado;
        }

        //MINIMOS CUADRADOS
        public ResultadoRegresion MinimosCuadrados(DatosParametros Datos)
        {
            ResultadoRegresion Resultados = new ResultadoRegresion();
            ResultadosCalcular Calculo = Calcular(Datos);

            double Nominador = (Datos.NumPares * Calculo.SumaXporY) - (Calculo.SumaX * Calculo.SumaY);

            double Denominador = (Datos.NumPares * Calculo.SumaXCuadrados) - Math.Pow(Calculo.SumaX, 2);

            Resultados.Pendiente = Nominador / Denominador;
            Resultados.OrdenadaOrigen = Calculo.PromedioY - (Resultados.Pendiente * Calculo.PromedioX);

            double[] lista = new double[5];

            Resultados.Efectividad = CalcularR(Datos, Calculo, Resultados, lista);

            return Resultados;
        }
        //MINIMOS CUADRADOS POLINOMIO
        public ResultadoRegresion MinimosCuadradosPolinomio(DatosParametros Datos)
        {
            ResultadoRegresion resultado = new ResultadoRegresion();
            ResultadosCalcular Calculo = Calcular(Datos);
            double[,] Matriz = new double[Datos.Grado,Datos.Grado];

            for (int i = 0; i < Datos.NumPares -1; i++)
            {
                for (int z = 0; z < Datos.Grado; z++)
                {
                    for (int t = 0; t < Datos.Grado; t++)
                    {
                        Matriz[z, t] = Math.Pow(Datos.X[i], t + z);
                    }
                    Matriz[z, Datos.Grado + 1] = Datos.Y[i] * Math.Pow(Datos.X[i], z);
                }
            }

            double[] Resultados = ObtenerGaussJordan(Matriz, Datos.Grado + 1);

            double r = CalcularR(Datos, Calculo, resultado, Resultados);

            return resultado;
        }

        //LAGRANJE
    }
}