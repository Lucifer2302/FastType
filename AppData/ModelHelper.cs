using FastType_Koshevoi_Chernenkov.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastType_Koshevoi_Chernenkov.AppData
{
    class ModelHelper
    {
        private static FastType_KoshevoiEntities context;

        public static FastType_KoshevoiEntities GetContext()
        {
            if (context == null)
            {
                context = new FastType_KoshevoiEntities();
            }
            return context;
        }
    }
}
