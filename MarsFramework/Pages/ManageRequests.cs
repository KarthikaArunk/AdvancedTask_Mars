using MarsAdvancedTask.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;


namespace MarsAdvancedTask.Pages
{
    public class ManageRequests
    {
        public ManageRequests()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Requests Link
        
        [FindsBy(How = How.XPath, Using ="//*[@id='account-profile-section']/div/section[1]/div/div[1]")]
        private IWebElement ManageRequestsLink { get; set; }

        //Click on Received Requests Link
        [FindsBy(How = How.LinkText, Using = "Received Requests")]
        private IWebElement ReceivedRequestsLink { get; set; }

        //Click on Sent Requests Link
        [FindsBy(How = How.LinkText, Using = "Sent Requests")]
        private IWebElement SentRequestsLink { get; set; }

               
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div/section[1]/div/div[1]")]
        private IWebElement ReceivedManageRequestsLink { get; set; }

        //Table of Sent requests

        [FindsBy(How = How.XPath, Using = "//*[@id='sent-request-section']/div[2]/div[1]/table")]
        private IWebElement SentRequestsTable { get; set; }

        //Table of Received requests

        [FindsBy(How = How.XPath, Using = "//*[@id='received-request-section']/div[2]/div[1]/table")]
        private IWebElement ReceivedRequestsTable { get; set; }

        //Click on Received Requests

        public void ReceivedRequests()
        {
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            var waitmanagerequestreceived = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(50));
            waitmanagerequestreceived.Until(ExpectedConditions.ElementToBeClickable(ReceivedManageRequestsLink));

            ReceivedManageRequestsLink.Click();
                        
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            var waitreceivedrequest = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            waitreceivedrequest.Until(ExpectedConditions.ElementToBeClickable(ReceivedRequestsLink));

            ReceivedRequestsLink.Click();
            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        //Click on Sent Requests
        public void SentRequests()
        {            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            var waitmanagerequest = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(15));
            waitmanagerequest.Until(ExpectedConditions.ElementToBeClickable(ManageRequestsLink));

            ManageRequestsLink.Click();

            var waitsentrequest = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            waitsentrequest.Until(ExpectedConditions.ElementToBeClickable(SentRequestsLink));

            SentRequestsLink.Click();

           
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
        }

        //Assertion for Sent Requests

        public bool Assertion_SentRequests()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SentRequest");

            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            var waitsentrequesttable = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(20));
            waitsentrequesttable.Until(ExpectedConditions.ElementToBeClickable(SentRequestsTable));

            var sentdatatosearch = GlobalDefinitions.ExcelLib.ReadData(2, "SentRequest");

            IList<IWebElement> rows = SentRequestsTable.FindElements(By.XPath("//tbody/tr"));
            var rowfound = false;
            for (int i = 1; i < rows.Count; i++)
            {
                if (SentRequestsTable.FindElement(By.XPath($"//tr[{i}]/td[2]")).Text == sentdatatosearch)
                {

                    rowfound = true;
                    break;
                }
            }

            return rowfound;
        }

        //Assertion for Received Requests

        public bool Assertion_ReceivedRequests()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ReceivedRequest");

           GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
           var waitsentrequesttable = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(20));
           waitsentrequesttable.Until(ExpectedConditions.ElementToBeClickable(ReceivedRequestsTable));

           var receiveddatatosearch = GlobalDefinitions.ExcelLib.ReadData(2, "ReceivedRequest");

            IList<IWebElement> rows = ReceivedRequestsTable.FindElements(By.XPath("//tbody/tr"));
           var rowfound = false;
           for (int i = 1; i<rows.Count; i++)
           {
              if (ReceivedRequestsTable.FindElement(By.XPath($"//tr[{i}]/td[2]")).Text == receiveddatatosearch)
                {

                   rowfound = true;
                    break;
                }
           }

            return rowfound;
        }
    }
}
