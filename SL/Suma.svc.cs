using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Suma" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Suma.svc or Suma.svc.cs at the Solution Explorer and start debugging.
    public class Suma : ISuma
    {
        public int SumarNumeros(int a, int b)
        {
            return a + b;
        }

        public int Resta(int a, int b)
        {
            return a - b;
        }
    }


}
