

namespace ImageUploadAuto.PageObjects
{
    public class HeaderMenusPage
    {
        public IWebDriver driver;
        public HeaderMenusPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Start of Locator
        IWebElement signUp => driver.FindElement(By.LinkText("Signup"));
        IWebElement FName => driver.FindElement(By.Name("registration[fname]"));
        IWebElement LName => driver.FindElement(By.Name("registration[lname]"));
        IWebElement userEmail => driver.FindElement(By.Name("registration[email]"));
        IWebElement userPasword => driver.FindElement(By.Name("registration[password]"));
        //IWebElement GetOptionElement(string value) => driver.FindElement(By.XPath($"(//label[normalize-space()='Mentor'])[1][.='{value}']"));
        IWebElement GetOptionElement(string value) => driver.FindElement(By.XPath($"(//label[contains(text(), 'Mentor')])[1]"));
             
        IWebElement termsCondition => driver.FindElement(By.CssSelector("label[for='tu-terms']"));
        IWebElement joinNow => driver.FindElement(By.CssSelector("a[class='tu-primbtn-lg tu-submit-registration'] span"));

        //WebElements for Find a Mentor
        private By findAMentor = By.LinkText("Find a Mentor");
        //private By categoryDropdown = By.CssSelector("#select2-parent-category-search-dropdown-container");
        IWebElement categoryDropdown => driver.FindElement(By.XPath("(//span[@class='select2-selection__placeholder'][normalize-space()='Select category'])[1]"));
        //private By priceDropdown = By.XPath("(//*[@class='select2-selection__rendered'])[1]");
        IWebElement priceDropdown => driver.FindElement(By.CssSelector("#select2-tu-instructor-search-sortby-container"));

        private By searchBttn = By.LinkText("Search now");

        #endregion End of locator

        #region Start of methods
        public void ClickSignUpMenu()
        {
            signUp.Click();
        }

        public void EnterFName()
        {
            LName.SendKeys(Images.firstName);
        }

        public void EnterLName()
        {
            FName.SendKeys(Images.lastName);
        }

        public void EnterUserEmail(string emailAddressValue)
        {
            userEmail.SendKeys(emailAddressValue);
        }
        public void EnterUserPasword()
        {
            userPasword.SendKeys(Images.password);
        }

        public void SelectOption(string value)
        {
            try
            {
                IWebElement optionElement = GetOptionElement(value);

                IJavaScriptExecutor js = driver as IJavaScriptExecutor;
                js.ExecuteScript("arguments[0].click();", optionElement);
            }
            catch (Exception ex)
            {
                // Handle any exceptions or log an error message
                Console.WriteLine($"Failed to select option '{value}': {ex.Message}");
                throw;
            }

            //IWebElement option = options(value);
            //IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            //js.ExecuteScript("arguments[0].click();", option);
        }
        public void ClickTermsandConditon()
        {
            termsCondition.Click();
        }
        public void ClickJoinNowBttn()
        {
            IWebElement element = driver.FindElement(By.CssSelector("a[class='tu-primbtn-lg tu-submit-registration'] span"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);

            //joinNow.Click();
        }
        public bool UserProfilePageShouldDisplayed()
        {
            return driver.Url.Contains("https://mentorskid.com/signup/");
        }

        public void ClickFIndaMentor()
        {
            driver.FindElement(findAMentor).Click();
            
        }
        public void SelectCategoryDropdown()
        {
            Thread.Sleep(3000);
            // Click on the dropdown to open it
            categoryDropdown.Click();
            
            IWebElement option = driver.FindElement(By.XPath("//*[@class='select2-search__field']"));
            option.SendKeys("Quality Testing");
            option.SendKeys(Keys.Enter);

        }
        public void SelectPriceDropdown()
        {

            // Find the dropdown
            IWebElement priceDropdown = driver.FindElement(By.CssSelector("#select2-tu-instructor-search-sortby-container"));
            // Find the options in the dropdown
            IList<IWebElement> options = priceDropdown.FindElements(By.TagName("li"));

            // Check if there is a second option
            if (options.Count > 1)
            {
                // Click the second option
                options[1].Click();
            }
            else
            {
                // Handle the case where there is no second option
                Console.WriteLine("There is no second option in the dropdown.");
            }


            // Click on the dropdown to open it
            //priceDropdown.Click();
            //Thread.Sleep(2000);
            //priceDropdown.Click();
            
            //IWebElement option = driver.FindElement(By.Id("select2-tu-instructor-search-sortby-container"));
            //option.SendKeys("Price low to high");
 
        }
        public void ClickSearchBttn()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Search now")));
            element.Click();
            //driver.FindElement(searchBttn).Click();
            Thread.Sleep(5000);
        }

        //public bool MentorsWithTheirPricesShouldBeDisplayed()
        //{
        //    return driver.Url.Contains("https://mentorskid.com/find-instructors/");
        //}
    }
    #endregion End of methods
}

