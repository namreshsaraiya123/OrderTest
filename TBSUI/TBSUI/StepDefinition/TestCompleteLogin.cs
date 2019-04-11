using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TBSUI.ComponentHelper;
using TBSUI.PageObject;
using TBSUI.Settings;
using TechTalk.SpecFlow;
using System.Threading;
using TBSUI.Configuration;

namespace TBSUI.StepDefinition
{
    [Binding]
    public sealed class TestCompleteLogin
    {
        AppConfigReader clientname = new AppConfigReader();
        TestCompleteLoginPage loginpage = new TestCompleteLoginPage(ObjectRepository.Driver);

        #region Given
        [Given(@"user have visited the testcomplete home page")]
        public void GivenUserHaveVisitedTheTestcompleteHomePage()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
        }

        [Given(@"user is not logged in")]
        public void GivenUserIsNotLoggedIn()
        {
        
        }

        [Given(@"user logs in")]
        public void GivenUserLogsIn()
        {
            loginpage.TestCompleteLogin("Tester", "test");
        }


        #endregion

        #region When
        [When(@"user enters username in the username textbox as ""(.*)""")]
        public void WhenUserEntersUsernameInTheUsernameTextboxAs(string username)
        {
            loginpage.EnterUsername(username);
        }

        [When(@"user enters password in the password textbox as ""(.*)""")]
        public void WhenUserEntersPasswordInThePasswordTextboxAs(string password)
        {
            loginpage.EnterPassword(password);
        }

        [When(@"user clicks on Login button")]
        public void WhenUserClicksOnLoginButton()
        {
            loginpage.ClickLoginButton();
        }

        [When(@"user clicks on the logout button")]
        public void WhenUserClicksOnTheLogoutButton()
        {
            loginpage.ClickLogOutButton();
        }

        #endregion

        #region Then
        [Then(@"verify the user is successfully logged in")]
        public void ThenVerifyTheUserIsSuccessfullyLoggedIn()
        {
            Assert.IsTrue(GenericHelper.IsElemetPresent(By.Id("ctl00_logout")));
        }

        [Then(@"verify the user is successfully logged out")]
        public void ThenVerifyTheUserIsSuccessfullyLoggedOut()
        {
            Assert.IsTrue(GenericHelper.IsElemetPresent(By.Id("ctl00_MainContent_login_button")));
        }


        #endregion 



    }
}
