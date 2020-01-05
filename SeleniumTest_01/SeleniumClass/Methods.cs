using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrganeHR;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

namespace OrganeHR
{
    public static class Methods
    {
        public static string AddSkill(FirefoxDriver _driver)
        {
            
            AdminPanel adminPanel = new AdminPanel(_driver);
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.GoToPage();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            //check if there is any iframe then get that frame and switch on frame using folloiwng code.
            var frame = wait.Until(ExpectedConditions.ElementExists(By.Name("preview-frame")));
            _driver.SwitchTo().Frame(frame);


            loginPage.UserName.Click();
            loginPage.UserName.SendKeys("opensourcecms");
            loginPage.Password.SendKeys("opensourcecms");
            loginPage.Submit.Click();

            //_driver.SwitchTo().Frame(0);
            System.Threading.Thread.Sleep(2000);
            var button = _driver.FindElement(By.XPath(@"/html/body/div[5]/ul/li[1]/ul/li[3]/ul/li[1]/a"));
            _driver.ExecuteScript("arguments[0].scrollIntoView(true);", button);
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(@"/html/body/div[5]/ul/li[1]/ul/li[3]/ul/li[1]/a")));

            //Najezdzamy na Menu i klikamy
            Actions actions = new Actions(_driver);
            actions.MoveToElement(adminPanel.MenuAdmin).Perform();
            actions.MoveToElement(adminPanel.MenuAdminQualification).Perform();
            actions.MoveToElement(adminPanel.MenuAdminQualificationSkills).Click().Perform();

            _driver.SwitchTo().Frame(0);
            string randomPart = System.Guid.NewGuid().ToString().Substring(0, 4);
            Skills skill = new Skills() { Skill = "skill"+randomPart, SkillDescription = "description2" };

            adminPanel.BtnAdd.Click();
            adminPanel.InputSkillName.SendKeys(skill.Skill);
            adminPanel.InputSkillDescription.SendKeys(skill.SkillDescription);
            adminPanel.BtnSave.Click();

            //if (adminPanel.MessageBallonSuccess.Text != "Successfully Saved")
            //    throw new Exception("Błąd!");

            return adminPanel.MessageBallonSuccess.Text;
        }

        public class Skills
        {
            public string Skill { get; set; }
            public string SkillDescription { get; set; }
        }
    }
}