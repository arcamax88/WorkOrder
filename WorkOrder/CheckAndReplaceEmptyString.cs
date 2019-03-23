using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOrder
{
    public class CheckAndReplaceEmptyString
    { 
        public static string Action(string strInput)
        {
            string strOutput;

            if (strInput == string.Empty)
            {
                strOutput = "UNKNOWN";
            }
            else
            {
                strOutput = strInput;
            }
            return strOutput;
        }
    }
}
