using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOrder
{
    public class CheckAndMakeCorrectionForDepartmentName
    {
        public static string Action(string inDepartmentName)
        {
            string outDepartmentName;
            string[] splitDepartmentName;


            splitDepartmentName = CheckAndReplaceEmptyString.Action(inDepartmentName).TrimStart().Split('-');
            if (splitDepartmentName.Length >= 2)
            {
                switch (splitDepartmentName[1].Trim())
                {
                    case "CENTRAL CLINICAL EQUIP SER":
                        {
                            outDepartmentName = "CCES";
                            break;
                        }
                    case "HIGH DEPENDENCY UNIT":
                        {
                            outDepartmentName = "HDU";
                            break;
                        }
                    case "ACCIDENT AND EMERGENCY":
                        {
                            outDepartmentName = "ED";
                            break;
                        }
                    case "ACCIDENT & EMERGENCY":
                        {
                            outDepartmentName = "ED";
                            break;
                        }
                    case "LOGAN HOSPITAL":
                        {
                            outDepartmentName = "WARDS";
                            break;
                        }
                    case "WARD 2E EXTENDED MIDWIFERY":
                        {
                            outDepartmentName = "WARD 2E EXT.";
                            break;
                        }
                    case "NET REQUEST":
                        {
                            outDepartmentName = "WARDS";
                            break;
                        }
                    default:
                        {
                            outDepartmentName = splitDepartmentName[1];
                            break;
                        }
                }
            }
            else
            {
                switch (splitDepartmentName[0])
                {
                    case "BEAUDESERT HOSPITAL":
                        {
                            outDepartmentName = "WARDS";
                            break;
                        }
                    case "LOGAN HOSPITAL":
                        {
                            outDepartmentName = "WARDS";
                            break;
                        }
                    case "NET REQUEST":
                        {
                            outDepartmentName = "WARDS";
                            break;
                        }
                    default:
                        {
                            outDepartmentName = splitDepartmentName[0];
                            break;
                        }
                }
            }
            return outDepartmentName;
        }
    }
}
