using MarsAdvancedTask.Pages;
using TechTalk.SpecFlow;
using NUnit.Framework;
using MarsAdvancedTask.Global;

namespace MarsAdvancedTask
{
    [Binding]
    
    public class LanguagesProfileStepDefinitions
    {
        
        LanguageProfile languageObj;

        [BeforeScenario("tag3")]
        public void Init()
        {
            BeforeAfterScenario.Inititalize();
        }

        [AfterScenario("tag3")]
        public void TearDown()
        {
            BeforeAfterScenario.TearDown();
        }

        
        [When(@"\[I add new language details from (.*)]")]
        public void WhenIAddNewLanguageDetailsFrom(string p0)
        {
            languageObj = new LanguageProfile();
            languageObj.NewLanguage(int.Parse(p0));
        }

        [Then(@"\[Langauge details should be saved]")]
        public void ThenLangaugeDetailsShouldBeSaved()
        {
            var language = languageObj.GetLanguage();
            var languagelevel = languageObj.GetLanguageLevel();
            Assert.IsNotNull(language);
            Assert.IsNotNull(languagelevel);
        }

    }
}
