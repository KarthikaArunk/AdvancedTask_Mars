using MarsAdvancedTask.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace MarsAdvancedTask.Pages
{
    internal class Notifications_Skill
    {
        public Notifications_Skill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Notifications
        //[FindsBy(How = How.LinkText, Using = "Notification")]

        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/div")]
        private IWebElement NotificationLink { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='notification-section']/div[1]/div[2]/div/div/div[2]/span/div/div[2]/div/center/a")]
        //private IWebElement SeeAllNotifications { get; set; }

        [FindsBy(How = How.LinkText, Using = "See All...")]
        private IWebElement SeeAllNotifications { get; set; }

        //Click on Select All button
        //[FindsBy(How = How.LinkText, Using = "//*[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[1]")]

        [FindsBy(How = How.XPath, Using = "//*[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[1]")]
        private IWebElement SelectAllBtn { get; set; }

        //Click on Unselect All button
        [FindsBy(How = How.XPath, Using = "//*[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[2]")]
        private IWebElement UnSelectAllBtn { get; set; }

        //Click on Mark selection as read button
        [FindsBy(How = How.XPath, Using = "//*[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[4]")]
        private IWebElement MarkAsReadBtn { get; set; }

        //Click on Show Less button
        [FindsBy(How = How.XPath, Using = "//*[@id='notification-section]/div[2]/div/div/div[3]/div[2]/span/span/div/div[7]/div[1]/center/a")]
        private IWebElement ShowLessBtn { get; set; }

        //Click on Load More button
        
        [FindsBy(How = How.XPath, Using = "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[6]/div/center/a")]

        private IWebElement LoadMoreBtn { get; set; }
        
        //Click on Notification Link
        public void Notifications_SkillSwap()
        {
            Thread.Sleep(4000);
            var wait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(NotificationLink));
            NotificationLink.Click();

            var waitallnotification = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            waitallnotification.Until(ExpectedConditions.ElementToBeClickable(SeeAllNotifications));
            SeeAllNotifications.Click();

            Thread.Sleep(2000);

            var waitselectallbtn = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            waitselectallbtn.Until(ExpectedConditions.ElementToBeClickable(SelectAllBtn));
            SelectAllBtn.Click();

            Thread.Sleep(2000);

            var waitmarkasreadbtn = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(15));
            waitmarkasreadbtn.Until(ExpectedConditions.ElementToBeClickable(MarkAsReadBtn));
            MarkAsReadBtn.Click();

            Thread.Sleep(2000);

            SelectAllBtn.Click();

            Thread.Sleep(2000);

            var waitunselectallbtn = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(15));
            waitunselectallbtn.Until(ExpectedConditions.ElementToBeClickable(UnSelectAllBtn));
            UnSelectAllBtn.Click();
        }


        public void LoadMore_Notification()
        {
            Thread.Sleep(3000);
            //LoadMoreBtn.Click();

            var loadmorebtn = GlobalDefinitions.driver.FindElement(By.LinkText("Load More..."));
            loadmorebtn.Click();
        }

        public void ShowLess_Notification()
        {
            Thread.Sleep(4000);
            //ShowLessBtn.Click();
            var showlessbtn = GlobalDefinitions.driver.FindElement(By.LinkText("...Show Less"));
            showlessbtn.Click();
        }

        public void Notification_Assertion()
        {
            Thread.Sleep(3000);
            var loadmorebtn = GlobalDefinitions.driver.FindElement(By.LinkText("Load More..."));
            Assert.That(loadmorebtn.Text== "Load More...","Notifications are saved");
        }
    }
}
