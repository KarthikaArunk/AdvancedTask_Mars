using MarsAdvancedTask.Pages;
using TechTalk.SpecFlow;
using NUnit.Framework;
using MarsAdvancedTask.Global;

namespace MarsAdvancedTask
{
    [Binding]
    
    public class ChatStepDefinitions
    {
        private string chatmsg;
        [BeforeScenario("tag11")]
        
        public void Init()
        {
            BeforeAfterScenario.Inititalize();
        }

        [AfterScenario("tag11")]
        public void TearDown()
        {
            BeforeAfterScenario.TearDown();
        }

        Chat_Profile chatObj;

        
        [When(@"\[I click on Chat link on home page]")]
        public void WhenIClickOnChatLinkOnHomePage()
        {
            chatObj = new Chat_Profile();
            chatmsg = chatObj.Chat_ProfilePage();
        }

        [Then(@"\[I should be able to send message]")]
        public void ThenIShouldBeAbleToSendMessage()
        {
            chatObj.Chat_Assertion(chatmsg);
        }
    }
}
