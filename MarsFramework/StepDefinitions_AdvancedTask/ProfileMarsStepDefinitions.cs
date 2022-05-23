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
        private string descrip,skill, language, certification, educountry, eduuniversity, edudegree, edutitle, eduyear, availabilitydata,hours, earntarg;
              
        
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
            string descripdata = descriptionObj.GetDescription();
            Assert.That(descripdata == descrip, "Description doesn't match");
        }

        //Add Availability,Hours and EarnTarget

        [When(@"\[I add Availability, Hours and EarnTarget in profile]")]
        public void WhenIAddAvailabilityHoursAndEarnTargetInProfile()
        {
            TargetObj = new AvailabilityHoursEarnTarget();
            availabilitydata = TargetObj.Availability_Status();
            hours = TargetObj.Hours_Status();
            earntarg = TargetObj.EarnTaregt_Status();
        }

        [Then(@"\[Availability,Hours and EarnTarget details should be saved]")]
        public void ThenAvailabilityHoursAndEarnTargetDetailsShouldBeSaved()
        {
            
            string newavailability =TargetObj.GetNewAvailabiltyData();
            string newhours =TargetObj.GetNewHoursData();
            string etarget = TargetObj.GetNewEarnTargetData();

            //Assertion

            Assert.That(newavailability == availabilitydata, "Availability doesn't match");
            Assert.That(newhours == hours, "Hours doesn't match");
            Assert.That(etarget == earntarg, "EarnTarget doesn't match");
        }

        //Add New Language

        [When(@"\[I add new language in profile from (.*)]")]
        public void WhenIAddNewLanguageInProfileFrom(string p0)
        {
            languageObj = new LanguageProfile();
            language= languageObj.NewLanguage(int.Parse(p0));
        }

        [Then(@"\[Langauge should be saved]")]
        public void ThenLangaugeShouldBeSaved()
        {
            var rowfound = languageObj.LanguageDetails(language);
            Assert.IsTrue(rowfound, $"{language} added successfully");
        }

        //Add New Skill

        [When(@"\[I add new skill in profile from (.*)]")]
        public void WhenIAddNewSkillInProfileFrom(string p0)
        {
            skillObj = new SkillProfile();
            skill = skillObj.NewSkill(int.Parse(p0));
        }

        [Then(@"\[Skill should be saved]")]
        public void ThenSkillShouldBeSaved()
        {
             var rowfoundskill = skillObj.GetSkillDetails(skill);
            Assert.IsTrue(rowfoundskill, $"{skill} added successfully");
        }

        //Add Education

        [When(@"\[I Add Education in profile]")]
        public void WhenIAddEducationInProfile()
        {
            educationObj = new EducationProfile();
            (educountry, eduuniversity, edutitle, edudegree,eduyear) = educationObj.EducationDetails();
            
        }

        [Then(@"\[Education should be saved]")]
        public void ThenEducationShouldBeSaved()
        {
            string countrydata = educationObj.GetCountrydata();
            string univeritydata = educationObj.GetUniversitydata();
            string titledata = educationObj.Gettitledata();
            string degreedata = educationObj.Getdegreedata();
            string yeardata = educationObj.Getyeardata();

            Assert.That(countrydata == educountry, "Country doesn't match");
            Assert.That(univeritydata == eduuniversity, "University doesn't match");                     
            Assert.That(titledata == edutitle, "Title doesn't match");            
            Assert.That(degreedata == edudegree, "Degree doesn't match");            
            Assert.That(yeardata == eduyear, "Year doesn't match");
        }

        //Adding Certification

        [When(@"\[I add certification in profile]")]
        public void WhenIAddCertificationInProfile()
        {
            certificationObj = new CertificationProfile();
            certification= certificationObj.NewCertification();
        }

        [Then(@"\[certification should be saved]")]
        public void ThenCertificationShouldBeSaved()
        {
            string getcertific=  certificationObj.GetCertificate();
            Assert.That(getcertific == certification, "Certificate doesn't match");
        }
    }
}
