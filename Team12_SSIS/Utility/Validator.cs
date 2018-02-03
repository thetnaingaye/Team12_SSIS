//Author: Lim Chang Siang
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace Team12_SSIS.Utility
{
    public static class Validator
    {
        public static bool IsPositiveInteger(int i)
        {
            Regex regex = new Regex("^\\d+$");
            return regex.IsMatch(i.ToString());

        }

        public static bool IsProductIdFormat(string productId)
        {
            Regex regex = new Regex("^([A-Za-z])([0-9][0-9][0-9])");
            return regex.IsMatch(productId);
        }

        public static bool IsEmailFormat(string email)
        {
            Regex regex = new Regex("^[A-Za-z0-9](([_\\.\\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\\.\\-]?[a-zA-Z0-9]+)*)\\.([A-Za-z]{2,})$");
            return regex.IsMatch(email);
        }

        public static bool IsDateRangeValid(DateTime startDate, DateTime endDate)
        {
            if(startDate < endDate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsDateRangeValid(DateTime startDate, DateTime endDate, bool andToday)
        {
            if (startDate <= endDate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string IsEmptyReturnSpace(string validString)
        {
            if(validString == "")
            {
                return " ";
            }
            return validString;
        }

        public static bool IsIntMoreThan(int value, int maximumLimit)
        {
            if (value <= maximumLimit)
                return false;
            else
                return true;
        }


    }
}