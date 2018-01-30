using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Reflection;
using RDotNet;
using DynamicInterop;

namespace Team12_SSIS.BusinessLogic.RScripts
{
    public class RFactory
    {
        // Forecasting algorithm
        public static string ForecastAlgorithm()
        {
            REngine.SetEnvironmentVariables("C:\\Program Files\\R\\R-3.4.1\\bin\\x64");
            using (REngine engine = REngine.GetInstance())
            {
                engine.Initialize();

                engine.Evaluate("tempwd <- 'Hello'");
                engine.Evaluate("temwaefpwd <- 'Hello'");
                engine.Evaluate("w <- 'Hello'");
                engine.Evaluate("se <- 'Hello'");
                engine.Evaluate("ss <- 'ss'");
                string[] b = engine.Evaluate("ss").AsCharacter().ToArray();
                string temp = b[0];
                return temp;
            }

        }


        public static string Test()
        {
            string path = System.Environment.CurrentDirectory;

            return path;
        }
    }
}