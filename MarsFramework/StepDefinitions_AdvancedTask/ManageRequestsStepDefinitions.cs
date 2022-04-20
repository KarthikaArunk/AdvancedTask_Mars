using MarsAdvancedTask.Pages;
using System;
using TechTalk.SpecFlow;
using MarsAdvancedTask.Global;


namespace MarsAdvancedTask
{
    [Binding]

    public class ManageRequestsStepDefinitions
    {
        [BeforeScenario("tag9")]
        public void Init()
        {
            BeforeAfterScenario.Inititalize();
        }

        [AfterScenario("tag9")]
        public void TearDown()
        {
            BeforeAfterScenario.TearDown();
        }

        ManageRequests manageReqObj;

        
        [When(@"\[I click on Manage Requests]")]
        public void WhenIClickOnManageRequests()
        {
            manageReqObj = new ManageRequests();
            manageReqObj.SentRequests();
            manageReqObj.ReceivedRequests();
        }

        [Then(@"\[I should be able to see received and sent requests]")]
        public void ThenIShouldBeAbleToSeeReceivedAndSentRequests()
        {
            manageReqObj.Assertion_ReceivedRequests();
           
        }
    }
}
