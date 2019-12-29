using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OnlineStore.PageObjects;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumClass
{
    class Program
    {
        public static void Main()
        {

            FirefoxDriver _driver = new FirefoxDriver();
            //_driver.SwitchTo().DefaultContent();
            //_driver.Switch().Frame().

            LoginPage loginPage = new LoginPage(_driver);
            loginPage.GoToPage();


            //_driver.SwitchTo().Frame("preview-frame");

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            //check if there is any iframe then get that frame and switch on frame using folloiwng code.
            var frame = wait.Until(ExpectedConditions.ElementExists(By.Name("preview-frame")));
            _driver.SwitchTo().Frame(frame);


            loginPage.UserName.Click();
            //var el = _driver.FindElementById("txtUsername");

            loginPage.UserName.SendKeys("opensourcecms");
            loginPage.Password.SendKeys("opensourcecms");
            loginPage.Submit.Click();


            //homePage.MyAccount.Click();
            //var loginPage = new LoginPage(_driver);
            //loginPage.UserName.SendKeys(_login);
            //loginPage.Password.SendKeys(_password);
            //loginPage.Submit.Submit();
            //Assert.IsTrue(homePage.HeaderText.Displayed);
            //Assert.AreEqual("Your Account", homePage.HeaderText.Text);
        }
    }
}
