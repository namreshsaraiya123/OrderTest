using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using TBSUI.ComponentHelper;
using TBSUI.Configuration;
using TBSUI.CustomException;
using TBSUI.Settings;
using TechTalk.SpecFlow;
using log4net.Repository.Hierarchy;

namespace TBSUI.GeneralHook
{
    [Binding]
    public sealed class GeneralHook
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("BeforeTestRun Hook");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("AfterTestRun Hook");
        }

        [BeforeFeature("Tag1")]
        public static void BeforeFeature()
        {
            Console.WriteLine("BeforeFeature Hook");
        }

        [AfterFeature("Tag1")]
        public static void AfterFeature()
        {
            Console.WriteLine("AfterFeature Hook");
        }

        [BeforeScenario("Tag1")]
        public static void BeforeScenario()
        {
            Console.WriteLine("BeforeScenario Hook");
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            Console.WriteLine("AfterScenario Hook");
            
            if (ScenarioContext.Current.TestError != null)
            {
                string name = ScenarioContext.Current.ScenarioInfo.Title + ".jpeg";
                GenericHelper.TakeScreenShot(name);
                Console.WriteLine(ScenarioContext.Current.TestError.Message);
                Console.WriteLine(ScenarioContext.Current.TestError.StackTrace);
            }
        }
    }
}
