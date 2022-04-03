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
    internal class Chat_Profile
    {
        public Chat_Profile()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Chat
        [FindsBy(How = How.LinkText, Using = "Chat")]
        private IWebElement ChatLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='chatTextBox']")]
        private IWebElement ChatTxtBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='btnSend']")]
        private IWebElement SendBtn { get; set; }

        internal void Chat_ProfilePage()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Chat");

            var waitchat = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            waitchat.Until(ExpectedConditions.ElementToBeClickable(ChatLink));
            ChatLink.Click();

            var chatmessage = GlobalDefinitions.ExcelLib.ReadData(2, "Message");
            ChatTxtBox.SendKeys(chatmessage);
            SendBtn.Click();
        }       
    }
}
