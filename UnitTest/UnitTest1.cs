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
            string userName = "clerk1";
            string password = "Password@#1";
            char seperator = '/';

            var topSecret = userName + seperator + password;
            int shft = 5;
            string encrypted = topSecret.Select(ch => ((int)ch) << shft).Aggregate("", (current, val) => current + (char)(val * 2));
            encrypted = Convert.ToBase64String(Encoding.UTF8.GetBytes(encrypted));
            string decrypted = Encoding.UTF8.GetString(Convert.FromBase64String(encrypted)).Select(ch => ((int)ch) >> shft).Aggregate("", (current, val) => current + (char)(val / 2));
            Console.WriteLine(topSecret);
            Console.WriteLine(encrypted);
            string[] splitString = decrypted.Split(seperator);
            foreach(string s in splitString)
            {
                Console.WriteLine(s);
            }

        }
        [TestMethod]
        public void TestMail()
        {
            DisbursementLogic dl = new DisbursementLogic();
            for (int i = 15; i < 43; i++)
                dl.UpdateDisbursementListDetails(i, 5, "Test Cases");
        }


        public void TestMethod7()
        {
            //Start Here....








            //Some things there




























        }
    }
}
