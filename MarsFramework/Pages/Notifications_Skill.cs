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

        //Click on Delete selection button
        [FindsBy(How = How.XPath, Using = "//*[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[3]]
        private IWebElement DeleteSelectionBtn { get; set; }


        internal void Notifications_SkillSwap()
        {
            var wait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(NotificationLink));
            NotificationLink.Click();

            var waitallnotification = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            waitallnotification.Until(ExpectedConditions.ElementToBeClickable(SeeAllNotifications));
            SeeAllNotifications.Click();

            Thread.Sleep(2000);

            var waitselectallbtn = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            waitselectallbtn.Until(ExpectedConditions.ElementToBeClickable(SelectAllBtn));
            SelectAllBtn.Click();

            var waitmarkasreadbtn = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(15));
            waitmarkasreadbtn.Until(ExpectedConditions.ElementToBeClickable(MarkAsReadBtn));
            MarkAsReadBtn.Click();

            SelectAllBtn.Click();

            var waitunselectallbtn = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(15));
            waitunselectallbtn.Until(ExpectedConditions.ElementToBeClickable(UnSelectAllBtn));
            UnSelectAllBtn.Click();

            

        }
    }
}
