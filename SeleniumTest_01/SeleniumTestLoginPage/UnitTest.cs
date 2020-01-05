using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OrganeHR;

namespace OnlineStore.PageObjects
{
    class FireFoxTest
    {
        [TestFixture]
        public class MainTest
        {
            //public IWebDriver _driver { private set; get; }
            public FirefoxDriver _driver { private set; get; }
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

            [Test]
            public void TestAddSkill()
            {
                string result = OrganeHR.Methods.AddSkill(_driver);
                //Assert.IsTrue(homePage.HeaderText.Displayed);
                Assert.AreEqual("Successfully Saved", result);
            }
        }
    }
}