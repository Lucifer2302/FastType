using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FastType_Koshevoi_Chernenkov.AppData
{
    public class TypeQuality
    {
        /// <summary>
        /// Возвращает или задает скорость печати
        /// </summary>
        /// <param name="input"> Длина исходного текста </param>
        /// <param name="temp"> Темп печати </param>
        /// <return> </return>
        public static decimal Speed { get; set; }

        public static string CalculateSpeed(TextBox input, int temp)
        {
            //?
            //((кол-во символов / время)) * 60).ToString(); 
            return (input.Text.Length / temp * 60).ToString();
        }

    }
}


