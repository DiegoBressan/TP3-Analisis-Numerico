using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Principal
    {
        public ResultadosCalcular Calcular(int[] vecx, int[] vecy, int c)
        {
            ResultadosCalcular resultados = new ResultadosCalcular();

            for (int i = 0; i < c; i++)
            {
                resultados.SumaX = resultados.SumaX + vecx[i];
                resultados.SumaY = resultados.SumaY + vecy[i];

                resultados.SumaXporY = resultados.SumaXporY + (vecx[i] * vecy[i]);

                resultados.SumaXCuadrados = resultados.SumaXCuadrados + (Math.Pow(vecx[i], 2));
            }

            resultados.PromedioX = resultados.PromedioX / c;
            resultados.PromedioY = resultados.PromedioY / c;

            return resultados;
        }


    }
}