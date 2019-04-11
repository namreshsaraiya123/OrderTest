using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TBSUI.BaseClasses;
using TBSUI.ComponentHelper;
using TBSUI.Settings;
using System.Threading;

namespace TBSUI.PageObject
{
    public class TestCompleteLoginPage :PageBase
    {
        private IWebDriver driver;

        #region Webelement
        [FindsBy(How = How.Id, Using = "ctl00_MainContent_username")]
        public IWebElement UsernameTextBox;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_password")]
        public IWebElement PasswordTextBox;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_login_button")]
        public IWebElement LoginButton;

        [FindsBy(How = How.Id, Using = "ctl00_logout")]
        public IWebElement LogoutButton;

        #endregion


        public TestCompleteLoginPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        public void TestCompleteLogin(string username, string password)
        {
            GenericHelper.WaitForWebElementInPage(By.Id("ctl00_MainContent_username"), TimeSpan.FromSeconds(30));
            UsernameTextBox.SendKeys(username);
            PasswordTextBox.SendKeys(password);
            LoginButton.Click();
            GenericHelper.WaitForWebElementInPage(By.Id("ctl00_logout"), TimeSpan.FromSeconds(30));
        }

        public void EnterUsername(string username)
        {
            GenericHelper.WaitForWebElementInPage(By.Id("ctl00_MainContent_username"), TimeSpan.FromSeconds(30));
            UsernameTextBox.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            GenericHelper.WaitForWebElementInPage(By.Id("ctl00_MainContent_username"), TimeSpan.FromSeconds(30));
            PasswordTextBox.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
            GenericHelper.WaitForWebElementInPage(By.Id("ctl00_logout"), TimeSpan.FromSeconds(30));

        }

        public void ClickLogOutButton()
        {
            LogoutButton.Click();
            GenericHelper.WaitForWebElementInPage(By.Id("ctl00_MainContent_username"), TimeSpan.FromSeconds(30));

        }
    }
}
