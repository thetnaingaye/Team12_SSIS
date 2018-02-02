using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Team12_SSIS.Utility.Validator;
using Team12_SSIS.BusinessLogic;
using System.Collections.Generic;
using System.Data.Entity;
using Team12_SSIS.Utility;
using System.Data;
using System.Linq;
using Team12_SSIS.Model;
using System.Web.Security;
using System.Text.RegularExpressions;
using System.Text;
using Team12_SSIS.Supplier;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetCollectionPointNameAndId()
		{
			//This is english dept
			string currentDept = "ENGL"; 
			//This should show the current CP Id - currently is 6.
			string currentCPByDept = DisbursementLogic.GetCurrentCPIDByDep(currentDept);
			Console.WriteLine(currentCPByDept);
			//This should show University Hospital, 11A.M
			string currentCPNameById = DisbursementLogic.GetCurrentCPWithTimeByID(Int32.Parse(currentCPByDept));
			Console.WriteLine(currentCPNameById);			
        }
        [TestMethod]
        public void TestGetCurrentOrderLeadTime()
		{
			//This is ALPHA Office Supplies
			string supplierID = "ALPA";
			//This should show the current order lead time of ALPHA Office Supplies - 3
			string orderLeadTime = PurchasingLogic.GetCurrentOrderLeadTime(supplierID).ToString();
			Console.WriteLine(orderLeadTime);

		}
        [TestMethod]
        public void TestGetCurrentBufferStockLevel()
        {
			//This is Clips item
			string itemID = "C001";
			//This should show the current buffer stock level of Clips item -
			int bufferStockLevel = PurchasingLogic.GetCurrentBufferStock(itemID);
			Console.WriteLine(bufferStockLevel);
        }

    }
}
