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
                var descriptiontxt = new DescriptionProfile();                
                var descripdata = descriptiontxt.Description_Add();
                var getdescrip = descriptiontxt.GetDescription();
                Assert.That(descripdata == getdescrip, "Description doesn't match");
            }

            //Availability,Hours,EarnTarget

            [Test, Order(2)]
            
            public void Test_AvailabilityHoursEarnTarget()
            {
                var availability = new AvailabilityHoursEarnTarget();
                var hours = new AvailabilityHoursEarnTarget();
                var earntarget = new AvailabilityHoursEarnTarget();

                var availdata= availability.Availability_Status();
                var hoursdata=  hours.Hours_Status();
                var earndata = earntarget.EarnTaregt_Status();

                var getavail = availability.GetNewAvailabiltyData();
                var gethours = hours.GetNewHoursData();
                var getearn = earntarget.GetNewEarnTargetData();

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
                var newlanguage = new LanguageProfile();
                var languagedata = newlanguage.NewLanguage(excelrow);
                var languagefound = newlanguage.LanguageDetails(languagedata);
                
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
                var newskill = new SkillProfile();
                var skilldata= newskill.NewSkill(excelrow);
                var skillfound= newskill.GetSkillDetails(skilldata);

                //Assertion
                Assert.IsTrue(skillfound, $"{skilldata} added successfully");

            }
            //Education

            [Test, Order(5)]
            
            
            public void Test_AddEducation()
            {
                var neweducation = new EducationProfile();
                
                var education = neweducation.EducationDetails(); ;
                
                var countrydata = neweducation.GetCountrydata();
                var universitydata = neweducation.GetUniversitydata();
                var titledata = neweducation.Gettitledata();
                var degreedata = neweducation.Getdegreedata();
                var yeardata = neweducation.Getyeardata();

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
                var newcertification = new CertificationProfile();
                var certif= newcertification.NewCertification();
                var certificdata = newcertification.GetCertificate();
                Assert.That(certif == certificdata, "Certificate doesn't match");
            }

            //ShareSkill

            [Test, Order(7)]
            [TestCase(2)]
            [TestCase(3)]
            [TestCase(4)]

            public void Test_Share_Skill(int excelrow)
            {
                var shareskill = new ShareSkill();
                var skilltitle = shareskill.EnterShareSkill(excelrow);
                var skillfound = shareskill.ShareSkill_Assertion(skilltitle);

                //Assertion
                Assert.IsTrue(skillfound, $"{skilltitle} added successfully");
            }

            //Adding New Skill Failed

            [Test, Order(8)]
            
            public void Test_AddingNewSkillFailed()
            {
                var addnewskillfailed = new ShareSkill();
                var newskillfail = addnewskillfailed.AddingNewSkillFailed();
                var categorydata = addnewskillfailed.NewSkillFailed_Assertion();

                //Assertion

                Assert.That(categorydata == newskillfail, "Successful Test");
            }

            //ManageListings

            [Test, Order(9)]

            public void Test_ManageListings()
            {
                var managelisting = new ManageListings();
                managelisting.ViewListing();
                var editdescrip =managelisting.EditListing();
                var editassert = managelisting.Edit_Assertion(editdescrip);

                var deletedata= managelisting.DeleteListings();
                var deleteassert = managelisting.Delete_Assertion(deletedata);

                //Assertion

                Assert.IsTrue(editassert, $"{editdescrip} edited successfully");
                Assert.IsFalse(deleteassert, "${deletedata} deleted successfully");
            }

            //ManageRequests

            [Test, Order(10)]

            public void Test_ManageRequests()
            {
                var managereqObj= new ManageRequests();
                managereqObj.SentRequests();
                managereqObj.ReceivedRequests();
                var titlereceived = managereqObj.Assertion_ReceivedRequests();

                Assert.IsTrue(titlereceived, "Received Requests are saved successfully");
            }

            //Notification

            [Test, Order(11)]
            public void Test_Notifications()
            {
                var notification = new Notifications_Skill();
                notification.Notifications_SkillSwap();
                var loadmorenotif = notification.LoadMore_Notification();
                notification.ShowLess_Notification();
                //notification.Notification_Assertion(loadmorenotif);
                var notif =notification.Notification_Assertion();
                Assert.That(notif == loadmorenotif, "Notifications are saved");
            }

            //Chat

            [Test, Order(12)]
            public void Test_Chat()
            {
                var chatprofile = new Chat_Profile();
                var chatmessage = chatprofile.Chat_ProfilePage();
                var chatmsg = chatprofile.Chat_Assertion();

                //Assertion

                Assert.That(chatmessage == chatmsg, "Chat message not saved");
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
