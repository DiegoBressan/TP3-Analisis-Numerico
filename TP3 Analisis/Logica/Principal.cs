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

            resultados.PromedioX = resultados.PromedioX / Datos.NumPares;
            resultados.PromedioY = resultados.PromedioY / Datos.NumPares;

            return resultados;
        }

        public ResultadoRegresion MinimosCuadrados(DatosParametros Datos)
        {
            ResultadoRegresion Resultados = new ResultadoRegresion();

            ResultadosCalcular Calculo = Calcular(Datos);

            double deltaA1 = (Datos.NumPares * Calculo.SumaXporY) - (Calculo.SumaX * Calculo.SumaY);

            double delta = (Datos.NumPares * Calculo.SumaXCuadrados) - (Calculo.SumaX * Calculo.SumaY);

            Resultados.Pendiente = deltaA1 / delta;
            Resultados.OrdenadaOrigen = Calculo.PromedioY - (Resultados.Pendiente * Calculo.PromedioX);

            return Resultados;
        }


    }
}