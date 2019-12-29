using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
namespace OnlineStore.PageObjects
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "username")]
        public IWebElement UserName { get; set; }
        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement Password { get; set; }
        [FindsBy(How = How.Name, Using = "login")]
        public IWebElement Submit { get; set; }
    }
}