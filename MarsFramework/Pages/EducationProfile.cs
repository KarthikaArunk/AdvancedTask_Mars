using MarsAdvancedTask.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace MarsAdvancedTask.Pages
{
    internal class EducationProfile
    {
        public EducationProfile()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
            //GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
        }

        //Click on Education Tab
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]")]
        private IWebElement EducationTab { get; set; }

        //Click on AddNew button on Education Tab
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div")]
        private IWebElement AddNewEducationBtn { get; set; }

        //Enter University to UniversityTextBox
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[1]/input")]
        private IWebElement UniversityTxtBox { get; set; }

        //Select Country from DropdownBox
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select")]
        private IWebElement Country { get; set; }

        //Select Title from DropdownBox
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select")]
        private IWebElement Title { get; set; }

        //Enter Degree to DegreeTextBox
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[2]/input")]
        private IWebElement DegreeTxtBox { get; set; }

        //Select Year of graduation from DropdownBox
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select")]
        private IWebElement GraduationYear { get; set; }

        //Click on Add button on Education Tab
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]")]
        private IWebElement AddEducationBtn { get; set; }

        //Get Country
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[1]")]
        private IWebElement GetCountry { get; set; }

        //Get University
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[2]")]
        private IWebElement GetUniversity { get; set; }

        //Get Title
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[3]")]
        private IWebElement GetTitle { get; set; }

        //Get Degree
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[4]")]
        private IWebElement GetDegree { get; set; }

        //Get Year
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[5]")]
        private IWebElement GetYear { get; set; }


        public (string country, string university,string title,string degree,string year) EducationDetails()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Education");

            //Click on  Language Tab
            var wait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(EducationTab));
            EducationTab.Click();

            AddNewEducationBtn.Click();

            //Enter Country
            var countrydatafromexcel = GlobalDefinitions.ExcelLib.ReadData(2, "Country");
            Country.SendKeys(countrydatafromexcel);

            //Enter University

            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            var universitydatafromexcel = GlobalDefinitions.ExcelLib.ReadData(2, "University");
            UniversityTxtBox.SendKeys(universitydatafromexcel);
                        

            //Enter Title
            var titledatafromexcel = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
            Title.SendKeys(titledatafromexcel);

            //Enter Degree
            var degreedatafromexcel = GlobalDefinitions.ExcelLib.ReadData(2, "Degree");
            DegreeTxtBox.SendKeys(degreedatafromexcel);

            //Enter Graduation Year
            var yeardatafromexcel = GlobalDefinitions.ExcelLib.ReadData(2, "Year of Graduation");
            GraduationYear.SendKeys(yeardatafromexcel);

            AddEducationBtn.Click();

            return (countrydatafromexcel, universitydatafromexcel, titledatafromexcel, degreedatafromexcel, yeardatafromexcel);
        }

        public string GetCountrydata()
        {
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            return GetCountry.Text;
        }

        public string GetUniversitydata()
        {
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            return GetUniversity.Text;
        }

        public string Gettitledata()
        {
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            return GetTitle.Text;
        }

        public string Getdegreedata()
        {
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            return GetDegree.Text;
        }

        public string Getyeardata()
        {
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            return GetYear.Text;
        }

    }
}
