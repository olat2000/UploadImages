using BoDi;
using ImageUploadAuto.Hooks;
using ImageUploadAuto.PageObjects;
using ImageUploadAuto.Support;
using OpenQA.Selenium;

namespace ImageUploadAuto.StepDefinitions
{
    [Binding]
    public class MentosKidSignUpSteps
    {
        public IWebDriver driver;
        HeaderMenusPage headerMenusPage;
        WebHooks _webHooks;

        public MentosKidSignUpSteps(IObjectContainer objectContainer)
        {
            driver = objectContainer.Resolve<IWebDriver>();
            headerMenusPage = objectContainer.Resolve<HeaderMenusPage>();
            //_basehooks = objectContainer.Resolve<BaseHooks>();
            _webHooks = objectContainer.Resolve<WebHooks>();
        }

        [Given(@"user navigate to MentorsKid website")]
        public void GivenUserNavigateToMentorsKidWebsite()
        {
            headerMenusPage.driver.Navigate().GoToUrl(_webHooks.url);
            
        }

        [Given(@"user click on signup")]
        public void GivenUserClickOnSignup()
        {
           headerMenusPage.ClickSignUpMenu();
        }

        [Given(@"user enter first name")]
        public void GivenUserEnterFirstName()
        {
            headerMenusPage.EnterFName();
        }

        [Given(@"user enter last name")]
        public void GivenUserEnterLastName()
        {
            headerMenusPage.EnterLName();
        }

        [Given(@"user enter email address")]
        public void GivenUserEnterEmailAddress()
        {
           headerMenusPage.EnterUserEmail(string.Format(Images.emailAddress, new Random().Next(1, 999)));
        }

        [Given(@"user enter pword")]
        public void GivenUserEnterPword()
        {
            headerMenusPage.EnterUserPasword();
        }
        [Given(@"user select the options Mentor or Mentee")]
        public void GivenUserSelectTheOptionsMentorOrMentee()
        {
            headerMenusPage.SelectOption("value");
        }


        [Given(@"user check terms and conditions")]
        public void GivenUserCheckTermsAndConditions()
        {
            headerMenusPage.ClickTermsandConditon();
        }

        [When(@"user click on join now")]
        public void WhenUserClickOnJoinNow()
        {
            headerMenusPage.ClickJoinNowBttn(); 
        }

        [Then(@"user profile page should displayed")]
        public void ThenUserProfilePageShouldDisplayed()
        {

            headerMenusPage.UserProfilePageShouldDisplayed().Should().BeTrue();

        }
    }
}
