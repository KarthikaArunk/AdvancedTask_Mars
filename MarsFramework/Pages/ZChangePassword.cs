using MarsAdvancedTask.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;


namespace MarsAdvancedTask.Pages
{
    internal class ZChangePassword
    {
        public ZChangePassword()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Name Dropdownlist
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span")]
        private IWebElement NameDropdown { get; set; }
        
        //Click on Change Password

        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span/div/a[2]")]
        private IWebElement ChangePassworddropdown { get; set; }

        //Enter Current password

        [FindsBy(How = How.Name, Using = "oldPassword")]
        private IWebElement CurrentPasswordTxtBox { get; set; }

        //Enter New password
       
        [FindsBy(How = How.Name, Using = "newPassword")]
        private IWebElement NewPasswordTxtBox { get; set; }

        //Confirm New password
                
        [FindsBy(How = How.Name, Using = "confirmPassword")]
        private IWebElement ConfirmPasswordTxtBox { get; set; }

        //Click on Save Button

        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/div/div[2]/form/div[4]/button")]

       private IWebElement SavePasswordBtn { get; set; }

        //Click on SignOut button
        
        [FindsBy(How = How.LinkText, Using = "Sign Out")]
        private IWebElement SignOutBtn { get; set; }

        internal void Change_Password()
        {

            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ChangePassword");

            var wait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(NameDropdown));
            NameDropdown.Click();

            var waitchangepassword = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            waitchangepassword.Until(ExpectedConditions.ElementToBeClickable(ChangePassworddropdown));
            ChangePassworddropdown.Click();

            var currentpassword = GlobalDefinitions.ExcelLib.ReadData(2, "Current Password");
            CurrentPasswordTxtBox.SendKeys(currentpassword);

            var newpassword = GlobalDefinitions.ExcelLib.ReadData(2, "New Password");
            NewPasswordTxtBox.SendKeys(newpassword);

            var confirmpassword = GlobalDefinitions.ExcelLib.ReadData(2, "Confirm Password");
            ConfirmPasswordTxtBox.SendKeys(confirmpassword);

            var waitsave = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(5));
            waitsave.Until(ExpectedConditions.ElementToBeClickable(SavePasswordBtn));

            SavePasswordBtn.Click();

            
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            var waitsignout = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(30));
            waitsignout.Until(ExpectedConditions.ElementToBeClickable(SignOutBtn));
            SignOutBtn.Click();
        }
    }
}
