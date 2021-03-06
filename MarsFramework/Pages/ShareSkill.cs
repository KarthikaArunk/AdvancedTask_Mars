using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using MarsAdvancedTask.Global;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;

namespace MarsAdvancedTask.Pages
{
    public class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
        }

        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div/select")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
        private IWebElement ServiceTypeOptions { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        private IWebElement Days { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTime { get; set; }

        //Storing the endtime
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[3]/input")]
        private IWebElement EndTime { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement SkillTradeOption { get; set; }

        //Enter Skill Exchange Tag
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input")]
        private IWebElement SkillExchangeTag { get; set; }

        //Select Credit
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input")]
        private IWebElement Credit { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement ActiveOption { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        //Storing the table of listings
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table")]
        private IWebElement ListingTable { get; set; }

        //Enter Skill Details
        internal string EnterShareSkill(int excelrow)
        {
            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            //Click on  ShareSkill Button
            var wait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(ShareSkillButton));
            ShareSkillButton.Click();

            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            //Enter Title
            wait.Until(ExpectedConditions.ElementToBeClickable(Title));
            string titledatafromexcel = FillDataFromExcel(excelrow, "Title", Title);

            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Enter Description
            string description = FillDataFromExcel(excelrow, "Description", Description);

            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Select Category
            wait.Until(ExpectedConditions.ElementToBeClickable(CategoryDropDown));
            string categorydatafromexcel = FillDataFromExcel(excelrow, "Category", CategoryDropDown);

            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Select subcategory
            wait.Until(ExpectedConditions.ElementToBeClickable(SubCategoryDropDown));
            string subcategorydatafromexcel = FillDataFromExcel(excelrow, "SubCategory", SubCategoryDropDown);

            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Enter Tags
            wait.Until(ExpectedConditions.ElementToBeClickable(Tags));
            string tagsdatafromexcel = FillDataFromExcel(excelrow, "Tags", Tags);
            Tags.SendKeys("\n");

            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Select ServiceType Options
            wait.Until(ExpectedConditions.ElementToBeClickable(ServiceTypeOptions));
            ServiceTypeOptions.Click();

            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Select LocationType Options
            LocationTypeOption.Click();

            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Enter Startdate
            string startdatefromexcel = FillDataFromExcel(excelrow, "Startdate", StartDateDropDown);

            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Enter Enddate
            string enddatefromexcel = FillDataFromExcel(excelrow, "Enddate", EndDateDropDown);

            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Enter Days
            var daysdatafromexcel = GlobalDefinitions.ExcelLib.ReadData(excelrow, "Selectday");
            var daycheckbox = Days.FindElement(By.XPath($"//label[text()='{daysdatafromexcel}']/preceding-sibling::input"));
            daycheckbox.Click();

            var daylabel = Days.FindElement(By.XPath($"//label[text()='{daysdatafromexcel}']"));
            var parent = daylabel.FindElement(By.XPath("./parent::div/parent::div/parent::div"));

           
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Enter StartTime
            var starttimefromexcel = GlobalDefinitions.ExcelLib.ReadData(excelrow, "Starttime");
            StartTime = parent.FindElement(By.Name("StartTime"));
            StartTime.SendKeys(starttimefromexcel);

            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Enter Endtime
            var endtimefromexcel = GlobalDefinitions.ExcelLib.ReadData(excelrow, "Endtime");
            EndTime = parent.FindElement(By.Name("EndTime"));
            EndTime.SendKeys(endtimefromexcel);

            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Select SkillTrade
            SkillTradeOption.Click();

            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Enter SkillExchange Tag
            string skillexchangetagdatafromexcel = FillDataFromExcel(excelrow, "Skill-Exchange", SkillExchangeTag);
            SkillExchangeTag.SendKeys("\n");

            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Select Credit
            Credit.Click();

            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Enter Credit Amount
            string creditamountfromexcel = FillDataFromExcel(excelrow, "CreditAmount", CreditAmount);

            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Select Active option
            ActiveOption.Click();

            Save.Click();
            return titledatafromexcel;
        }

        public bool ShareSkill_Assertion(string titledata)
        {

            //Assertion for ShareSkill

            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            var wait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementToBeClickable(ListingTable));

            IList<IWebElement> rows = ListingTable.FindElements(By.XPath("//tbody/tr"));
            var rowfound = false;
            for (int i = 1; i < rows.Count; i++)
            {
                if (ListingTable.FindElement(By.XPath($"//tr[{i}]/td[3]")).Text == titledata)
                {

                    rowfound = true;
                    break;
                }
            }

            return rowfound;          
        }
    
        private string FillDataFromExcel(int excelrow, string columnName, IWebElement element)
        {
            var datafromexcel = GlobalDefinitions.ExcelLib.ReadData(excelrow, columnName);
            element.SendKeys(datafromexcel);
            return datafromexcel;
        }

        //Negative testcase 
        public string AddingNewSkillFailed()
        {
            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            var wait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(ShareSkillButton));
            ShareSkillButton.Click();

            //Enter Title
            var waitnewtitle = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(5));
            waitnewtitle.Until(ExpectedConditions.ElementToBeClickable(Title));

            var newtitledatafromexcel = GlobalDefinitions.ExcelLib.ReadData(5, "Title");
            Title.SendKeys(newtitledatafromexcel);

            //Enter Description
            var newdescriptiondatafromexcel = GlobalDefinitions.ExcelLib.ReadData(5, "Description");
            Description.SendKeys(newdescriptiondatafromexcel);

            var categorydata= GlobalDefinitions.ExcelLib.ReadData(5, "Category");

            Save.Click();
            return categorydata;
        }

        public string NewSkillFailed_Assertion()
        {
            //Assertion
            var categoryrequired = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div[2]"));
            return categoryrequired.Text;           
        }
    }
}
