using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace OnlineStore.PageObjects
{
    public class LoginPage
    {
        public readonly string URL = @"https://s1.demo.opensourcecms.com/s/44";
        //public readonly string URL = @"https://s2.demo.opensourcecms.com/orangehrm/symfony/web/index.php/auth/login";

        private readonly IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "#txtUsername")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.Id, Using = "txtPassword")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "btnLogin")]
        public IWebElement Submit { get; set; }

        public void GoToPage()
        {
            driver.Navigate().GoToUrl(URL);
        }
    }
}