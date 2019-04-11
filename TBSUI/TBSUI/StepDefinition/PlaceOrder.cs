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
    public sealed class PlaceOrder
    {
        OrderPage orderpage = new OrderPage(ObjectRepository.Driver);

        #region Given
        [Given(@"user clicks on Order button")]
        public void GivenUserClicksOnOrderButton()
        {
            orderpage.ClickOrderButton();
        }

        #endregion

        #region When

        [When(@"user provides the mandatory fields for the order")]
        public void WhenUserProvidesTheMandatoryFieldsForTheOrder(Table table)
        {
            foreach (var row in table.Rows)
            {
                orderpage.PlaceOrder(row["Product"], row["Quantity"], row["CustomerName"], row["Street"], row["City"], row["State"], row["Zip"], row["CardType"], row["CardNo"], row["ExpDate"]);
            }
        }

        [When(@"user clicks on the process button")]
        public void WhenUserClicksOnTheProcessButton()
        {
            orderpage.ClickProcessButton();
        }


        #endregion

        #region Then
        [Then(@"verify the order is placed")]
        public void ThenVerifyTheOrderIsPlaced()
        {
            IWebElement ele = ObjectRepository.Driver.FindElement(By.XPath("//*[@id='ctl00_MainContent_fmwOrder']/tbody/tr/td/div/strong"));
            string successmessagefromUI = ele.Text;
            Assert.IsTrue(successmessagefromUI.Contains("New order has been successfully added."));
        }

        [Then(@"user clicks on view all orders")]
        public void ThenUserClicksOnViewAllOrders()
        {
            orderpage.ClickViewAllOrderButton();
        }

        [Then(@"clicks on the edit button for the newly created order")]
        public void ThenClicksOnTheEditButtonForTheNewlyCreatedOrder()
        {
            orderpage.ClickEditButton();
        }

        [Then(@"update the quantity of the order to ""(.*)""")]
        public void ThenUpdateTheQuantityOfTheOrderTo(int p0)
        {
            orderpage.UpdateQuantity("3");
        }

        [Then(@"verify the order quantity is updated")]
        public void ThenVerifyTheOrderQuantityIsUpdated()
        {
            IWebElement ele = ObjectRepository.Driver.FindElement(By.XPath("/html/body/form/table/tbody/tr/td[2]/div[2]/div[3]/table/tbody/tr[2]/td[4]"));
            string successmessagefromUI = ele.Text;
            Assert.IsTrue(successmessagefromUI.Contains("3"));
        }

        [Then(@"clicks on the checkbox  for the newly created order")]
        public void ThenClicksOnTheCheckboxForTheNewlyCreatedOrder()
        {
            orderpage.ClickCheckBox();
        }

        [Then(@"clicks on the delete button")]
        public void ThenClicksOnTheDeleteButton()
        {
            orderpage.ClickDeleteButton();
        }

        [Then(@"verify the order is deleted")]
        public void ThenVerifyTheOrderIsDeleted()
        {
            IWebElement ele = ObjectRepository.Driver.FindElement(By.XPath("/html/body/form/table/tbody/tr/td[2]/div[2]/div[3]/table/tbody/tr[2]/td[2]"));
            string successmessagefromUI = ele.Text;
            Assert.IsTrue(successmessagefromUI != "Namresh");
        }





        #endregion
    }
}
