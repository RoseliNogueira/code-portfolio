using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLH_DLL
{
    static public class Validations
    {
        static public bool CheckLenght(int x)
        {
            bool success = false;
            if (x <= 15)
            {
                success = true;
            }
            return success;
        }
    }
}
