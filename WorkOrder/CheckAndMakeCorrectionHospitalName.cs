using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOrder
{
    public class CheckAndMakeCorrectionHospitalName
    {
        public static string Action(string inHospitalName)
        {
            string outHospitalName;

            switch (inHospitalName)
            {
                case "QUEENSLAND CHILDRENS HOSPITAL":
                    {
                        outHospitalName = "QCH";
                        break;
                    }
                default:
                    {
                        outHospitalName = inHospitalName;
                        break;
                    }
            }
            return outHospitalName;
        }
    }
}
