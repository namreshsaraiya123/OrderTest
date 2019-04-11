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
    public class OrderPage : PageBase
    {
        private IWebDriver driver;

        #region WebElement

        [FindsBy(How = How.LinkText, Using = "Order")]
        public IWebElement OrderButton;

        [FindsBy(How = How.LinkText, Using = "View all orders")]
        public IWebElement ViewAllOrderButton;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_fmwOrder_ddlProduct")]
        public IWebElement ProductDropDown;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_fmwOrder_txtQuantity")]
        public IWebElement QuantityTextbox;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_fmwOrder_txtName")]
        public IWebElement CustomerNameTextbox;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_fmwOrder_TextBox2")]
        public IWebElement StreetTextbox;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_fmwOrder_TextBox3")]
        public IWebElement CityTextbox;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_fmwOrder_TextBox4")]
        public IWebElement StateTextbox;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_fmwOrder_TextBox5")]
        public IWebElement ZipTextBox;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_fmwOrder_cardList_0")]
        public IWebElement VisaRadioButton;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_fmwOrder_cardList_1")]
        public IWebElement MasterCardRadioButton;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_fmwOrder_cardList_2")]
        public IWebElement AmericanExpressRadioButton;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_fmwOrder_TextBox6")]
        public IWebElement CardNumberTextBox;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_fmwOrder_TextBox1")]
        public IWebElement ExpDateTextBox;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_fmwOrder_InsertButton")]
        public IWebElement ProcessButton;


        [FindsBy(How = How.XPath, Using = "/html/body/form/table/tbody/tr/td[2]/div[2]/div[3]/table/tbody/tr[2]/td[13]/input")]
        public IWebElement EditButton;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_fmwOrder_UpdateButton")]
        public IWebElement UpdateButton;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_btnDelete")]
        public IWebElement DeleteButton;

        #endregion

        public OrderPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        public void ClickOrderButton()
        {
            OrderButton.Click();
            GenericHelper.WaitForWebElementInPage(By.Id("ctl00_MainContent_fmwOrder_InsertButton"), TimeSpan.FromSeconds(30));
        }

        public void ClickViewAllOrderButton()
        {
            ViewAllOrderButton.Click();
        }

        public void PlaceOrder(string productName, string quantity, string customerName, string street, string city, string state, string zip, string cardType, string cardNumber, string expdate)
        {

            ComboBoxHelper.SelectElementByText(ProductDropDown, productName);
            QuantityTextbox.SendKeys(quantity);
            CustomerNameTextbox.SendKeys(customerName);
            StreetTextbox.SendKeys(street);
            CityTextbox.SendKeys(city);
            StateTextbox.SendKeys(state);
            ZipTextBox.SendKeys(zip);
            if(cardType == "Visa")
            {
                RadioButtonHelper.ClickRadioButton(By.Id("ctl00_MainContent_fmwOrder_cardList_0"));
            }
            else if(cardType == "Mastercard")
            {
                RadioButtonHelper.ClickRadioButton(By.Id("ctl00_MainContent_fmwOrder_cardList_1"));
            }
            else if(cardType == "AmericanExpress")
            {
                RadioButtonHelper.ClickRadioButton(By.Id("ctl00_MainContent_fmwOrder_cardList_2"));
            }
            else
            {
                throw new Exception("No Such Card Type Exist");
            }
            CardNumberTextBox.SendKeys(cardNumber);
            ExpDateTextBox.SendKeys(expdate);

        }

        public void ClickProcessButton()
        {
            ProcessButton.Click();
        }

        public void ClickEditButton()
        {
            EditButton.Click();
        }

        public void UpdateQuantity(string quantity)
        {
            QuantityTextbox.Clear();
            QuantityTextbox.SendKeys(quantity);
            UpdateButton.Click();

        }

        public void ClickCheckBox()
        {
            CheckBoxHelper.CheckedCheckBox(By.Id("ctl00_MainContent_orderGrid_ctl02_OrderSelector"));
        }

        public void ClickDeleteButton()
        {
            DeleteButton.Click();
        }
    }
    
}
