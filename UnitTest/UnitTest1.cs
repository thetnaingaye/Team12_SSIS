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

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine(IsPositiveInteger(23));
            Console.WriteLine(IsPositiveInteger(-23).ToString());
            Console.WriteLine(IsPositiveInteger(0).ToString());
        }
        [TestMethod]
        public void TestMethod2()
        {

            Console.WriteLine(IsProductIdFormat("P0232"));
            Console.WriteLine(IsProductIdFormat("p0232"));
            Console.WriteLine(IsProductIdFormat("pp0232"));
            Console.WriteLine(IsProductIdFormat("#0323"));
            Console.WriteLine(IsProductIdFormat("0232"));
        }
        [TestMethod]
        public void TestMethod3()
        {
            Console.WriteLine(IsEmailFormat("abc@gmail.com"));
            Console.WriteLine(IsEmailFormat("abc@u.nus.edu"));
            Console.WriteLine(IsEmailFormat("abc.abc.nus.edu"));
        }

        [TestMethod]
        public void TestMethod4()
        {
            string todayDate = "18/Jan/2017";
            string tomorrowDate = "20/Jan/2017";
            Console.WriteLine(IsDateRangeValid(DateTime.Parse(todayDate), DateTime.Parse(tomorrowDate)).ToString());
            Console.WriteLine(IsDateRangeValid(DateTime.Parse(todayDate), DateTime.Parse(todayDate)).ToString());
            Console.WriteLine(IsDateRangeValid(DateTime.Parse(tomorrowDate), DateTime.Parse(todayDate)).ToString());
        }

        [TestMethod]
        public void TestMethod6()
        {
            int i = Team12_SSIS.Utility.Utility.GetValidPrimaryKeyInt("GR00010");
            Console.WriteLine(i.ToString());


        }
        [TestMethod]
        public void TestMail()
        {
            string s = "GR00010";
            Regex regex = new Regex("[0-9]");
            int x;
            for (int i = 0; i < s.Length; i++)
            {
                if (regex.IsMatch(s.Substring(i, 1)))
                {                    
                    bool isValid = int.TryParse(s.Substring(2, 5), out x);
                    Console.WriteLine(i.ToString(),x.ToString());
                    break;
                }
            }
        }


        public void TestMethod7()
        {
            //Start Here....








            //Some things there




























        }
    }
}
