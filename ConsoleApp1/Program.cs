using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOrder;
using System.IO;
using System.Xml.Serialization;
using MedicalEquipmentTester;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<WorkOrder.WorkOrder> workOrdersIpmFormUnfinished = new List<WorkOrder.WorkOrder>();
            List<Tester> testers = new List<Tester>();
            List<string> parameters = new List<string>();
            string xmlFile = "Ipm.xml";

            Tester tester = new Tester();
            testers = tester.ReadXmlFile("List_of_Currently_Used_Tester.xml");

            using (StreamReader sr = new StreamReader("Parameters.txt"))
            {
                string[] splitParameters = sr.ReadLine().Split(',');
                foreach(string item in splitParameters)
                {
                    parameters.Add(item);
                }
            }

            List<WorkOrder.WorkOrder> workOrders = new List<WorkOrder.WorkOrder>();

            XmlSerializer deserializer = new XmlSerializer(typeof(AIMSExport));
            TextReader reader = new StreamReader(xmlFile);
            object obj = deserializer.Deserialize(reader);
            AIMSExport xmlData = (AIMSExport)obj;
            reader.Close();

            int row_count = 0;
            foreach (Work_Orders item in xmlData.ListOfWorkOrders)
            {
                row_count++;
                Console.WriteLine(row_count);
                Console.WriteLine(item.WO_NUMBER + " " + item.TAG_NUMBER + " " + item.MANUFACTURER_DESC + " " + item.MODEL_NUM + " " + item.SERIAL_NUM + " " + item.LOCATION_DESC
                    + " " + item.EMPLOYEE_DESC);
                WorkOrder.WorkOrder wo = new WorkOrder.WorkOrder(item.WO_NUMBER, item.EMPLOYEE_DESC, item.STAT_DATETIME, item.TAG_NUMBER, item.SERIAL_NUM, item.MANUFACTURER_DESC,
                                                                    item.MODEL_NUM, item.BUILDING_DESC, item.LOCATION_DESC, item.ACTION);
                Console.WriteLine(wo.WorkOrderNumber + " " + wo.ControlNumber + " " + wo.ModelName + " " + wo.SerialNumber  + " " + wo.DepartmentName 
                    + " " + wo.HospitalName + " " + wo.EmployeeName);

                string[] splitAction;
                splitAction = item.ACTION.Split(':');
                if (splitAction.Length == 2)
                {

                    wo.Action = splitAction[1];
                }
                else
                {
                    wo.Action = "Vol = 20ml,OCC1 = 8.8psi,OCC2 = 9.2psi";
                }

                Console.WriteLine(wo.Action);
                string strOutputFile = ConstantString.IpmFormCompletedFolder + wo.ManufacturerName + "_" + wo.ModelName + "_" + wo.ControlNumber + "_" + wo.WorkOrderNumber + ".docx";
                wo.CreateIpmForm(ConstantString.InfusionPumpPlumA, strOutputFile, testers);
                Console.ReadLine();

            }
            Console.WriteLine(row_count);
            Console.ReadLine();
        }

    }
}
