using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalEquipmentTester;

namespace WorkOrder
{
    public class WorkOrder
    {
        public string FindEmployeeName = "[NAME]";
        public string FindDate = "[DATE]";
        public string FindWorkOrder = "[WORK ORDER]";
        public string FindHospitalName = "[FACILITY]";
        public string FindManufacturer = "[MANUFACTURER]";
        public string FindDepartmentName = "[LOCATION]";
        public string FindModel = "[MODEL]";
        public string FindControlNumber = "[ASSET NUMBER]";
        public string FindSerialNumber = "[SERIAL NUMBER]";

        private string _workOrderNumber;
        private string _employeeName;
        private string _date;
        private string _controlNumber;
        private string _serialNumber;
        private string _manufacturerName;
        private string _modelName;
        private string _hospitalName;
        private string _departmentName;
        private string _action;

        public string WorkOrderNumber
        {
            get { return _workOrderNumber; }
            set { _workOrderNumber = value; }
        }
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }
        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public string ControlNumber
        {
            get { return _controlNumber; }
            set { _controlNumber = value; }
        }
        public string SerialNumber
        {
            get { return _serialNumber; }
            set { _serialNumber = value; }
        }
        public string ManufacturerName
        {
            get { return _manufacturerName; }
            set { _manufacturerName = value; }
        }
        public string ModelName
        {
            get { return _modelName; }
            set { _modelName = value; }
        }
        public string HospitalName
        {
            get { return _hospitalName; }
            set { _hospitalName = value; }
        }
        public string DepartmentName
        {
            get { return _departmentName; }
            set { _departmentName = value; }
        }
        public string Action
        {
            get { return _action; }
            set { _action = value; }
        }

        public WorkOrder(string workOrderNumber, string employeeName, string date, string controlNumber, string serialNumber,
                                    string manufacturerName, string modelName, string hospitalName, string departmentName, string action)
        {
            _workOrderNumber = workOrderNumber;
            _employeeName = CheckAndMakeCorrectionEmployeeName.Action(employeeName);
            _date = date.Substring(0, 10);
            _controlNumber = controlNumber;
            _serialNumber = serialNumber;
            _manufacturerName = CheckAndMakeCorrectionManufacturerName.Action(manufacturerName);
            _modelName = CheckAndMakeCorrectionModelName.Action(modelName);
            _hospitalName = hospitalName;
            _departmentName = CheckAndMakeCorrectionForDepartmentName.Action(departmentName);
            _action = action;
        }



        //for equipment model in which the IPM form does not have a measured value.
        public bool CreateIpmForm(string inputFile, string outputFile, List<Tester> testers)
        {
             File.Copy(inputFile, outputFile, true);

            // Open copied document.
            using (var flatDocument = new FlatDocument(outputFile))
            {
                AddEquipmentDetails(flatDocument);
                AddTestersToDocu(flatDocument, testers);
                AddMeasuredValueToDocu(flatDocument);
            }
            return true;
        }

        private void AddEquipmentDetails(FlatDocument docu)
        {
            docu.FindAndReplace(FindEmployeeName, _employeeName);
            docu.FindAndReplace(FindDate, _date);
            docu.FindAndReplace(FindWorkOrder, _workOrderNumber);
            docu.FindAndReplace(FindHospitalName, _hospitalName);
            docu.FindAndReplace(FindManufacturer, _manufacturerName);
            docu.FindAndReplace(FindDepartmentName, _departmentName);
            docu.FindAndReplace(FindModel, _modelName);
            docu.FindAndReplace(FindControlNumber, _controlNumber);
            docu.FindAndReplace(FindSerialNumber, _serialNumber);
        }

        private void AddTestersToDocu(FlatDocument docu, List<Tester> listTesterDetails)
        {
            foreach (Tester item in listTesterDetails)
            {
                docu.FindAndReplace("[" + item.Name + " ASSET]", item.ControlNumber);
                docu.FindAndReplace("[" + item.Name + " CAL DATE]", item.CalibrationDueDate);
            }
        }

        private void AddMeasuredValueToDocu(FlatDocument docu)
        {
            var dictionary = new Dictionary<string, string>();

            //test result data inside strAction
            string[] splitAction = _action.Split(',');
            foreach (string measuredValue in splitAction)
            {
                string[] splitMeasuredValue = measuredValue.Split('=');
                string strDictKeyPairNoSpace = splitMeasuredValue[0].TrimStart()
                    .TrimEnd().ToUpper();
                string dictKeyPair = "[" + strDictKeyPairNoSpace + "]";
                dictionary.Add(dictKeyPair, splitMeasuredValue[1]);
            }

            foreach (var pair in dictionary)
            {
                docu.FindAndReplace(pair.Key, pair.Value);
            }
        }
    }
}

