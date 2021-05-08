using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace TestingEpam
{
    public class InsightsPage
    {
        private IWebDriver driver;

        public InsightsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        private const string SelectField = "//*[@id='main']/div[1]/div[4]/section/div/div[1]/div/div[2]/div/div/span[1]/div/div[1]";
        private const string SelectItem = "//*[@id='main']/div[1]/div[4]/section/div/div[1]/div/div[2]/div/div/span[1]/div/div[2]/div/ul/li[8]/label/span";
        private const string IndustryTitle = "//*[@id='main']/div[1]/div[4]/section/div/div[1]/div/div[3]/ul/li[1]/a/div[2]/ul/li[2]";

        [FindsBy(How = How.XPath, Using = SelectField)]
        private IWebElement selectField;
        [FindsBy(How = How.XPath, Using = SelectItem)]
        private IWebElement selectItem;
        [FindsBy(How = How.XPath, Using = IndustryTitle)]
        private IWebElement industryTitle;

        public string Filter()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(selectField));
            selectField.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(selectItem));
            selectItem.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(industryTitle));
            string res = industryTitle.GetAttribute("innerHTML");
            return res;
        }
        
    }
}