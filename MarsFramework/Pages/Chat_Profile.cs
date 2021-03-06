using MarsAdvancedTask.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;



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

        //Click on Send button
        [FindsBy(How = How.XPath, Using = "//*[@id='btnSend']")]
        private IWebElement SendBtn { get; set; }

        //Chat data

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div/div[2]/div/div[2]/div/div/span/div[11]/div/div/span")]
        private IWebElement Chatdata { get; set; }


        public string Chat_ProfilePage()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Chat");

            var waitchat = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(20));
            waitchat.Until(ExpectedConditions.ElementToBeClickable(ChatLink));
            ChatLink.Click();

            var chatmessage = GlobalDefinitions.ExcelLib.ReadData(2, "Message");
            ChatTxtBox.SendKeys(chatmessage);
            SendBtn.Click();

            return chatmessage;
        }   
        
        public string Chat_Assertion()
        {
            GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            //return Chatdata.Text;
            var chatdata= GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div[2]/div/div/span/div[11]/div/div/span"));
            return chatdata.Text;            
        }
    }
}
