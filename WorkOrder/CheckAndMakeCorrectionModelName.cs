using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOrder
{
    public class CheckAndMakeCorrectionModelName
    {
        public static string Action(string inModelName)
        {
            string outModelName;

            switch (inModelName)
            {
                case "1110063":
                    {
                        outModelName = "INNOSPIRE DELUXE";
                        break;
                    }
                case "860310":
                    {
                        outModelName = "TC50";
                        break;
                    }
                case "860315":
                    {
                        outModelName = "TC70";
                        break;
                    }
                case "M2703A":
                    {
                        outModelName = "FM30";
                        break;
                    }
                case "m2703a":
                    {
                        outModelName = "FM30";
                        break;
                    }
                case "UIBX-230-N2930-CR/2*":
                    {
                        outModelName = "UIBX-230-N2930";
                        break;
                    }
                default:
                    {
                        outModelName = inModelName;
                        break;

                    }
            }
            return outModelName;
        }
    }
}
