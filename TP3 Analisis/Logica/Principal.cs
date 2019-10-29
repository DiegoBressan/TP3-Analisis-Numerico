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
                double aux2 = (regresion.Pendiente * datos.X[i]) + regresion.OrdenadaOrigen - datos.Y[i];
                sr = sr + Math.Pow(aux2, 2);
            }*/

            //MINIMOS CUADRADOS POLINIMIO
            
            double acu = 0;
            for (int i = 0; i < datos.NumPares; i++)
            {
                int potencia = 0;
                for (int z = 0; z < datos.Grado; z++)
                {
                    acu = acu + (lista[z] * Math.Pow(datos.X[i], z));
                    potencia+= 1;
                }

                sr = sr + Math.Pow((acu - datos.Y[i]), 2);
                acu = 0;
            }
            r = Math.Sqrt(Math.Abs(st - sr) / st) * 100;

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

                for (int z = 0; z <= grado; z++)
                {
                   if (z < grado)
                   {
                        coeficiente = matrizcargada[x, z];

                        for (int t = 0; t <= grado -1 ; t++)
                        {
                            if (t != x)
                            {
                                matrizcargada[t, z] = matrizcargada[t, z] - (coeficiente * matrizcargada[t, x]);
                            }
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
        public ResultadoRegresionPolinomio MinimosCuadradosPolinomio(DatosParametros Datos)
        {
            ResultadoRegresionPolinomio Resultado = new ResultadoRegresionPolinomio();
            ResultadoRegresion resulta = new ResultadoRegresion();
            ResultadosCalcular Calculo = Calcular(Datos);
            double[,] Matriz = new double[Datos.Grado, Datos.NumPares];

            for (int i = 0; i < Datos.NumPares - 1; i++)
            {
                for (int z = 0; z < Datos.Grado; z++)
                {
                    for (int t = 0; t < Datos.Grado; t++)
                    {
                        Matriz[z, t] += Math.Pow(Datos.X[i], t + z);
                    }
                    Matriz[z, Datos.NumPares-1] += Datos.Y[i] * Math.Pow(Datos.X[i], z);
                }
            }
            Resultado.ResultadosX = ObtenerGaussJordan(Matriz, Datos.Grado);

            Resultado.Efectividad = CalcularR(Datos, Calculo, resulta, Resultado.ResultadosX);

            return Resultado;
        }

        //LAGRANJE
        public ResultadoLagranje InterpolacionPolinomioLagranje(DatosParametros Datos, double ValorX)
        {
            ResultadoLagranje Resultado = new ResultadoLagranje();
            double[] ResultadosP = new double[Datos.NumPares];

            for (int z = 0; z < Datos.NumPares; z++)
            {
                double Nominadores = 1;
                double Denominador = 1;

                for (int i = 0; i < Datos.NumPares; i++)
                {
                    if (i != z)
                    {
                        Nominadores = Nominadores * (ValorX - Datos.X[i]);
                        Denominador = Denominador * (Datos.X[z] - Datos.X[i]);
                    }
                }

                Resultado.Interpolacion += Datos.Y[z] * (Nominadores / Denominador);
            }
            return Resultado;
        }
    }
}