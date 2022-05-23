using MarsAdvancedTask.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace MarsAdvancedTask.Pages
{
    internal class SkillProfile
    {
        public SkillProfile()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Skills Tab
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")]
        private IWebElement SkillsTab { get; set; }

        //Click on AddNew button on Skills Tab
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")]
        private IWebElement AddNewSkillBtn { get; set; }

        //Enter Skill to SkillTextBox
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input")]
        private IWebElement SkillTxtBox { get; set; }

        //Select SkillLevel from DropdownBox
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select")]
        private IWebElement SkillLevel { get; set; }

        //Click on Add button on Skill Tab
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]")]
        private IWebElement AddSkillBtn { get; set; }

        //Skill table

        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table")]
        private IWebElement SkillListing { get; set; }

        //Get Skill from Table
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]")]
        private IWebElement SkillFromTable { get; set; }

        //Get SkillLevel 
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[2]")]
        private IWebElement SkillLevelFromTable { get; set; }

        public string NewSkill(int excelrow)
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Skill");

            //Click on  Skill Tab
           
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            SkillsTab.Click();
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            

            //Click on Add New button on Skill tab 
            AddNewSkillBtn.Click();

            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var waitskill = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            waitskill.Until(ExpectedConditions.ElementToBeClickable(SkillTxtBox));

            //Thread.Sleep(1000);
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Enter new skill
            var newskilldatafromexcel = GlobalDefinitions.ExcelLib.ReadData(excelrow, "Skill");
            SkillTxtBox.SendKeys(newskilldatafromexcel);

            //Enter skill level
            var newskilllevelfromexcel = GlobalDefinitions.ExcelLib.ReadData(excelrow, "Level");
            SkillLevel.SendKeys(newskilllevelfromexcel);

            //Click on Add button on skill tab

            AddSkillBtn.Click();

            return newskilldatafromexcel;
            
        }

        public bool GetSkillDetails(string skill)
        {            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            
            var wait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(SkillListing));

            IList<IWebElement> rows = SkillListing.FindElements(By.XPath("//tbody/tr"));
            var rowfound = false;
            for (int i = 1; i <= rows.Count; i++)
            {
                if (SkillListing.FindElement(By.XPath($"//tbody[{i}]/tr/td[1]")).Text == skill)
                {

                    rowfound = true;
                    break;
                }
            }
            return rowfound;                       
        }

    }
}
