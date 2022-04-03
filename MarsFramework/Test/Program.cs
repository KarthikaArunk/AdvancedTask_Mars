using MarsAdvancedTask.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace MarsAdvancedTask
{
    public class Program
    {
        [TestFixture]
        [Parallelizable]
        [Category("Sprint1")]
        class User : Global.Base
        {
            //[Test, Order(1)]
            //public void Test_Description()
            //{
            //    var descriptiontxt = new DescriptionProfile();
            //    descriptiontxt.Description();
            //}

            //[Test, Order(1)]
            //[TestCase(2)]
            //[TestCase(3)]
            //[TestCase(4)]

            //public void Test_Share_Skill(int excelrow)
            //{
            //    var shareskill = new ShareSkill();
            //    shareskill.EnterShareSkill(excelrow);
            //}

            //[Test, Order(1)]

            //public void Test_ViewListing()
            //{
            //    var managelisting = new ManageListings();
            //    managelisting.ViewListing();
            //}

            //[Test, Order(3)]
            //public void Test_EditListing()
            //{
            //    var managelisting = new ManageListings();
            //    managelisting.EditListing();
            //}


            //[Test, Order(4)]
            //public void Test_DeleteListing()
            //{
            //    var deletelisting = new ManageListings();
            //    deletelisting.DeleteListings();
            //}

            //[Test, Order(5)]
            //[TestCase(5)]
            //public void Test_AddingNewSkillFailed(int excelrow)
            //{
            //    var addnewskillfailed = new ShareSkill();
            //    addnewskillfailed.AddingNewSkillFailed(excelrow);
            //}

            //[Test, Order(2)]
            //[TestCase(2)]
            //[TestCase(3)]
            //[TestCase(4)]
            //public void Test_AddLanguage(int excelrow)
            //{
            //    var newlanguage = new LanguageProfile();
            //    newlanguage.NewLanguage(excelrow);
            //}

            //[Test, Order(3)]
            //[TestCase(2)]
            //[TestCase(3)]
            //[TestCase(4)]
            //public void Test_AddSkill(int excelrow)
            //{
            //    var newskill = new SkillProfile();
            //    newskill.NewSkill(excelrow);
            //}

            //[Test, Order(4)]
            //[TestCase(2)]
            ////[TestCase(3)]
            ////[TestCase(4)]
            //public void Test_AddEducation(int excelrow)
            //{
            //    var neweducation = new EducationProfile();
            //    neweducation.EducationDeatils(excelrow);
            //}

            //[Test, Order(5)]
            //[TestCase(2)]
            //[TestCase(3)]
            ////[TestCase(4)]
            //public void Test_AddCertification()
            //{
            //    var newcertification = new CertificationProfile();
            //    newcertification.NewCertification();
            //}

            //[Test, Order(1)]
            ////[TestCase(2)]
            //public void Test_AvailabilityHoursEarnTarget()
            //{
            //    var availhoursearn = new AvailabilityHoursEarnTarget();
            //    availhoursearn.Availability_Hours_Target();
            //}

            //[Test, Order(1)]
            //public void Test_Chat()
            //{
            //    var chatprofile = new Chat_Profile();
            //    chatprofile.Chat_ProfilePage();
            //}

            //[Test, Order(1)]
            //public void Test_SentRequest()
            //{
            //    var sentrequest = new ManageRequests();
            //    sentrequest.SentRequests();
            //}

            //[Test, Order(2)]
            //public void Test_ReceivedRequest()
            //{
            //    var receivedrequest = new ManageRequests();
            //    receivedrequest.ReceivedRequests();
            //}
            [Test, Order(1)]
            public void Test_SearchSkills()
            {
                var searchskills = new SearchSkills();
                searchskills.SearchSkillsBy_AllCategories();
            }

            //[Test, Order(1)]
            //public void Test_Notifications()
            //{
            //    var notification = new Notifications_Skill();
            //    notification.Notifications_SkillSwap();


            //[Test, Order(1)]
            //public void Test_ChangePassword()
            //{
            //    var changepassw = new ChangePassword();
            //    changepassw.Change_Password();
            //}
        }


    }
}
