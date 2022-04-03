using MarsAdvancedTask.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;


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

        internal void EducationDeatils(int excelrow)
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Education");

            //Click on  Language Tab
            var wait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(EducationTab));
            EducationTab.Click();

            AddNewEducationBtn.Click();

            //Enter University
            var universitydatafromexcel = GlobalDefinitions.ExcelLib.ReadData(excelrow, "University");
            UniversityTxtBox.SendKeys(universitydatafromexcel);

            //Enter Country
            var countrydatafromexcel = GlobalDefinitions.ExcelLib.ReadData(excelrow, "Country");
            Country.SendKeys(countrydatafromexcel);

            //Enter Title
            var titledatafromexcel = GlobalDefinitions.ExcelLib.ReadData(excelrow, "Title");
            Title.SendKeys(titledatafromexcel);

            //Enter Title
            var degreedatafromexcel = GlobalDefinitions.ExcelLib.ReadData(excelrow, "Degree");
            DegreeTxtBox.SendKeys(degreedatafromexcel);

            //Enter Graduation Year
            var yeardatafromexcel = GlobalDefinitions.ExcelLib.ReadData(excelrow, "Year of Graduation");
            GraduationYear.SendKeys(yeardatafromexcel);

            AddEducationBtn.Click();
        }

    }
}
