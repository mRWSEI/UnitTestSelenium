using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OnlineStore.PageObjects;

namespace SeleniumDemo
{
    [TestFixture]
    public abstract class MainTest
    {
        public IWebDriver _driver { private set; get; }
        [SetUp]
        public void StartBrowser()
        {
            _driver = new FirefoxDriver();
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();
        }
    }
}