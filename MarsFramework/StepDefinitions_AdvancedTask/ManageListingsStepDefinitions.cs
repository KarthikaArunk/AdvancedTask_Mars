using MarsAdvancedTask.Pages;
using TechTalk.SpecFlow;
using NUnit.Framework;
using MarsAdvancedTask.Global;

namespace MarsAdvancedTask
{
    [Binding]

    public class ManageListingsStepDefinitions
    {
        
        private string editeddescription;
        private string deletedata;
        [BeforeScenario("tag8")]
        public void Init()
        {
            BeforeAfterScenario.Inititalize();
        }

        [AfterScenario("tag8")]
        public void TearDown()
        {
            BeforeAfterScenario.TearDown();
        }

        ManageListings manageListingObj;

        
        [When(@"\[I click on Manage Listings tab]")]
        public void WhenIClickOnManageListingsTab()
        {
            manageListingObj = new ManageListings();
            manageListingObj.ManageListings_Skill();

            editeddescription = manageListingObj.EditListing();
            manageListingObj.DeleteListings();

        }

        [Then(@"\[I should be able to see all listings]")]
        public void ThenIShouldBeAbleToSeeAllListings()
        {
            var editdata = manageListingObj.Edit_Assertion(editeddescription);
            Assert.IsTrue(editdata, $"{editeddescription} edited successfully");

            var rowtodelete = manageListingObj.Delete_Assertion(deletedata);
            Assert.IsFalse(rowtodelete, "${deletedata} deleted successfully");
        }
    }
}
