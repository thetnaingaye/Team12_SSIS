﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team12_SSIS.Model;

namespace Team12_SSIS.BusinessLogic
{
    //Khair Line 15 to 315
    //Jane Line 316 to 616
    //Naing Line 617 to 917
    //Pradeep 1218 to 1518
    //Yishu Line 1519 to 1820
    public class RequisitionLogic
    {



















































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































	public static void AddDelegate(String fullname,DateTime startdate, DateTime enddate, string depid)
	{
			if (startdate >= DateTime.Today && enddate >= startdate)
			{
				using (SA45Team12AD entities = new SA45Team12AD())
				{
					DDelegateDetail delegateDetail = new DDelegateDetail
					{
						DepartmentID = depid,
						DepartmentHeadDelegate = fullname,
						StartDate = startdate,
						EndDate = enddate
					};
					entities.DDelegateDetails.Add(delegateDetail);
					entities.SaveChanges();
				}
			}
			
	}

	public static List<DDelegateDetail> ListDelegateDetails(string dept)
		{
			using (SA45Team12AD entities = new SA45Team12AD())
			{
				return entities.DDelegateDetails.Where(x=>x.DepartmentID == dept).ToList<DDelegateDetail>();
			}
		}

		public static List<DDelegateDetail> FindDelegateDetailsByEmployeeName(string input, string dept)
		{
			using (SA45Team12AD entities = new SA45Team12AD())
			{
				return entities.DDelegateDetails.Where(x => x.DepartmentHeadDelegate.Contains(input)).Where(x => x.DepartmentID == dept).ToList<DDelegateDetail>();
			}
		}











































































































































































































































































































        public List<InventoryCatalogue> SearchBy(string value)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.InventoryCatalogues.Where(i => i.ItemID.Contains(value) || i.Description.Contains(value)).ToList();
            }
        }

        //public static List<InventoryCatalogue> DeleteOrder(List<InventoryCatalogue> _bookList, int bookID)
        //{
        //    //List<Book> bookList = _bookList;
        //    //Book removeBook = bookList.Where(b => b.BookID == bookID).First<Book>();
        //    //bookList.Remove(removeBook);
        //    //return bookList;
        //}

    }
    }