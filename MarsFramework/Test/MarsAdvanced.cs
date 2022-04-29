using MarsAdvancedTask.Pages;
using NUnit.Framework;


namespace MarsAdvancedTask
{
    public class MarsAdvanced
    {
        [TestFixture]
        [Parallelizable]
        [Category("Sprint1")]
        class User : Global.Base
        {
            //Description

            [Test, Order(1)]
            public void Test_Description(string descrip)
            {
                var descriptiontxt = new DescriptionProfile();
                
                //    descriptiontxt.Description();
                  descriptiontxt.Description_Add();
                descriptiontxt.GetDescription(descrip);
            }

            //Availability,Hours,EarnTarget

            [Test, Order(2)]
            
            public void Test_AvailabilityHoursEarnTarget()
            {
                var availability = new AvailabilityHoursEarnTarget();
                var hours = new AvailabilityHoursEarnTarget();
                var earntarget = new AvailabilityHoursEarnTarget();

                availability.Availability_Status();
                hours.Hours_Status();
                earntarget.EarnTaregt_Status();

            }

            //Language

            [Test, Order(3)]
            [TestCase(2)]
            [TestCase(3)]
            [TestCase(4)]
            public void Test_AddLanguage(int excelrow)
            {
                var newlanguage = new LanguageProfile();
                newlanguage.NewLanguage(excelrow);
            }

            //Skill

            [Test, Order(4)]
            [TestCase(2)]
            [TestCase(3)]
            [TestCase(4)]
            public void Test_AddSkill(int excelrow)
            {
                var newskill = new SkillProfile();
                newskill.NewSkill(excelrow);
            }
            //Education

            [Test, Order(5)]
            
            
            public void Test_AddEducation()
            {
                var neweducation = new EducationProfile();
                neweducation.EducationDetails();
            }

            //Certification

            [Test, Order(6)]
            
            
            public void Test_AddCertification()
            {
                var newcertification = new CertificationProfile();
                newcertification.NewCertification();
            }

            //ShareSkill

            [Test, Order(7)]
            [TestCase(2)]
            [TestCase(3)]
            [TestCase(4)]

            public void Test_Share_Skill(int excelrow)
            {
                var shareskill = new ShareSkill();
                shareskill.EnterShareSkill(excelrow);
            }

            //Adding New Skill Failed

            [Test, Order(8)]
            
            public void Test_AddingNewSkillFailed()
            {
                var addnewskillfailed = new ShareSkill();
                addnewskillfailed.AddingNewSkillFailed();
                addnewskillfailed.NewSkillFailed_Assertion();
            }

            //ManageListings

            [Test, Order(9)]

            public void Test_ManageListings()
            {
                var managelisting = new ManageListings();
                managelisting.ViewListing();
                managelisting.EditListing();
                managelisting.DeleteListings();
            }

            //ManageRequests

            [Test, Order(10)]

            public void Test_ManageRequests()
            {
                var managereqObj= new ManageRequests();
                managereqObj.SentRequests();
                managereqObj.ReceivedRequests();
                managereqObj.Assertion_ReceivedRequests();
            }

            //Notification

            [Test, Order(11)]
            public void Test_Notifications()
            {
                var notification = new Notifications_Skill();
                notification.Notifications_SkillSwap();
                var loadmorenotif = notification.LoadMore_Notification();
                notification.ShowLess_Notification();
                notification.Notification_Assertion(loadmorenotif);
            }

            //Chat

            [Test, Order(12)]
            public void Test_Chat()
            {
                var chatprofile = new Chat_Profile();
                var chatmessage = chatprofile.Chat_ProfilePage();
                chatprofile.Chat_Assertion(chatmessage);
            }

            //SearchSkills

            [Test, Order(13)]
            public void Test_SearchSkills()
            {
                var searchskills = new SearchSkills();
                searchskills.SearchSkillsBy_AllCategories();
                searchskills.SearchBy_Filter();
                searchskills.SearchBy_Skill();
                searchskills.SearchSkill_Assertion();
            }

            //ChangePassword

            [Test, Order(14)]
            public void Test_ChangePassword()
            {
                var changepassw = new ZChangePassword();
                changepassw.Change_Password();
            }
        }
    }
}
