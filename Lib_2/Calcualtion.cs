using LibMas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_2
{
    public static class Calcualtion
    {

        /// <summary>
        /// Нахождение проиведения и суммы К-ого столбца
        /// </summary>
        /// <param name="array">Двумерный массив</param>
        /// <param name="k">Число К</param>
        /// <returns>Произведение и сумма К-ого столбца в виде кортежа.</returns>
        public static (string, string) SumAndProduct(this Arrayx array, int k)
        {
            int prod = 1;
            int sum = 0;
            for (int i = 0; i < array.LineLength; i++)
            {
                for (int j = 0; j < array.ColumnLength; j++)
                {
                    if (k ==  i + 1)
                    {
                        prod *= array[j, i];
                        sum += array[j, i];
                    }
                }
            }
            return (prod.ToString(), sum.ToString());
        }   
    }
}
