using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team12_SSIS.Model
{
    public class TempInventoryRetrieval
    {
        // Attributes
        private int requestID;
        private int requestDetailID;
        private string itemID;
        private string departmentID;
        private int requestedQty;
        private int actualQty;
        private bool isOverride = false;


        // Constructor
        public TempInventoryRetrieval(int requestID, int requestDetailID, string itemID, string departmentID, int requestedQty, int actualQty)
        {
            this.requestID = requestID;
            this.requestDetailID = requestDetailID;
            this.itemID = itemID;
            this.departmentID = departmentID;
            this.requestedQty = requestedQty;
            this.actualQty = actualQty;
        }


        // Properties
        public int RequestID
        {
            get { return requestID; }
            set { requestID = value; }
        }

        public int RequestDetailID
        {
            get { return requestDetailID; }
            set { requestDetailID = value; }
        }

        public string ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }

        public string DepartmentID
        {
            get { return departmentID; }
            set { departmentID = value; }
        }

        public int RequestedQty
        {
            get { return requestedQty; }
            set { requestedQty = value; }
        }

        public int ActualQty
        {
            get { return actualQty; }
            set { actualQty = value; }
        }

        public bool IsOverride
        {
            get { return isOverride; }
            set { isOverride = value; }
        }
    }
}