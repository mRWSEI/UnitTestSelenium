using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumClass
{
    public class AdminPanel
    {   
        private readonly IWebDriver driver;
        public AdminPanel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        #region Menu
        [FindsBy(How = How.XPath, Using = @"/html/body/div[5]/ul/li[1]/a/span")]
        public IWebElement MenuAdmin { get; set; }

        [FindsBy(How = How.XPath, Using = @"/html/body/div[5]/ul/li[1]/ul/li[3]/a/span")]
        public IWebElement MenuAdminQualification  { get; set; }

        [FindsBy(How = How.XPath, Using = @"/html/body/div[5]/ul/li[1]/ul/li[3]/ul/li[1]/a/span")]
        public IWebElement MenuAdminQualificationSkills { get; set; }

        #endregion

        [FindsBy(How = How.Id, Using = "btnAdd")]
        public IWebElement BtnAdd { get; set; }

        [FindsBy(How = How.Id, Using = "btnSave")]
        public IWebElement BtnSave { get; set; }

        [FindsBy(How = How.Id, Using = "messageBalloon_success")]
        public IWebElement MessageBallonSuccess { get; set; }


        [FindsBy(How = How.XPath, Using = @"/html/body/div[5]/ul/li[1]/ul/li[3]/ul/li[1]/a")]
        public IWebElement MenuSkills { get; set; }

        [FindsBy(How = How.Id, Using = "skill_name")]
        public IWebElement InputSkillName { get; set; }


        [FindsBy(How = How.Id, Using = "skill_description")]
        public IWebElement InputSkillDescription { get; set; }
    }
}
