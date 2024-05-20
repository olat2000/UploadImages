using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System.ComponentModel;
using TechTalk.SpecFlow;

namespace ImageUploadAuto.Hooks
{
    [Binding]
    public class WebHooks
    {
        private IWebDriver _driver;
        private readonly IObjectContainer  _container;
        public string url = "https://mentorskid.com/";
        public string url2 = "https://qa2.mentorskid.com/";

        public WebHooks(IObjectContainer container)
        {
            _container = container;
        }
 
        [BeforeScenario]
        public void BeforeScenario()
        {
            {
                _driver = GetDriver("CHROME");
            }

        }

        public IWebDriver GetDriver(string requiredDriver)
        {
            switch (requiredDriver.ToUpper())
            {
                case "CHROME":
                    //ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService("F:\\SeleniumSpecflow-main\\BlueSkyCitadel\\bin\\Debug\\net6.0\\");
                    ChromeOptions option = new ChromeOptions();
                    option.AddArguments("start-maximized", "incognito");
                    _driver = new ChromeDriver(option);
                    _driver.Manage().Window.Maximize();
                    _container.RegisterInstanceAs(_driver);
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                    break;

                case "EDGE":
                    EdgeOptions edgeOption = new EdgeOptions();
                    edgeOption.AddArguments("start-maximized", "InPrivate");
                    _driver = new EdgeDriver(edgeOption);
                    _driver.Manage().Window.Maximize();
                    _container.RegisterInstanceAs(_driver);
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                    break;

                case "FIREFOX":
                    FirefoxOptions firefoxOptions  = new FirefoxOptions();
                    _driver = new FirefoxDriver(firefoxOptions);
                    _driver.Manage().Window.Maximize();
                    _container.RegisterInstanceAs(_driver);
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                    break;

                default:
                    throw new NotSupportedException($"Driver '{requiredDriver}' is not supported.");
            }
 
            return _driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Close();
            _driver.Quit();
            _driver.Dispose();
        }
    }
}