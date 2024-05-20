//using BoDi;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Edge;
//using System.Reflection;

//namespace ImageUploadTest.Hooks
//{
//    [Binding]

//    public class BaseHooks
//    {
//        public IObjectContainer _context;
//        public string url = "https://mentorskid.com/";
//        public string url2 = "https://qa2.mentorskid.com/";

//        private IWebDriver? driver;

//        public BaseHooks(IObjectContainer context)
//        {
//            _context = context;
//        }

//        [BeforeScenario]
//        public void BeforeScenario()
//        {
//            driver = new ChromeDriver();
//            //driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
//            //driver = new EdgeDriver(AppDomain.CurrentDomain.BaseDirectory);
//            driver.Manage().Window.Maximize();
//            _context.RegisterInstanceAs(driver);
//        }

//        [AfterScenario]
//        public void AfterScenario()
//        {
//            if (driver != null)
//            {
//                driver?.Quit();
//            }
//            driver = null;
//        }
//    }
//}

