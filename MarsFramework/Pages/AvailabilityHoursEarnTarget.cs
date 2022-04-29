
using MarsAdvancedTask.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace MarsAdvancedTask.Pages
{
    internal class AvailabilityHoursEarnTarget
    {
        public AvailabilityHoursEarnTarget()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on  AvailabilityIcon 
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i")]
        private IWebElement AvailabilityIcon { get; set; }

        //Click on  Availability Dropdownbox
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select")]
        private IWebElement AvailabilityDropdown { get; set; }

        //Select  Availability Option
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select/option[2]")]
        private IWebElement AvailabilityOption { get; set; }

        //Click on  HoursIcon 
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i")]
        private IWebElement HoursIcon { get; set; }

        
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select")]

        ////[FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select")]
        private IWebElement HoursDropdown { get; set; }

        //Select  Hours Option
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select/option[3]")]
        private IWebElement HoursOption { get; set; }

        //Click on  EarnTarget Icon 
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i")]
        private IWebElement EarnTargetIcon { get; set; }

        //Click on  EarnTarget Dropdownbox
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select")]
        private IWebElement EarnTargetDropdown { get; set; }

        //Select  EarnTarget Option
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select/option[3]")]
        private IWebElement EarnTargetOption { get; set; }

        //Get  New Availability 
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span")]
        private IWebElement GetNewAvailability { get; set; }

        //Get  New Hours
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span")]
        private IWebElement GetNewHours { get; set; }

        //Get  New EarnTarget
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span")]
        private IWebElement GetNewEarnTarget { get; set; }



        internal void Availability_Status()
        {            
            //Click on  AvailabilityIcon

            //Thread.Sleep(5000);
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            var wait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(AvailabilityIcon));
            AvailabilityIcon.Click();

            //Select  AvailabilityDropdown
            //Thread.Sleep(2000);
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            AvailabilityDropdown.Click();
            AvailabilityOption.Click();

            //Thread.Sleep(4000);
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
        }

        internal void Hours_Status()
        {
            //Click on HoursIcon
            //Thread.Sleep(4000);
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            HoursIcon.Click();
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            //Thread.Sleep(3000);

            HoursDropdown.Click();

            //Thread.Sleep(2000);
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            HoursOption.Click();
        }

        internal void EarnTaregt_Status()
        {         
            //Click on  EarnTarget Icon
            //Thread.Sleep(2000);
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            EarnTargetIcon.Click();

            //Thread.Sleep(2000);
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            EarnTargetDropdown.Click();

            //Thread.Sleep(2000);
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            EarnTargetOption.Click();                      
        }

        public string GetNewAvailabiltyData()
        {
            //Thread.Sleep(2000);
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            return GetNewAvailability.Text;
        }

        public string GetNewHoursData()
        {
            //Thread.Sleep(2000);
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            return GetNewHours.Text;
        }

        public string GetNewEarnTargetData()
        {
            //Thread.Sleep(2000);
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            return GetNewEarnTarget.Text;
        }
    }
}   
