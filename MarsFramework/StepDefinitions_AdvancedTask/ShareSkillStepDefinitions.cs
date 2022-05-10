using MarsAdvancedTask.Pages;
using TechTalk.SpecFlow;
using NUnit.Framework;
using MarsAdvancedTask.Global;
using OpenQA.Selenium.Chrome;

namespace MarsAdvancedTask
{
    [Binding]
   
    public class ShareSkillStepDefinitions
    {
        private string skilldata;
        private string addskillfailed;
        [BeforeScenario("tag7")]
        public void Init()
        {
            BeforeAfterScenario.Inititalize();
        }

        [AfterScenario("tag7")]
        public void TearDown()
        {
            BeforeAfterScenario.TearDown();
        }
        ShareSkill SkillObj;
        
        [When(@"\[I add new skill listings from (.*)]")]
        public void WhenIAddNewSkillListingsFrom(string p0)
        {
            SkillObj = new ShareSkill();
            skilldata = SkillObj.EnterShareSkill(int.Parse(p0));
        }

        [Then(@"\[Skill listings should be saved]")]
        public void ThenSkillListingsShouldBeSaved()
        {
            
            var rowcheck= SkillObj.ShareSkill_Assertion(skilldata);
            Assert.IsTrue(rowcheck, $"{skilldata} added successfully");
        }

        [When(@"\[I add few fields for new skill]")]
        public void WhenIAddFewFieldsForNewSkill()
        {
            SkillObj = new ShareSkill();
            addskillfailed = SkillObj.AddingNewSkillFailed();
        }

                
        [Then(@"\[An error message should be displayed]")]
        public void ThenAnErrorMessageShouldBeDisplayed()
        {
            var categorydata = SkillObj.NewSkillFailed_Assertion();
            Assert.That(categorydata == addskillfailed, "Successful Test");
        }
    }
}
