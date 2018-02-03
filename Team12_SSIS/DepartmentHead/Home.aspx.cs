//Thet Naing Aye and SICAT JANE ESCALADA
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

namespace Team12_SSIS.DepartmentHead
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected int GetPendingRequestCount()
        {
            String dep = DisbursementLogic.GetCurrentDep();
            List<RequisitionRecord> list = RequisitionLogic.ListAllRRBySpecificDeptAndStatus(dep, "Pending");
            return list.Count;
        }
        protected String GetRep()
        {
            
            return DisbursementLogic.GetDeptRepFullName(DisbursementLogic.GetCurrentDep());
        }
    }
}