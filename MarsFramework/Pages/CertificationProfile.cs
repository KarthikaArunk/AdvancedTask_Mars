using MarsAdvancedTask.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;


namespace MarsAdvancedTask.Pages
{
    internal class CertificationProfile
    {
        public CertificationProfile()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
            //GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
        }

        //Click on Certifications Tab
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]")]
        private IWebElement CertificationTab { get; set; }

        //Click on AddNew button on Certifications Tab
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div")]
        private IWebElement AddNewCertificationBtn { get; set; }

        //Enter Certificate to CertificateTextBox
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[1]/div/input")]
        private IWebElement CertificateTxtBox { get; set; }

        //Enter CertifiedFrom to CertifiedTextBox
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[1]/input")]
        private IWebElement CertifiedFromTxtBox { get; set; }

        //Select Year of certification from DropdownBox
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[2]/select")]
        private IWebElement CertificationYear { get; set; }

        //Click on Add button on Certification Tab
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]")]
        private IWebElement AddCertificationBtn { get; set; }

        internal void NewCertification()
        {

            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Certifications");

            //Click on  Language Tab
            var wait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(CertificationTab));
            CertificationTab.Click();

            AddNewCertificationBtn.Click();

            //Enter new Certificate
            var newcertificatedatafromexcel = GlobalDefinitions.ExcelLib.ReadData(2, "Certificate");
            CertificateTxtBox.SendKeys(newcertificatedatafromexcel);

            //Enter new CertificateFrom
            var newcertifiedfromdatafromexcel = GlobalDefinitions.ExcelLib.ReadData(2, "Certificate From");
            CertifiedFromTxtBox.SendKeys(newcertifiedfromdatafromexcel);

            //Enter new Certified Year
            var newcertifiedyearfromexcel = GlobalDefinitions.ExcelLib.ReadData(2, "Year");
            CertificationYear.SendKeys(newcertifiedyearfromexcel);

            AddCertificationBtn.Click();
        }

    }
}
