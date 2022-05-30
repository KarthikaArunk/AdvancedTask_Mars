using MarsAdvancedTask.Pages;
using TechTalk.SpecFlow;
using MarsAdvancedTask.Global;


namespace MarsAdvancedTask
{
    [Binding]
    public class SearchSkillStepDefinitions
    {
        [BeforeScenario("tag12")]
        public void Init()
        {
            BeforeAfterScenario.Inititalize();
        }

        [AfterScenario("tag12")]
        public void TearDown()
        {
            BeforeAfterScenario.TearDown();
        }

        SearchSkills searchSkillObj;

        [When(@"\[I click on SearchIcon]")]
        public void WhenIClickOnSearchIcon()
        {
            searchSkillObj = new SearchSkills();
            searchSkillObj.SearchSkillsBy_AllCategories();
            searchSkillObj.SearchBy_Filter();
            searchSkillObj.SearchBy_Skill();
        }

        [Then(@"\[I should be able to see the skill]")]
        public void ThenIShouldBeAbleToSeeTheSkill()
        {
            searchSkillObj.SearchSkill_Assertion();
        }
    }
}
