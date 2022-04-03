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

        ////Select  Availability Option
        //[FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select/option[]")]
        //private IWebElement AvailabilityOption { get; set; }

        //Click on  HoursIcon 
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i")]
        private IWebElement HoursIcon { get; set; }

        //Click on  Hours Dropdownbox

        //[FindsBy(How = How.Name, Using = "availabiltyHour")]

        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select")]

        //[FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select")]
        private IWebElement HoursDropdown { get; set; }

        ////Select  Hours Option
        //[FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select/option[]")]
        //private IWebElement HoursOption { get; set; }

        //Click on  EarnTarget Icon 
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i")]
        private IWebElement EarnTargetIcon { get; set; }

        //Click on  EarnTarget Dropdownbox
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select")]
        private IWebElement EarnTargetDropdown { get; set; }

        ////Select  EarnTarget Option
        //[FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select/option[]")]
        //private IWebElement EarnTargetOption { get; set; }

        //Click on Availability update message
        ////[FindsBy(How = How.XPath, Using = "/html/body/div[1]/a")]
        //[FindsBy(How = How.XPath, Using = "//*[@class='ns-box-inner']")]

        //private IWebElement AvailabilityUpdateMessage { get; set; }


        internal void Availability_Hours_Target()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "AvailabilityHoursEarnTarget");

            //Click on  AvailabilityIcon
            var wait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(AvailabilityIcon));
            AvailabilityIcon.Click();

            //Select  AvailabilityDropdown
            var waitavaildropdown = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            waitavaildropdown.Until(ExpectedConditions.ElementToBeClickable(AvailabilityDropdown));
            AvailabilityDropdown.Click();
            //AvailabilityDropdown.Clear();

            var availabilitydatafromexcel = GlobalDefinitions.ExcelLib.ReadData(2, "Availability");
            AvailabilityDropdown.SendKeys(availabilitydatafromexcel);


            Thread.Sleep(1000);
            //var closebutton = GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[1]/a"));
            //closebutton.Click(); 


            //AvailabilityUpdateMessage.Click();

            ////Select Availability
            //var waitavailoption = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            //waitavailoption.Until(ExpectedConditions.ElementToBeClickable(AvailabilityOption));

            //var availabilitydatafromexcel = GlobalDefinitions.ExcelLib.ReadData(excelrow, "Availability");
            //AvailabilityOption.SendKeys(availabilitydatafromexcel);

            //Click on  HoursIcon
            //Select HoursDropdown
            //var waithoursdropdown = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            //waithoursdropdown.Until(ExpectedConditions.ElementToBeClickable(HoursDropdown));
            ////Thread.Sleep(2000);
            //HoursDropdown.Click();


            ////Select Hours
            //var hoursdatafromexcel = GlobalDefinitions.ExcelLib.ReadData(excelrow, "Hours");
            //HoursOption.SendKeys(hoursdatafromexcel);

            //Click on  EarnTarget Icon
            var waitearntarget = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            waitearntarget.Until(ExpectedConditions.ElementToBeClickable(EarnTargetIcon));
            EarnTargetIcon.Click();

            //Select  EarnTargetDropdown
            var waitearntargetdropdown = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            waitearntargetdropdown.Until(ExpectedConditions.ElementToBeClickable(EarnTargetDropdown));
            EarnTargetDropdown.Click();

            var earntargetfromexcel = GlobalDefinitions.ExcelLib.ReadData(2, "Earn Target");
            EarnTargetDropdown.SendKeys(earntargetfromexcel);

            var waithours = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(60));
            waithours.Until(ExpectedConditions.ElementToBeClickable(HoursIcon));
            HoursIcon.Click();
            //Thread.Sleep(3000);
            const string xpath = "/html/body/div[1]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select";
            //GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath(xpath), 30000);
            var dropdown = GlobalDefinitions.driver.FindElement(By.XPath(xpath));
            var hoursdatafromexcel = GlobalDefinitions.ExcelLib.ReadData(2, "Hours");
            //HoursDropdown.SendKeys(hoursdatafromexcel);
            dropdown.SendKeys(hoursdatafromexcel);
        }
    }
}   
