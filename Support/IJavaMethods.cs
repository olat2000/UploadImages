using OpenQA.Selenium;

namespace ImageUploadAuto.Support
{
    public static class IJavaMethods
    {
        public static void UseIJavaScroll(this IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor jsScroll = (IJavaScriptExecutor)driver;
            jsScroll.ExecuteScript("arguments[0].scrollIntoView(true)", element);
        }

    }
}
