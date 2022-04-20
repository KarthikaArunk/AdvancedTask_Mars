using MarsAdvancedTask.Pages;
using TechTalk.SpecFlow;
using NUnit.Framework;
using MarsAdvancedTask.Global;


namespace MarsAdvancedTask
{
    [Binding]
    
    public class CertificationProfileStepDefinitions
    {
        [BeforeScenario("tag6")]
        public void Init()
        {
            BeforeAfterScenario.Inititalize();
        }
        [AfterScenario("tag6")]
        public void TearDown()
        {
            BeforeAfterScenario.TearDown();
        }

        CertificationProfile certificationObj;

        
        [When(@"\[I add certification details]")]
        public void WhenIAddCertificationDetails()
        {
            certificationObj = new CertificationProfile();
            certificationObj.NewCertification();
        }


        [Then(@"\[certification details should be saved]")]
        public void ThenCertificationDetailsShouldBeSaved()
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
