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
using OpenQA.Selenium.Interactions;

namespace SeleniumClass
{
    class Program
    {
        public static void Main()
        {

            using (FirefoxDriver _driver = new FirefoxDriver())
            {
                try
                {
                    //_driver.SwitchTo().DefaultContent();
                    //_driver.Switch().Frame().
                    AdminPanel adminPanel = new AdminPanel(_driver);
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

                    //_driver.SwitchTo().Frame(0);
                    System.Threading.Thread.Sleep(2000);
                    var button = _driver.FindElement(By.XPath(@"/html/body/div[5]/ul/li[1]/ul/li[3]/ul/li[1]/a"));
                    _driver.ExecuteScript("arguments[0].scrollIntoView(true);", button);
                    wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(@"/html/body/div[5]/ul/li[1]/ul/li[3]/ul/li[1]/a")));

                    //Klikamy w Menu
                    Actions actions = new Actions(_driver);
                    actions.MoveToElement(adminPanel.MenuAdmin).Perform();
                    actions.MoveToElement(adminPanel.MenuAdminQualification).Perform();
                    actions.MoveToElement(adminPanel.MenuAdminQualificationSkills).Click().Perform();
                    
                    _driver.SwitchTo().Frame(0);
                    List<Skills> skills = new List<Skills>();
                    string randomPart = System.Guid.NewGuid().ToString().Substring(0, 4);
                    skills.Add(new Skills() { Skill = "skill"+randomPart, SkillDescription = "description1" });

                    randomPart = System.Guid.NewGuid().ToString().Substring(0, 4);
                    skills.Add(new Skills() { Skill = "skill2"+randomPart, SkillDescription = "description2" });

                    foreach (Skills skill in skills)
                    {
                        adminPanel.BtnAdd.Click();
                        adminPanel.InputSkillName.SendKeys(skill.Skill);
                        adminPanel.InputSkillDescription.SendKeys(skill.SkillDescription);
                        adminPanel.BtnSave.Click();
                        if (adminPanel.MessageBallonSuccess.Text != "Successfully Saved")
                            throw new Exception("Błąd!");
                    }
                    //Assert.IsTrue(homePage.HeaderText.Displayed);
                    //Assert.AreEqual("Your Account", homePage.HeaderText.Text);
                }
                catch(Exception ex)
                {
                    throw;
                }
                finally
                {
                    _driver.Quit();
                }
            }
        }

        public class Skills
        {
            public string Skill { get; set; }
            public string SkillDescription { get; set; }
        }
    }
}
