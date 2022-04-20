using MarsAdvancedTask.Pages;
using TechTalk.SpecFlow;
using NUnit.Framework;
using MarsAdvancedTask.Global;

namespace MarsAdvancedTask
{
    [Binding]
    public class ZChangePasswordStepDefinitions
    {
        [BeforeScenario("tag13")]
        public void Init()
        {
            BeforeAfterScenario.Inititalize();
        }
        [AfterScenario("tag13")]
        public void TearDown()
        {
            BeforeAfterScenario.TearDown();
        }

        ZChangePassword PasswordObj;
        SignIn SignInObj;


        [When(@"\[I change password]")]
        public void WhenIChangePassword()
        {
            PasswordObj = new ZChangePassword();
            PasswordObj.Change_Password();
        }


        [Then(@"\[New password should be saved]")]
        public void ThenNewPasswordShouldBeSaved()
        {
            //Login with new password

            SignInObj = new SignIn();
            SignInObj.LoginSteps();
        }
    }
}
