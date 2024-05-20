using BoDi;
using ImageUploadAuto.Hooks;
using ImageUploadAuto.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ImageUploadAuto.StepDefinitions
{
    [Binding]
    public class ImageUploadTestSteps
    {
        public IWebDriver driver;
        ImageUploadPage imageUploadPage;
        WebHooks _webhooks;

        public object SoftAssert { get; private set; }

        //BaseHooks _basehooks;

        public ImageUploadTestSteps(IObjectContainer objectContainer)
        {
            driver = objectContainer.Resolve<IWebDriver>();
            imageUploadPage = objectContainer.Resolve<ImageUploadPage>();
            //_basehooks = objectContainer.Resolve<BaseHooks>();
            _webhooks = objectContainer.Resolve<WebHooks>();
        }

        [Given(@"I navigate to Mentors Kid website")]
        public void GivenINavigateToMentorsKidWebsite()
        {
           driver.Navigate().GoToUrl(_webhooks.url);
        }

        [When(@"I click on Log in from the header section")]
        public void WhenIClickOnLogInFromTheHeaderSection()
        {
            imageUploadPage.ClickLoginMenu();

        }
        [When(@"I enter my user email")]
        public void WhenIEnterMyUserEmail()
        {
            imageUploadPage.EnterUserEmail();

            bool isElementVisible = driver.FindElement(By.Name("login[email]")).Displayed;
            Assert.That(isElementVisible, "The element with NAME 'login[email]' is not visible.");
            Console.WriteLine(isElementVisible);

            //bool isElementVisible = driver.FindElement(By.Name("login[email]")).Displayed;
            //Assert.IsFalse(isElementVisible, "The element with NAME 'login[email]' is visible, but it was expected to be not visible.");
            //Console.WriteLine(isElementVisible);
        }
         
        [When(@"I enter my user pasword")]
        public void WhenIEnterMyUserPasword()
        {
            imageUploadPage.EnterPassword();
 
        }
              
        [When(@"I click on submit button")]
        public void WhenIClickOnSubmitButton()
        {
            imageUploadPage.ClickSubmitBttn();
            

            //Verify the expected URL after login

            //string expectedUrl = "https://mentorskid.com/";
            string expectedUrl = "https://mentorskid.com/profile-settings/?tab=personal_details&useridentity=51";
            string actualUrl = driver.Url;
            Assert.That(actualUrl, Is.EqualTo(expectedUrl), "Actual page URL is not the same as expected");

            //Assert.AreEquals(expectedUrl, actualUrl, "Actual page URL is not the same as expected");

            //string actualTitle = driver.Title;
            //string notExpectedTitle = "MentorSkid profile";
            //Assert.AreNotEqual(notExpectedTitle, actualTitle, "The actual title is the Profile settings – MentorSkid, but it was expected to be different.");
            //Console.WriteLine(actualTitle);

            IWebElement myProfile = driver.FindElement(By.TagName("h4"));
            string actualText = myProfile.Text;
            Assert.That("My Profile", Is.EqualTo(actualText), $"Actual page TEXT is not the same as expected. Expected: 'My Profile', Actual: '{actualText}'");
            Console.WriteLine(actualText);

        }

        [When(@"I choose from profile settings section")]
        public void WhenIChooseFromProfileSettingsSection()
        {
            imageUploadPage.ClickProfileSetting();
            imageUploadPage.ClickProfileSetting2();
            imageUploadPage.ClickProfileSetting3();

        }

        [When(@"I click on upload photo button")]
        public async Task WhenIClickOnUploadPhotoButton()
        {   
            
            await imageUploadPage.ImageFileUpload()!;
            
        }

        [Then(@"image should be uploaded")]
        public void ThenImageShouldBeUploaded()
        {
            //imageUploadPage.ImageShouldBeUploaded().Should().BeTrue();
            Assert.That(imageUploadPage.IsImageUploaded(), "The image should be uploaded.");
            
        }


    }
}
