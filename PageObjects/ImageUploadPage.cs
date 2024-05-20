namespace ImageUploadAuto.PageObjects
{
    public class ImageUploadPage
    {
        public IWebDriver? driver;
        WebDriverWait wait;
       
        public ImageUploadPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Start of locator

        //IWebElement logIn => driver.FindElement(By.XPath("//a[normalize-space()='Login']"));
        private By logIn = By.XPath("//a[normalize-space()='Login']");
   
        //IWebElement userEmail => driver!.FindElement(By.Name("login[email]"));
        private By userEmail = By.Name("login[email]");
        //IWebElement pasword => driver!.FindElement(By.Name("login[password]"));
        private By pasword = By.Name("login[password]");
        IWebElement submitBttn => driver!.FindElement(By.XPath("//i[@class='icon icon-arrow-right']"));
        //private By submitBttn = By.XPath("//i[@class='icon icon-arrow-right']");
        //IWebElement uploadPhoto => driver!.FindElement(By.Id(""));
        private By photoUpload = By.CssSelector(".icon.icon-camera");
        private By saveImage = By.Id("save-profile-img");
        public By uploadedImage = By.Id("profile-avatar");
        IWebElement profileSetting => driver!.FindElement(By.LinkText("Area of Expertise"));
        //public By profile-setting = By.XPath("//span[contains(text(),'My calendar')]");
        IWebElement profileSetting2 => driver.FindElement(By.CssSelector("a[id='bookings-tab'] span"));
        IWebElement profileSetting3 => driver!.FindElement(By.Id("mentor-tab"));

        #endregion End of locator

        #region Start of methods
        public void ClickLoginMenu()
        {
            Thread.Sleep(2000);
            driver!.FindElement(logIn).Click();
            //wait.Until(x => logIn).Click();
        }
        public void EnterUserEmail()
        {
            Thread.Sleep(2000);
            driver!.FindElement(pasword).Click();
            driver!.FindElement(pasword).Clear();
            driver!.FindElement(userEmail).SendKeys("unitechplc2525@yahoo.com");
            //wait.Until(x => userEmail).SendKeys("unitechplc2525@yahoo.com");
        }

        public void EnterPassword()
        {
            Thread.Sleep(2000);
            driver!.FindElement(pasword).Click();
            driver!.FindElement(pasword).Clear();
            driver!.FindElement(pasword).SendKeys("awesomeGod");
            //wait.Until(x => pasword).SendKeys("awesomeGod");

        }
        public void ClickSubmitBttn()
        {
            driver!.UseIJavaScroll(submitBttn);
            Thread.Sleep(2000);
            submitBttn.Click();
            //Thread.Sleep(2000);
            //driver!.FindElement(submitBttn).Click();
            //wait.Until(x => submitBttn).Click();
            Thread.Sleep(3000);
        }
        //public void ClickUploadButton()
        //{
        //    driver.Navigate().Refresh();
        //    Thread.Sleep(5000);
        //    driver!.FindElement(uploadImage).SendKeys("C:\\TrainingAutomation\\ImageUploadAuto\\TestData\\Prepmajor_Image.jpg");

        //var image = driver.FindElement(By.CssSelector(".icon.icon-camera"));
        //var filePath = Directory.GetCurrentDirectory() + "\\TestData\\warrior.jpeg";
        //image.SendKeys(filePath);
        //}

        public async Task ImageFileUpload()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(photoUpload));
            element.Click();
            //driver?.FindElement(photoUpload).Click();
            await UploadImage.FileUpload("Script.exe", Images.img3);
            IWebElement ele = wait.Until(ExpectedConditions.ElementToBeClickable(saveImage));
            ele.Click();
            //driver?.FindElement(saveImage).Click();
        }

        public bool IsImageUploaded()
        {
            return driver!.Url.Contains("https://mentorskid.com/");
            //https://mentorskid.com/profile-settings/?tab=personal_details&useridentity=51
        }
        public void ClickProfileSetting()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Area of Expertise")));
            //IWebElement element = driver!.FindElement(By.LinkText("Area of Expertise"));
            ((IJavaScriptExecutor)driver!).ExecuteScript("arguments[0].click();", element);
            
            //driver!.FindElement(expertise).Click();
            //wait.Until(x => submitBttn).Click();
        }
        public void ClickProfileSetting2()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[id='bookings-tab'] span")));
            //IWebElement element = driver!.FindElement(By.CssSelector("a[id='bookings-tab'] span"));
            ((IJavaScriptExecutor)driver!).ExecuteScript("arguments[0].click();", element);   
        }
        public void ClickProfileSetting3()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("mentor-tab")));
            //IWebElement element = driver!.FindElement(By.Id("mentor-tab")));
            ((IJavaScriptExecutor)driver!).ExecuteScript("arguments[0].click();", element);
        }
    }
    #endregion End of methods
}

