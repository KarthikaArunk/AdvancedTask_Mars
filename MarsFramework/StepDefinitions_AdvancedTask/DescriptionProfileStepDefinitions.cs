using MarsAdvancedTask.Pages;
using TechTalk.SpecFlow;
using NUnit.Framework;
using MarsAdvancedTask.Global;
using OpenQA.Selenium.Chrome;

namespace MarsAdvancedTask
{
    [Binding]
    
    public class DescriptionProfileStepDefinitions
    {

        [BeforeScenario("tag1")]
        
        public void Init()
        {
            BeforeAfterScenario.Inititalize();
        }
        [AfterScenario("tag1")]
        public void TearDown()
        {
            BeforeAfterScenario.TearDown();
        }
        
        DescriptionProfile descriptionObj;

        
        [When(@"\[I add description]")]
        public void WhenIAddDescription()
        {
            descriptionObj = new DescriptionProfile();
            
            descriptionObj.Description_Add();
        }

        [Then(@"\[Description details should be saved]")]
        public void ThenDescriptionDetailsShouldBeSaved()
        {
            var descriptiontxt = descriptionObj.GetDescription();
            Assert.That(descriptiontxt == "Hi, I am Karthika. Craft making is my hobby.", "Description doesn't match");
        }
    }
}
