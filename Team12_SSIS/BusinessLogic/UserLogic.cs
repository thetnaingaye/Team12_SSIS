using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team12_SSIS.BusinessLogic
{
	public class UserLogic
	{
		public static string GetCurrentDep()
		{
			return HttpContext.Current.Profile.GetPropertyValue("department").ToString();
		}



	}
}