

using MarsAdvancedTask.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace MarsAdvancedTask.Pages
{
    public class DescriptionProfile
    {
        public DescriptionProfile()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Description Write Icon
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i")]
        private IWebElement DescriptionWriteIcon { get; set; }

        //Click on Description Textbox
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea")]
        private IWebElement DescriptionTxtBox { get; set; }

        //Click on Description Save button
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button")]
        private IWebElement DescriptionSaveBtn { get; set; }

        //Get text from Description Textbox
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea")]
        private IWebElement GetDescriptionTxt { get; set; }

        //Add Description
        public void Description_Add()
        {
             //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "DescriptionProfile");

            Thread.Sleep(2000);

            var waitdescriptionicon = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            waitdescriptionicon.Until(ExpectedConditions.ElementToBeClickable(DescriptionWriteIcon));

            DescriptionWriteIcon.Click();

            var waitdescriptiontxtbox = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            waitdescriptiontxtbox.Until(ExpectedConditions.ElementToBeClickable(DescriptionTxtBox));
            DescriptionTxtBox.Clear();

            var description = GlobalDefinitions.ExcelLib.ReadData(2, "Description");
            
            DescriptionTxtBox.SendKeys(description);

            DescriptionSaveBtn.Click();
        }

        public string GetDescription()
        {
            return GetDescriptionTxt.Text;
        }
    }
}
