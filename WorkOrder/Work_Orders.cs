using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOrder
{
    public class Work_Orders
    {
        public string WO_NUMBER { get; set; }
        public string TRADE_EMP_DESC { get; set; }
        public string TRADE_EMP_CODE { get; set; }
        public string TRADE_EMP_TYPE { get; set; }
        public string STAT_DATETIME { get; set; }
        public string TAG_NUMBER { get; set; }
        public string SERIAL_NUM { get; set; }
        public string MANUFACTURER { get; set; }
        public string MANUFACTURER_DESC { get; set; }
        public string MODEL_NUM { get; set; }
        public string BUILDING { get; set; }
        public string BUILDING_DESC { get; set; }
        public string LOCATION_CODE { get; set; }
        public string LOCATION_DESC { get; set; }
        public string EMPLOYEE_DESC { get; set; }
        public string ACTION { get; set; }
    }
}
