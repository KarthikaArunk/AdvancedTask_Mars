using MarsAdvancedTask.Pages;
using TechTalk.SpecFlow;
using NUnit.Framework;
using MarsAdvancedTask.Global;
using OpenQA.Selenium.Chrome;

namespace MarsAdvancedTask
{
    [Binding]
    
    public class AvailabilityHoursEarnTargetStepDefinitions
    {
        [BeforeScenario("tag2")]
        public void Init()
        {
            BeforeAfterScenario.Inititalize();
        }
        [AfterScenario("tag2")]
        public void TearDown()
        {
            BeforeAfterScenario.TearDown();
        }

        AvailabilityHoursEarnTarget TargetObj;

        [When(@"\[I add Availability, Hours and EarnTarget]")]
        public void WhenIAddAvailabilityHoursAndEarnTarget()
        {
            TargetObj = new AvailabilityHoursEarnTarget();
            TargetObj.Availability_Status();
            TargetObj.Hours_Status();
            TargetObj.EarnTaregt_Status();
        }

        [Then(@"\[Availability,Hours and EarnTarget should be saved]")]
        public void ThenAvailabilityHoursAndEarnTargetShouldBeSaved()
        {
            var newAvail = TargetObj.GetNewAvailabiltyData();
            var newHours = TargetObj.GetNewHoursData();
            var newEarn = TargetObj.GetNewEarnTargetData();

            //Assertion
            Assert.That(newAvail == "Part Time", "Availability doesn't match");
            Assert.That(newHours == "More than 30hours a week", "Hours doesn't match");
            Assert.That(newEarn == "Between $500 and $1000 per month", "EarnTarget doesn't match");
        }
    }
}
