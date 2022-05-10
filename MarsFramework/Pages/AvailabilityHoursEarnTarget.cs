
using MarsAdvancedTask.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;


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

        //Click on  HoursIcon 
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i")]
        private IWebElement HoursIcon { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select")]

        //[FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select")]
        private IWebElement HoursDropdown { get; set; }

        //Click on  EarnTarget Icon 
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i")]
        private IWebElement EarnTargetIcon { get; set; }

        //Click on  EarnTarget Dropdownbox
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select")]
        private IWebElement EarnTargetDropdown { get; set; }

        
        //Get  New Availability 
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span")]
        private IWebElement GetNewAvailability { get; set; }

        //Get  New Hours
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span")]
        private IWebElement GetNewHours { get; set; }

        //Get  New EarnTarget
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span")]
        private IWebElement GetNewEarnTarget { get; set; }



        public string Availability_Status()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "AvailHoursEarn");

            //Click on  AvailabilityIcon
                        
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            var wait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(AvailabilityIcon));
            AvailabilityIcon.Click();

            //Select  AvailabilityDropdown
           
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            AvailabilityDropdown.Click();
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            var availabilityfromexcel = GlobalDefinitions.ExcelLib.ReadData(2, "Availability");
            AvailabilityDropdown.Click();
            AvailabilityDropdown.SendKeys(availabilityfromexcel);
            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            return availabilityfromexcel;
        }

        
        public string Hours_Status()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "AvailHoursEarn");

            //Click on HoursIcon
            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            HoursIcon.Click();
            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            
            HoursDropdown.Click();

            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            
            var hoursfromexcel = GlobalDefinitions.ExcelLib.ReadData(2, "Hours");
            HoursDropdown.Click();
            HoursDropdown.SendKeys(hoursfromexcel);
            
            return hoursfromexcel;
        }

        public string GetNewAvailabiltyData()
        {
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            return GetNewAvailability.Text;
        }

        public string GetNewHoursData()
        {
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            return GetNewHours.Text;
        }

        public  string EarnTaregt_Status()
        {

            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "AvailHoursEarn");

            //Click on  EarnTarget Icon
            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            EarnTargetIcon.Click();

            //Click on EarnTargetDropdown
            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            EarnTargetDropdown.Click();
            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            var earntargetfromexcel = GlobalDefinitions.ExcelLib.ReadData(2, "EarnTarget");
            EarnTargetDropdown.Click();
            EarnTargetDropdown.SendKeys(earntargetfromexcel);
            return earntargetfromexcel;
        }


        public string GetNewEarnTargetData()
        {            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            return GetNewEarnTarget.Text;
        }
    }
}   
