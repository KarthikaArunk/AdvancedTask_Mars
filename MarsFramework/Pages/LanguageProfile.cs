using MarsAdvancedTask.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;


namespace MarsAdvancedTask.Pages
{
    internal class LanguageProfile
    {
        public LanguageProfile()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
            //GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Languages");
        }

        //Click on Language Tab
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]")]
        private IWebElement LanguageTab { get; set; }

        //Click on AddNew button on Language Tab
        [FindsBy(How = How.XPath, Using ="//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")]
        private IWebElement AddNewLanguageBtn { get; set; }

        //Enter Language to LanguageTextBox
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")]
        private IWebElement LanguageTxtBox { get; set; }

        //Select LanguageLevel from DropdownBox
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select")]
        private IWebElement LanguageLevel { get; set; }

        //Click on Add button on Language Tab
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")]
        private IWebElement AddLanguageBtn { get; set; }

        //Get  Language from table
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")]
        private IWebElement LanguageFromTable { get; set; }

        //Get  Language level from table
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[2]")]
        private IWebElement LanguageLevelFromTable { get; set; }

        //Language table
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table")]
        private IWebElement LanguageListing { get; set; }

        public string NewLanguage(int excelrow)
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Languages");

            //Click on  Language Tab
            var wait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(LanguageTab));
            LanguageTab.Click();

            //Click on Add New button on language tab 
            wait.Until(ExpectedConditions.ElementToBeClickable(AddNewLanguageBtn));
            AddNewLanguageBtn.Click();

            //Enter new language
            var newlanguagedatafromexcel = GlobalDefinitions.ExcelLib.ReadData(excelrow, "Language");
            LanguageTxtBox.SendKeys(newlanguagedatafromexcel);
            LanguageTxtBox.Click();

            //Enter language level
            var waitlanguagelevel = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(6));
            waitlanguagelevel.Until(ExpectedConditions.ElementToBeClickable(LanguageLevel));

            var newlanguagelevelfromexcel = GlobalDefinitions.ExcelLib.ReadData(excelrow, "Level");
            LanguageLevel.Click();
            LanguageLevel.SendKeys(newlanguagelevelfromexcel);

            //Click on Add button on language tab

            AddLanguageBtn.Click();

            return newlanguagedatafromexcel;

        }

        public bool LanguageDetails(string language)
        {
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //return LanguageFromTable.Text;

            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            var wait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(LanguageListing));

            IList<IWebElement> rows = LanguageListing.FindElements(By.XPath("//tbody/tr"));
            var rowfound = false;
            for (int i = 1; i <= rows.Count; i++)
            {
                if (LanguageListing.FindElement(By.XPath($"//tbody[{i}]/tr/td[1]")).Text == language)
                {

                    rowfound = true;
                    break;
                }
            }

            return rowfound;            
            }
        }
    }
