using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
namespace OnlineStore.PageObjects
{
    class HomePage
    {
        private IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "account")]
        public IWebElement MyAccount { get; set; }
        [FindsBy(How = How.CssSelector, Using = ".entry-title")]
        public IWebElement HeaderText { get; set; }
        public void GoToPage()
        {
            driver.Navigate().GoToUrl("https://google.pl");
        }
    }
}