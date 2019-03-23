using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WorkOrder
{
    public class AIMSExport
    {
        [XmlElement("Work_Orders")]
        public List<Work_Orders> ListOfWorkOrders = new List<Work_Orders>();
    }
}

