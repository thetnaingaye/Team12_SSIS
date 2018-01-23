using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team12_SSIS.Utility
{
    public class DisbursementUtility
    {
        private int DisbursementID;
        private string DepartmentName;
        private DateTime? CollectionDate;
        private string CollectionPoint1;
        private string RepresentativeName;
        private string status;

        public DisbursementUtility(int _DisbursementID,string _DepartmentName,DateTime? _CollectionDate,string _CollectionPoint1, string _RepresentativeName,string _status)
        {
            this.DisbursementID = _DisbursementID;
            this.DepartmentName = _DepartmentName;
            this.CollectionDate = _CollectionDate;
            this.CollectionPoint1 = _CollectionPoint1;
            this.RepresentativeName = _RepresentativeName;
            this.status = _status;
        }
        public DisbursementUtility()
        {

        }

        public int GetDisbursemnet()
        {
            return DisbursementID;

        }
        public string GetDepartmentName()
        {
            return DepartmentName;

        }
        public DateTime GetCollectionDate()
        {
            return (DateTime) CollectionDate;

        }
        public string GetCollectionPoint1()
        {
            return CollectionPoint1;

        }
        public string GetRepresentativeName()
        {
            return RepresentativeName;

        }
        public string Getstatus()
        {
            return status;

        }

    }
}