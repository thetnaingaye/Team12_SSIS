using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team12_SSIS.Model;

namespace Team12_SSIS.BusinessLogic
{
    public class DisbursementLogic
    {
        public List<int> GetListOfDisbursement()
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                List<int> disbursementList = ctx.DisbursementLists.Select(x => x.DisbursementID).ToList();
                return disbursementList;
            }
        }

        public bool AddDisbursementList()
        {
            DisbursementList dl = new DisbursementList();
            dl.DepartmentID = "ENGL";
            dl.CollectionPointID = 1;
            dl.CollectionDate = DateTime.Now.Date;
            dl.RepresentativeName = "Pradeep";

            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                ctx.DisbursementLists.Add(dl);
                ctx.SaveChanges();
            }
            return true;
        }
    }
}