using MarsAdvancedTask.Pages;
using TechTalk.SpecFlow;
using NUnit.Framework;
using MarsAdvancedTask.Global;
using OpenQA.Selenium.Chrome;

namespace MarsAdvancedTask
{
    [Binding]
    public class NotificationsStepDefinitions
    {
        [BeforeScenario("tag10")]
        public void Init()
        {
            BeforeAfterScenario.Inititalize();
        }

        [AfterScenario("tag10")]
        public void TearDown()
        {
            BeforeAfterScenario.TearDown();
        }

        Notifications_Skill NotificationObj;

        [When(@"\[I click on Notification]")]
        public void WhenIClickOnNotification()
        {
            NotificationObj = new Notifications_Skill();
            NotificationObj.Notifications_SkillSwap();
            NotificationObj.LoadMore_Notification();
            NotificationObj.ShowLess_Notification();
        }


        [Then(@"\[I should be able to see all notifications]")]
        public void ThenIShouldBeAbleToSeeAllNotifications()
        {
            NotificationObj.Notification_Assertion();
        }
    }
}
