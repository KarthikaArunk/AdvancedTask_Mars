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
            public void Test_Description()
            {                
                DescriptionProfile DescriptionObj = new DescriptionProfile();

                var descripdata = DescriptionObj.Description_Add();
                var getdescrip = DescriptionObj.GetDescription();

                Assert.That(descripdata == getdescrip, "Description doesn't match");
            }

            //Availability,Hours,EarnTarget

            [Test, Order(2)]
            
            public void Test_AvailabilityHoursEarnTarget()
            {                
                AvailabilityHoursEarnTarget AvailObj = new AvailabilityHoursEarnTarget();

                var availdata = AvailObj.Availability_Status();
                var hoursdata = AvailObj.Hours_Status();
                var earndata = AvailObj.EarnTaregt_Status();

                var getavail = AvailObj.GetNewAvailabiltyData();
                var gethours = AvailObj.GetNewHoursData();
                var getearn = AvailObj.GetNewEarnTargetData();

                Assert.That(availdata == getavail, "Availability doesn't match");
                Assert.That(hoursdata == gethours, "Hours doesn't match");
                Assert.That(earndata == getearn, "EarnTarget doesn't match");
            }

            //Language

            [Test, Order(3)]
            [TestCase(2)]
            [TestCase(3)]
            [TestCase(4)]
            public void Test_AddLanguage(int excelrow)
            {                
                LanguageProfile LanguageObj = new LanguageProfile();

                var languagedata = LanguageObj.NewLanguage(excelrow);
                var languagefound = LanguageObj.LanguageDetails(languagedata);

                //Assertion
                Assert.IsTrue(languagefound, $"{languagedata} added successfully");
            }

            //Skill

            [Test, Order(4)]
            [TestCase(2)]
            [TestCase(3)]
            [TestCase(4)]
            public void Test_AddSkill(int excelrow)
            {                
                SkillProfile SkillObj = new SkillProfile();

                var skilldata = SkillObj.NewSkill(excelrow);
                var skillfound = SkillObj.GetSkillDetails(skilldata);

                //Assertion
                Assert.IsTrue(skillfound, $"{skilldata} added successfully");

            }
            //Education

            [Test, Order(5)]
            
            
            public void Test_AddEducation()
            {                
                EducationProfile EducationObj = new EducationProfile();

                var education = EducationObj.EducationDetails();
                var countrydata = EducationObj.GetCountrydata();
                var universitydata = EducationObj.GetUniversitydata();
                var titledata = EducationObj.Gettitledata();
                var degreedata = EducationObj.Getdegreedata();
                var yeardata = EducationObj.Getyeardata();

                Assert.That(education.country==countrydata,"Country doesn't match");
                Assert.That(education.university == universitydata, "University doesn't match");
                Assert.That(education.title == titledata, "Title doesn't match");
                Assert.That(education.degree == degreedata, "Degree doesn't match");
                Assert.That(education.year == yeardata, "Year doesn't match");              
            }

            //Certification

            [Test, Order(6)]
            
            
            public void Test_AddCertification()
            {                
                CertificationProfile CertificationObj = new CertificationProfile();

                var certif = CertificationObj.NewCertification();
                var certificdata = CertificationObj.GetCertificate();

                Assert.That(certif == certificdata, "Certificate doesn't match");
            }

            //ShareSkill

            [Test, Order(7)]
            [TestCase(2)]
            [TestCase(3)]
            [TestCase(4)]

            public void Test_Share_Skill(int excelrow)
            {                
                ShareSkill ShareSkillObj = new ShareSkill();

                var skilltitle = ShareSkillObj.EnterShareSkill(excelrow);
                var skillfound = ShareSkillObj.ShareSkill_Assertion(skilltitle);

                //Assertion
                Assert.IsTrue(skillfound, $"{skilltitle} added successfully");
            }

            //Adding New Skill Failed

            [Test, Order(8)]
            
            public void Test_AddingNewSkillFailed()
            {                
                ShareSkill ShareSkillObj = new ShareSkill();

                var newskillfail = ShareSkillObj.AddingNewSkillFailed();
                var categorydata = ShareSkillObj.NewSkillFailed_Assertion();

                //Assertion

                Assert.That(categorydata == newskillfail, "Successful Test");
            }

            //ManageListings

            [Test, Order(9)]

            public void Test_ManageListings()
            {
                
                ManageListings ManageListingObj = new ManageListings();

                ManageListingObj.ViewListing();
                var editdescrip = ManageListingObj.EditListing();
                var editassert = ManageListingObj.Edit_Assertion(editdescrip);
                var deletedata = ManageListingObj.DeleteListings();
                var deleteassert = ManageListingObj.Delete_Assertion(deletedata);

                //Assertion

                Assert.IsTrue(editassert, $"{editdescrip} edited successfully");
                Assert.IsFalse(deleteassert, "${deletedata} deleted successfully");
            }

            //ManageRequests

            [Test, Order(10)]

            public void Test_ManageRequests()
            {                
                ManageRequests ManageRequestsObj = new ManageRequests();

                ManageRequestsObj.SentRequests();
                ManageRequestsObj.ReceivedRequests();

                var titlereceived = ManageRequestsObj.Assertion_ReceivedRequests();

                Assert.IsTrue(titlereceived, "Received Requests are saved successfully");
            }

            //Notification

            [Test, Order(11)]
            public void Test_Notifications()
            {
                
                Notifications_Skill NotificationsObj = new Notifications_Skill();

                NotificationsObj.Notifications_SkillSwap();

                var loadmorenotif = NotificationsObj.LoadMore_Notification();

                NotificationsObj.ShowLess_Notification();

                var notif = NotificationsObj.Notification_Assertion();
                Assert.That(notif == loadmorenotif, "Notifications are saved");
            }

            //Chat

            [Test, Order(12)]
            public void Test_Chat()
            {
                
                Chat_Profile ChatObj = new Chat_Profile();

                var chatmessage = ChatObj.Chat_ProfilePage();
                var chatmsg = ChatObj.Chat_Assertion();

                //Assertion

                Assert.That(chatmessage == chatmsg, "Chat message not saved");
            }

            //SearchSkills

            [Test, Order(13)]
            public void Test_SearchSkills()
            {
                SearchSkills SearchSkillsObj = new SearchSkills();

                SearchSkillsObj.SearchSkillsBy_AllCategories();
                SearchSkillsObj.SearchBy_Filter();
                SearchSkillsObj.SearchBy_Skill();
                SearchSkillsObj.SearchSkill_Assertion();
            }

            //ChangePassword

            [Test, Order(14)]
            public void Test_ChangePassword()
            {
                
                ZChangePassword ChangePasswordObj = new ZChangePassword();

                ChangePasswordObj.Change_Password();
            }
        }
    }
}
