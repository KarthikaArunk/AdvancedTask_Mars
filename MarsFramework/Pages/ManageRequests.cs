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
            Thread.Sleep(4000);
            var waitmanagerequestreceived = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(50));
            waitmanagerequestreceived.Until(ExpectedConditions.ElementToBeClickable(ReceivedManageRequestsLink));

            ReceivedManageRequestsLink.Click();

            Thread.Sleep(2000);

            var waitreceivedrequest = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            waitreceivedrequest.Until(ExpectedConditions.ElementToBeClickable(ReceivedRequestsLink));

            ReceivedRequestsLink.Click();
            Thread.Sleep(2000);            
        }

        //Click on Sent Requests
        public void SentRequests()
        {
            Thread.Sleep(4000);
            var waitmanagerequest = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(15));
            waitmanagerequest.Until(ExpectedConditions.ElementToBeClickable(ManageRequestsLink));

            ManageRequestsLink.Click();

            var waitsentrequest = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            waitsentrequest.Until(ExpectedConditions.ElementToBeClickable(SentRequestsLink));

            SentRequestsLink.Click();

            Thread.Sleep(4000);                     
        }

        //Assertion for Sent Requests

        public void Assertion_SentRequests()
        {
            Thread.Sleep(2000);
            var waitsentrequesttable = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(20));
            waitsentrequesttable.Until(ExpectedConditions.ElementToBeClickable(SentRequestsTable));

            IList<IWebElement> rows = SentRequestsTable.FindElements(By.XPath("//tbody/tr"));
            var rowfound = false;
            for (int i = 1; i < rows.Count; i++)
            {
                if (SentRequestsTable.FindElement(By.XPath($"//tr[{i}]/td[2]")).Text == "Selenium")
                {

                    rowfound = true;
                    break;
                }
            }
            Assert.IsTrue(rowfound, "Sent Requests are saved successfully");
        }

        //Assertion for Received Requests

        public void Assertion_ReceivedRequests()
        {
            Thread.Sleep(2000);
           var waitsentrequesttable = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(20));
           waitsentrequesttable.Until(ExpectedConditions.ElementToBeClickable(ReceivedRequestsTable));

           IList<IWebElement> rows = ReceivedRequestsTable.FindElements(By.XPath("//tbody/tr"));
           var rowfound = false;
           for (int i = 1; i<rows.Count; i++)
           {
              if (ReceivedRequestsTable.FindElement(By.XPath($"//tr[{i}]/td[2]")).Text == "SQL")
                {

                   rowfound = true;
                    break;
                }
           }        
             Assert.IsTrue(rowfound, "Received Requests are saved successfully");
        }
    }
}
