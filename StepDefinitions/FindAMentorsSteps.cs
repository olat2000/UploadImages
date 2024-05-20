using BoDi;
using ImageUploadAuto.Hooks;
using ImageUploadAuto.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ImageUploadAuto.StepDefinitions
{
    [Binding]
    public class FindAMentorsSteps
    {
        public IWebDriver driver;
        HeaderMenusPage headerMenusPage;
        WebHooks _webHooks;

        public FindAMentorsSteps(IObjectContainer objectContainer)
        {
            driver = objectContainer.Resolve<IWebDriver>();
            headerMenusPage = objectContainer.Resolve<HeaderMenusPage>();
            //_basehooks = objectContainer.Resolve<BaseHooks>();
            _webHooks = objectContainer.Resolve<WebHooks>();
        }

        [Given(@"user navigates to Mentorskid website")]
        public void GivenUserNavigatesToMentorskidWebsite()
        {
            driver.Navigate().GoToUrl(_webHooks.url);
        }

        [When(@"user click on Find a Mentor on the header section")]
        public void WhenUserClickOnFindAMentorOnTheHeaderSection()
        {
            headerMenusPage.ClickFIndaMentor();
        }

        [When(@"user validates the ""([^""]*)"" on the redirected page")]
        public void WhenUserValidatesTheOnTheRedirectedPage(string text)
        {
            
            IWebElement whatAreYouLookingFor = driver.FindElement(By.XPath("//input[@placeholder='What are you looking for?']"));
            string actualText1 = whatAreYouLookingFor.GetAttribute("placeholder");
            Assert.That("What are you looking for?", Is.EqualTo(actualText1), 
                $"Actual page TEXT is not the same as expected. Expected: 'What are you looking for?', Actual: '{actualText1}'");
            //Assert.AreEqual("What are you looking for?", actualText1, $"Actual page TEXT is not the same as expected. Expected: 'What are you looking for?', Actual: '{actualText1}'");
            Console.WriteLine(actualText1);
        }

        [When(@"user validates the ""([^""]*)"" text on the page")]
        public void WhenUserValidatesTheTextOnThePage(string text)
        {
            IWebElement selectCategory = driver.FindElement(By.XPath("(//span[@id='select2-parent-category-search-dropdown-container'])[1]"));
            string actualText2 = selectCategory.Text;
            Assert.That("Select category", Is.EqualTo(actualText2), $"Actual page TEXT is not the same as expected. Expected: 'Select category', Actual: '{actualText2}'");
            //Assert.AreEqual("Select category", actualText2, $"Actual page TEXT is not the same as expected. Expected: 'Select category', Actual: '{actualText2}'");

            Console.WriteLine(actualText2);
        }

        [When(@"user validates the ""([^""]*)"" too on the page")]
        public void WhenUserValidatesTheTooOnThePage(string text)
        {
            IWebElement startfromHere = driver.FindElement(By.XPath("//span[normalize-space()='Start from here']"));
            //"innerText" is used instead of "text" to get the visible text content of the element
            string actualText3 = startfromHere.GetAttribute("innerText");
            Assert.That("Start from here", Is.EqualTo(actualText3), $"Actual page TEXT is not the same as expected.Expected: 'Start from Here', Actual: '{actualText3}'");
            //Assert.AreEqual("Start from here", actualText3, $"Actual page TEXT is not the same as expected.Expected: 'Start from Here', Actual: '{actualText3}'");
            Console.WriteLine(actualText3);
        }

        [When(@"user select course from Category dropdown")]
        public void WhenUserSelectCourseFromCategoryDropdown()
        {
            headerMenusPage.SelectCategoryDropdown();
        }

        [When(@"user select price from High to Low or Low to High dropdown")]
        public void WhenUserSelectPriceFromHighToLowOrLowToHighDropdown()
        {
            headerMenusPage.SelectPriceDropdown();
        }

        [When(@"user click on search now button")]
        public void WhenUserClickOnSearchNowButton()
        {
            headerMenusPage.ClickSearchBttn();
        }
  
        [Then(@"Mentors with the selected prices should be displayed")]
        public void ThenMentorsWithTheSelectedPricesShouldBeDisplayed()
        {
            //Fluent Assertion
            //headerMenusPage.MentorsWithTheirPricesShouldBeDisplayed().Should().BeTrue();
            
            
            //NUnits Assertion 
            // Get the actual title of the webpage
            string actualUrl = "https://mentorskid.com/find-instructors/?keyword=&categories=quality-testing";

            // Define the expected title
            string expectedUrl = headerMenusPage.driver.Url;

            // Assert that the actual title is equal to the expected title
            Assert.That(expectedUrl, Is.EqualTo(actualUrl));
            //Assert.AreEqual(expectedUrl, actualUrl);
            Console.WriteLine(actualUrl);

        }

    }
}
