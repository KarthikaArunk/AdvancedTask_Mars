using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTask.Pages
{
    internal class ManageRequests
    {
        public ManageRequests()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Requests Link
        //[FindsBy(How = How.LinkText, Using = "Manage Requests")]
        //[FindsBy(How = How.ClassName, Using = "ui dropdown link item")]
        //[FindsBy(How = How.XPath, Using = "//*[@id='message-section']/section[1]/div/div[1]")]
        [FindsBy(How = How.XPath, Using ="//*[@id='account-profile-section']/div/section[1]/div/div[1]")]
        private IWebElement ManageRequestsLink { get; set; }

        //Click on Received Requests Link
        [FindsBy(How = How.LinkText, Using = "Received Requests")]
        private IWebElement ReceivedRequestsLink { get; set; }

        //Click on Sent Requests Link
        [FindsBy(How = How.LinkText, Using = "Sent Requests")]
        private IWebElement SentRequestsLink { get; set; }

        internal void SentRequests()
        {
            var waitmanagerequest = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(15));
            waitmanagerequest.Until(ExpectedConditions.ElementToBeClickable(ManageRequestsLink));

            ManageRequestsLink.Click();

            var waitsentrequest = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            waitsentrequest.Until(ExpectedConditions.ElementToBeClickable(SentRequestsLink));

            SentRequestsLink.Click();

        }

        internal void ReceivedRequests()
        {
            var waitmanagerequest = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            waitmanagerequest.Until(ExpectedConditions.ElementToBeClickable(ManageRequestsLink));

            ManageRequestsLink.Click();

            var waitreceivedrequest = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            waitreceivedrequest.Until(ExpectedConditions.ElementToBeClickable(ReceivedRequestsLink));

            ReceivedRequestsLink.Click();

        }
        
    }
}
