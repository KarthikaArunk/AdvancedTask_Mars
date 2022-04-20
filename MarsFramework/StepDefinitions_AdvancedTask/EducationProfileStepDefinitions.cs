using MarsAdvancedTask.Pages;
using TechTalk.SpecFlow;
using NUnit.Framework;
using MarsAdvancedTask.Global;

namespace MarsAdvancedTask
{
    [Binding]
    
    public class EducationProfileStepDefinitions
    {
        [BeforeScenario("tag5")]
        public void Init()
        {
            BeforeAfterScenario.Inititalize();
        }

        [AfterScenario("tag5")]
        public void TearDown()
        {
            BeforeAfterScenario.TearDown();
        }

        EducationProfile educationObj;

        [When(@"\[I Add Education Details]")]
        public void WhenIAddEducationDetails()
        {
            educationObj = new EducationProfile();
            educationObj.EducationDetails();
        }

        [Then(@"\[Education details should be saved]")]
        public void ThenEducationDetailsShouldBeSaved()
        {
            var eduCountry = educationObj.GetCountryData();
            var educUniversity = educationObj.GetUniversityData();
            var educTitle = educationObj.GetTitleData();
            var educDegree = educationObj.GetDegreeData();
            var educYear = educationObj.GetYearData();

            Assert.That(eduCountry == "Australia", "Country doesn't match");
            Assert.That(educUniversity == "UQ", "University doesn't match");
            Assert.That(educTitle == "M.Tech", "Title doesn't match");
            Assert.That(educDegree == "Computer", "Degree doesn't match");
            Assert.That(educYear == "2010", "Year doesn't match");
        }
    }
}
