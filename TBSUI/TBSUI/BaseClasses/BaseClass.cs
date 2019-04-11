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
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System.IO;
using System.Reflection;

namespace TBSUI.BaseClasses
{
    [TestClass]

    public class BaseClass
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));
        private static FirefoxOptions GetFirefoxptions()
        {
            FirefoxOptions profile = new FirefoxOptions();
            FirefoxProfileManager manager = new FirefoxProfileManager();
            //profile = manager.GetProfile("default");
            Logger.Info(" Using Firefox Profile ");
            return profile;
        }
        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("start-maximized");            
            option.AddUserProfilePreference("disable-popup-blocking", "true");
            option.AddArgument("--proxy-server='direct://'");
            option.AddArgument("--proxy-bypass-list=*");
            option.AddArgument("incognito");
            Logger.Info(" Using Chrome Options ");
            return option;
        }

        private static ChromeOptions GetChromeHeadlessOption()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("--kiosk");
            option.AddArguments("--headless");
            option.AddArguments("window-size=1920,1080");
            option.AddUserProfilePreference("disable-popup-blocking", "true");
            Logger.Info(" Using Chrome Options ");
            return option;
        }

        private static InternetExplorerOptions GetIEOptions()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.IgnoreZoomLevel = true;
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.EnsureCleanSession = true;
            options.ElementScrollBehavior = InternetExplorerElementScrollBehavior.Bottom;
            Logger.Info(" Using Internet Explorer Options ");
            return options;
        }


        private static FirefoxDriver GetFirefoxDriver()
        {
            FirefoxDriver driver = new FirefoxDriver(GetFirefoxptions());
            return driver;
        }

        public static  IWebDriver GetAppiumEmulatorAndroidDriver()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(MobileCapabilityType.PlatformName, MobilePlatform.Android);
            capabilities.SetCapability(MobileCapabilityType.DeviceName, "Android Emulator");
            capabilities.SetCapability(MobileCapabilityType.NewCommandTimeout, "200000");
            capabilities.SetCapability(MobileCapabilityType.App, "/app-bettingClubTheme-debug.apk");
            //Connecting to Appium Server
            var driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(200));
            return driver;
        }

        public static IWebDriver GetAppiumRealDeviceAndroidDriver()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(MobileCapabilityType.PlatformName, MobilePlatform.Android);
            capabilities.SetCapability(MobileCapabilityType.DeviceName, "OPPO F1s");
            capabilities.SetCapability(MobileCapabilityType.NewCommandTimeout, "200000");
            capabilities.SetCapability(MobileCapabilityType.App, "/app-bettingClubTheme-debug.apk");
            //Connecting to Appium Server
            var driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(200));
            return driver;
        }

        private static ChromeDriver GetChromeDriver()
        {
            ChromeDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }

        private static ChromeDriver GetChromeHeadlessDriver()
        {
            
            ChromeDriver driver = new ChromeDriver(GetChromeHeadlessOption());
            return driver;
        }

        private static InternetExplorerDriver GetIEDriver()
        {
            InternetExplorerDriver driver = new InternetExplorerDriver(GetIEOptions());
            return driver;
        }

        private static EdgeDriver GetEdgeDriver()
        {
            EdgeDriver driver = new EdgeDriver();
            return driver;
        }

        private static PhantomJSDriver GetPhantomJsDriver()
        {
            PhantomJSDriver driver = new PhantomJSDriver(GetPhantomJsDrvierService());

            return driver;
        }

        private static PhantomJSOptions GetPhantomJsptions()
        {
            PhantomJSOptions option = new PhantomJSOptions();
            option.AddAdditionalCapability("handlesAlerts", true);
            Logger.Info(" Using PhantomJS Options  ");
            return option;
        }

        private static PhantomJSDriverService GetPhantomJsDrvierService()
        {
            PhantomJSDriverService service = PhantomJSDriverService.CreateDefaultService();
            service.LogFile = "TestPhantomJS.log";
            service.HideCommandPromptWindow = false;
            service.LoadImages = true;
            Logger.Info(" Using PhantomJS Driver Service  ");
            return service;
        }


        [AssemblyInitialize]
        [BeforeFeature()]
        public static void InitWebdriver(TestContext tc)
        {
            ObjectRepository.Config = new AppConfigReader();
            //ObjectRepository.Service = ChromeDriverService.CreateDefaultService(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            //ObjectRepository.Service.Port = 5555; // Some port value.
            //ObjectRepository.Service.Start();
            

            switch (ObjectRepository.Config.GetBrowser())
            {
                case BrowserType.Firefox:
                    ObjectRepository.Driver = GetFirefoxDriver();
                    Logger.Info(" Using Firefox Driver  ");
                    break;

                case BrowserType.Chrome:
                    ObjectRepository.Driver = GetChromeDriver();
                    //var driver = new RemoteWebDriver(new Uri("http://127.0.0.1:5555"), GetChromeOptions());
                    //ObjectRepository.Driver = driver;
                    Logger.Info(" Using Chrome Driver  ");
                    break;
                case BrowserType.Chromeheadless:
                    ObjectRepository.Driver = GetChromeHeadlessDriver();
                    //var driverheadless = new RemoteWebDriver(new Uri("http://127.0.0.1:5555"), GetChromeHeadlessOption());
                    //ObjectRepository.Driver = driverheadless;
                    Logger.Info("Using Chrome Headless Driver");
                    break;
                case BrowserType.IExplorer:
                    ObjectRepository.Driver = GetIEDriver();
                    Logger.Info(" Using Internet Explorer Driver  ");
                    break;

                case BrowserType.PhantomJs:
                    ObjectRepository.Driver = GetPhantomJsDriver();
                    Logger.Info(" Using PhantomJs Driver  ");
                    break;
                case BrowserType.IEdge:
                    ObjectRepository.Driver = GetEdgeDriver();
                    Logger.Info(" Using Edge Driver  ");
                    break;

                case BrowserType.AndroidRealDevice:
                    ObjectRepository.Driver = GetAppiumRealDeviceAndroidDriver();
                    break;

                case BrowserType.AndroidEmulator:
                    ObjectRepository.Driver = GetAppiumEmulatorAndroidDriver();
                    break;

                default:
                    throw new NoSutiableDriverFound("Driver Not Found : " + ObjectRepository.Config.GetBrowser().ToString());
            }
            ObjectRepository.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTimeOut());
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut());
            
            
    }

        [AfterScenario()]
        [AssemblyCleanup]
        public static void TearDown()
        {
            if (ObjectRepository.Driver != null)
            {
                ObjectRepository.Driver.Close();
                ObjectRepository.Driver.Quit();
            }

            if(ObjectRepository.Service !=null)
            {
                ObjectRepository.Service.Dispose();
            }
            Logger.Info(" Stopping the Driver and Service  ");
        }
    }
}
