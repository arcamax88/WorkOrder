using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOrder
{
    public class CheckAndMakeCorrectionEmployeeName
    {
        public static string Action(string inEmployeeName)
        {
            string outEmployeeName;
            string[] splitEmployeeName;

            splitEmployeeName = CheckAndReplaceEmptyString.Action(inEmployeeName).Split(' ');
            outEmployeeName = " " + splitEmployeeName[0].Substring(0, 1) + "." + splitEmployeeName[1];
            return outEmployeeName;
        }
    }
}
