using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DL
{
    public class Conexion
    {
        public static string GetConnectionString()
        {
            //return System.Configuration.ConfigurationManager.ConnectionStrings["Data Source=.;Initial Catalog=IEspinozaProgramacionNCapasGF2023;Persist Security Info=True;User ID=sa;Password=pass@word1"].ConnectionString.ToString();
            return ConfigurationManager.ConnectionStrings["IEspinozaProgramacionNCapasGF2023"].ConnectionString.ToString();
        }
    }
}
