using MarsAdvancedTask.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsAdvancedTask.Pages
{
    internal class SearchSkills
    {
        public SearchSkills()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
            //GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
        }

        //Find Search Skill Textbox
        
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[2]/input")]

        private IWebElement Skilltxtbox { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[1]/div[1]/i")]

        //Click on Search Icon
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[1]/i")]
        private IWebElement SearchIcon { get; set; }

        //Click Search Icon on Skill page
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[3]/div/section/div/div[1]/div[2]/i")]
        private IWebElement SearchSkillIcon { get; set; }

        //Select Sub Categories

        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[7]")]
        private IWebElement SearchSubCategories { get; set; }

        //Select QA Categories

        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[11]")]
        private IWebElement SearchQACategories { get; set; }


        //Select Filter - Online

        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[1]")]
        private IWebElement SearchFilterOnline { get; set; }

        //Click on skill 
        [FindsBy(How = How.LinkText, Using = "Web designing")]
        private IWebElement ClickOnSkill { get; set; }

        public void SearchSkillsBy_AllCategories()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SearchSkill");

            var waitsearchicon = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(15));
            waitsearchicon.Until(ExpectedConditions.ElementToBeClickable(SearchIcon));

            SearchIcon.Click();
        }          

      
        public void SearchBy_Filter()
        {
            //Thread.Sleep(3000);
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            var waitsearchfilter = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(30));
            waitsearchfilter.Until(ExpectedConditions.ElementToBeClickable(SearchFilterOnline));

            SearchFilterOnline.Click();
            SearchFilterOnline.SendKeys("\n");

            //Thread.Sleep(1000);
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        public void SearchBy_Skill()
        {

            //Thread.Sleep(3000);
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            var wait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(Skilltxtbox));

            //Thread.Sleep(3000);
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            var searchskill = GlobalDefinitions.ExcelLib.ReadData(2, "SkillToSearch");
            Skilltxtbox.SendKeys(searchskill);
            Skilltxtbox.SendKeys("\n");
            Skilltxtbox.Click();

            //Thread.Sleep(3000);
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
       public void SearchSkill_Assertion()
         {
            //Thread.Sleep(3000);
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            var wait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(ClickOnSkill));
            ClickOnSkill.Click();
         }
    }
}
