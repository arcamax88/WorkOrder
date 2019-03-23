using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOrder
{
    public class CheckAndMakeCorrectionManufacturerName
    {
        public static string Action(string inManufacturerName)
        {
            string outManufacturerName;
            string[] splitManufacturerName;

            splitManufacturerName = CheckAndReplaceEmptyString.Action(inManufacturerName).TrimStart().Split(' ', '&', '/');
            if (splitManufacturerName.Length >= 2)
            {
                switch (splitManufacturerName[0].Trim())
                {
                    case "FISHER":
                        {
                            outManufacturerName = "FISHER AND PAYKEL";
                            break;
                        }
                    case "AMEDA":
                        {
                            outManufacturerName = "AMEDA";
                            break;
                        }
                    default:
                        {
                            outManufacturerName = splitManufacturerName[0] + " " + splitManufacturerName[1];
                            break;

                        }
                }
            }
            else
            {
                outManufacturerName = splitManufacturerName[0];
            }
            return outManufacturerName;
        }
    }
}
