using MarsAdvancedTask.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MarsAdvancedTask.Pages
{
    
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i")]
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }

        //Storing the table of listings
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table")]
        private IWebElement ListingTable { get; set; }

        //Select Credit
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input")]
        private IWebElement Credit { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        //Enter Edited Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        
                
        internal void ManageListings_Skill()
        {
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            var waitmanagelist = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            waitmanagelist.Until(ExpectedConditions.ElementToBeClickable(manageListingsLink));

            manageListingsLink.Click();
        }


        internal void ViewListing()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

            var waitmanagelist = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            waitmanagelist.Until(ExpectedConditions.ElementToBeClickable(manageListingsLink));

            manageListingsLink.Click();

            var waitview = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(15));
            waitview.Until(ExpectedConditions.ElementToBeClickable(view));

            view.Click();
        }

        
        internal string EditListing()
        {
            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "EditSkill");

            var waitmanagelistedit = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            waitmanagelistedit.Until(ExpectedConditions.ElementToBeClickable(manageListingsLink));

            manageListingsLink.Click();

            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            var waitskilltoedit = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(25));
            waitskilltoedit.Until(ExpectedConditions.ElementToBeClickable(edit));

            //Get data to be edited from Excel sheet
            var skilltoedit = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
            var editeddescriptionfromexcel = GlobalDefinitions.ExcelLib.ReadData(2, "EditedDescription");
            var editedcreditamountfromexcel = GlobalDefinitions.ExcelLib.ReadData(2, "EditedCreditAmount");

            IList<IWebElement> rows = ListingTable.FindElements(By.XPath("//tbody/tr"));

            for (int i = 1; i < rows.Count; i++)
            {
                var row = rows[i];

                if (ListingTable.FindElement(By.XPath($"//tr[{i}]/td[3]")).Text == skilltoedit)
                {
                    var editbutton = row.FindElement(By.XPath($"//tr[{i}]//td[8]//button[2]"));
                    editbutton.Click();

                    //Enter the edited description
                    Description.Clear();
                    Description.SendKeys(editeddescriptionfromexcel);

                    //Enter the edited credit amount
                    Credit.Click();
                    CreditAmount.Clear();
                    CreditAmount.SendKeys(editedcreditamountfromexcel);
                    Save.Click();
                    break;
                }
            }
            return editeddescriptionfromexcel;
        }

        public bool Edit_Assertion(string descrip)
        {

                //Assertion for Edit

                Thread.Sleep(2000);
                GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                 IList<IWebElement> editedrows = ListingTable.FindElements(By.XPath("//tbody/tr"));
                var rowfound = false;
                for (int i = 1; i < editedrows.Count; i++)
                {
                    if (ListingTable.FindElement(By.XPath($"//tr[{i}]/td[4]")).Text == descrip)
                    {
                        rowfound = true;
                        break;
                    }
                }
                return rowfound;
        }

       //Delete Listing
        public string DeleteListings()
        {
            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "DeleteSkill");

            var waitmanagelist = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            waitmanagelist.Until(ExpectedConditions.ElementToBeClickable(manageListingsLink));

            manageListingsLink.Click();

            var waitdelete = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(6));
            waitdelete.Until(ExpectedConditions.ElementToBeClickable(delete));

            var skilltodeletefromexcel = GlobalDefinitions.ExcelLib.ReadData(2, "Title");

            IList<IWebElement> rows = ListingTable.FindElements(By.XPath("//tbody/tr"));
            for (int i = 1; i < rows.Count; i++)
            {
                var row = rows[i];
                if (ListingTable.FindElement(By.XPath($"//tr[{i}]/td[3]")).Text == skilltodeletefromexcel)
                {
                    var deletebutton = row.FindElement(By.XPath($"//tr[{i}]/td[8]//button[3]"));
                    deletebutton.Click();
                    var yesbutton = clickActionsButton.FindElement(By.CssSelector(".positive"));
                    yesbutton.Click();
                    break;
                }
            }
            return skilltodeletefromexcel;
        }

        //Assertion for delete
        public bool Delete_Assertion(string deletedata)
        {
           //Assertion for delete

               
           GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
           IList<IWebElement> updatedrows = ListingTable.FindElements(By.XPath("//tbody/tr"));
           var rowfound = false;
           for (int i = 1; i < updatedrows.Count; i++)
           {
               if (ListingTable.FindElement(By.XPath($"//tr[{i}]/td[3]")).Text == deletedata)
               {

                        rowfound = true;
                        break;
               }
           }
            return rowfound;
            
        }
    }       
}

