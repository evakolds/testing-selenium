using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace TestingEpam
{
    public class RusPage
    {
        private readonly IWebDriver _driver;

        public RusPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
        
        private const string RussianServices = ".top-navigation__item:nth-child(1) .top-navigation__item-link";
        private const string RussianApproaches = ".top-navigation__item:nth-child(3) .top-navigation__item-link";

        [FindsBy(How = How.CssSelector, Using = RussianServices)]
        private IWebElement russianWordServicesElement;
        
        [FindsBy(How = How.CssSelector, Using = RussianApproaches)]
        private IWebElement russianWordApproachesElement;

        public string GetRussianWordServices()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).
                Until(ExpectedConditions.ElementToBeClickable(russianWordServicesElement));
            string res = russianWordServicesElement.GetAttribute("innerHTML");
            return res;
        }
        
        public string GetRussianWordApproaches()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).
                Until(ExpectedConditions.ElementToBeClickable(russianWordApproachesElement));
            string res = russianWordApproachesElement.GetAttribute("innerHTML");
            return res;
        }
    }
}