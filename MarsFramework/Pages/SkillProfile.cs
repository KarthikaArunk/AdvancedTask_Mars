using MarsAdvancedTask.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTask.Pages
{
    internal class SkillProfile
    {
        public SkillProfile()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
            //GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Skill");
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

        internal void NewSkill(int excelrow)
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Skill");

            //Click on  Skill Tab
            var wait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(SkillsTab));
            SkillsTab.Click();

            //Click on Add New button on Skill tab 
            wait.Until(ExpectedConditions.ElementToBeClickable(AddNewSkillBtn));
            AddNewSkillBtn.Click();

            var waitskill = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            waitskill.Until(ExpectedConditions.ElementToBeClickable(SkillTxtBox));

            //Enter new skill
            var newskilldatafromexcel = GlobalDefinitions.ExcelLib.ReadData(excelrow, "Skill");
            SkillTxtBox.SendKeys(newskilldatafromexcel);

            //Enter skill level
            var newskilllevelfromexcel = GlobalDefinitions.ExcelLib.ReadData(excelrow, "Level");
            SkillLevel.SendKeys(newskilllevelfromexcel);

            //Click on Add button on skill tab

            AddSkillBtn.Click();

        }

    }
}
