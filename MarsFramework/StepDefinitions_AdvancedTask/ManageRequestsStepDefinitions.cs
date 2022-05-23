using MarsAdvancedTask.Pages;
using System;
using TechTalk.SpecFlow;
using MarsAdvancedTask.Global;
using NUnit.Framework;

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
            var titlereceived = manageReqObj.Assertion_ReceivedRequests();
            Assert.IsTrue(titlereceived, "Received Requests are saved successfully");
        }
    }
}
