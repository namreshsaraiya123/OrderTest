using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TBSUI.Interfaces;
using TBSUI.PageObject;

namespace TBSUI.Settings
{
    public class ObjectRepository
    {
        public static IConfig Config { get; set; }
        public static IWebDriver Driver { get; set; }

        public static DriverService Service { get; set; }

        
    }
}
