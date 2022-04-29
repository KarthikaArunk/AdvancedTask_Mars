using MarsAdvancedTask.Pages;
using TechTalk.SpecFlow;
using NUnit.Framework;
using MarsAdvancedTask.Global;

namespace MarsAdvancedTask
{
    [Binding]
    public class ProfileMarsStepDefinitions
    {
        [BeforeScenario("tagsignin","tagdescription", "tagavailability", "taglanguage", "tagskill", "tageducation", "tagcertification")]

        public void Init()
        {
            BeforeAfterScenario.Inititalize();
        }

        [AfterScenario("tagsignin","tagdescription", "tagavailability", "taglanguage", "tagskill", "tageducation", "tagcertification")]
        public void TearDown()
        {
            BeforeAfterScenario.TearDown();
        }

        DescriptionProfile descriptionObj;
        AvailabilityHoursEarnTarget TargetObj;
        LanguageProfile languageObj;
        SkillProfile skillObj;
        EducationProfile educationObj;
        CertificationProfile certificationObj;
        SignIn SignInObj;
        private string descrip;

        //SignIn
        
        [Given(@"\[I login successfully]")]
        public void GivenILoginSuccessfully()
        {
            SignInObj = new SignIn();
            SignInObj.LoginSteps();
        }

        //Add Description

        [When(@"\[I add description in profile]")]
        public void WhenIAddDescriptionInProfile()
        {
            descriptionObj = new DescriptionProfile();

           descrip = descriptionObj.Description_Add();
        }

        [Then(@"\[Description should be saved]")]
        public void ThenDescriptionShouldBeSaved()
        {
            //var descriptiontxt = descriptionObj.GetDescription();
            //Assert.That(descriptiontxt == "Hi, I am Karthika. Craft making is my hobby.", "Description doesn't match");
            descriptionObj.GetDescription(descrip);
        }

        //Add Availability,Hours and EarnTarget

        [When(@"\[I add Availability, Hours and EarnTarget in profile]")]
        public void WhenIAddAvailabilityHoursAndEarnTargetInProfile()
        {
            TargetObj = new AvailabilityHoursEarnTarget();
            TargetObj.Availability_Status();
            TargetObj.Hours_Status();
            TargetObj.EarnTaregt_Status();
        }

        [Then(@"\[Availability,Hours and EarnTarget details should be saved]")]
        public void ThenAvailabilityHoursAndEarnTargetDetailsShouldBeSaved()
        {
            var newAvail = TargetObj.GetNewAvailabiltyData();
            var newHours = TargetObj.GetNewHoursData();
            var newEarn = TargetObj.GetNewEarnTargetData();

            //Assertion
            Assert.That(newAvail == "Part Time", "Availability doesn't match");
            Assert.That(newHours == "More than 30hours a week", "Hours doesn't match");
            Assert.That(newEarn == "Between $500 and $1000 per month", "EarnTarget doesn't match");
        }

        //Add New Language

        [When(@"\[I add new language in profile from (.*)]")]
        public void WhenIAddNewLanguageInProfileFrom(string p0)
        {
            languageObj = new LanguageProfile();
            languageObj.NewLanguage(int.Parse(p0));
        }

        [Then(@"\[Langauge should be saved]")]
        public void ThenLangaugeShouldBeSaved()
        {
            var language = languageObj.GetLanguage();
            var languagelevel = languageObj.GetLanguageLevel();
            Assert.IsNotNull(language);
            Assert.IsNotNull(languagelevel);
        }

        //Add New Skill

        [When(@"\[I add new skill in profile from (.*)]")]
        public void WhenIAddNewSkillInProfileFrom(string p0)
        {
            skillObj = new SkillProfile();
            skillObj.NewSkill(int.Parse(p0));
        }

        [Then(@"\[Skill should be saved]")]
        public void ThenSkillShouldBeSaved()
        {
            var skill = skillObj.GetSkill();
            var skillevel = skillObj.GetSkillLevel();
            Assert.IsNotNull(skill);
            Assert.IsNotNull(skillevel);
        }

        //Add Education

        [When(@"\[I Add Education in profile]")]
        public void WhenIAddEducationInProfile()
        {
            educationObj = new EducationProfile();
            educationObj.EducationDetails();
        }

        [Then(@"\[Education should be saved]")]
        public void ThenEducationShouldBeSaved()
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

        //Adding Certification

        [When(@"\[I add certification in profile]")]
        public void WhenIAddCertificationInProfile()
        {
            certificationObj = new CertificationProfile();
            certificationObj.NewCertification();
        }

        [Then(@"\[certification should be saved]")]
        public void ThenCertificationShouldBeSaved()
        {
            var certificateName = certificationObj.GetCertificate();
            var certificationFrom = certificationObj.GetCertifiedFrom();
            var certificationYear = certificationObj.CertificateYear();

            Assert.That(certificateName == "ISTQB", "Certification doesn't match");
            Assert.That(certificationFrom == "ITB", "Certification from doesn't match");
            Assert.That(certificationYear == "2008", "Certification year doesn't match");
        }
    }
}
