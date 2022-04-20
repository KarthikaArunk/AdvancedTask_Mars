using MarsAdvancedTask.Pages;
using TechTalk.SpecFlow;
using NUnit.Framework;
using MarsAdvancedTask.Global;
using OpenQA.Selenium.Chrome;

namespace MarsAdvancedTask
{
    [Binding]
    
    public class SkillProfileStepDefinitions
    {
        [BeforeScenario("tag4")]
        public void Init()
        {
            BeforeAfterScenario.Inititalize();
        }

        [AfterScenario("tag4")]
        public void TearDown()
        {
            BeforeAfterScenario.TearDown();
        }


        SkillProfile skillObj;

               
        [When(@"\[I add new skill details from (.*)]")]
        public void WhenIAddNewSkillDetailsFrom(string p0)
        {
            skillObj = new SkillProfile();
            skillObj.NewSkill(int.Parse(p0));
        }

        [Then(@"\[Skill details should be saved]")]
        public void ThenSkillDetailsShouldBeSaved()
        {
            var skill = skillObj.GetSkill();
            var skillevel = skillObj.GetSkillLevel();
            Assert.IsNotNull(skill);
            Assert.IsNotNull(skillevel);
        }

    }
}
