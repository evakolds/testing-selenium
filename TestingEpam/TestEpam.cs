using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace TestingEpam
{
    public class TestEpam
    { 
        [TestFixture]
        public class Test
        {
            private IWebDriver _driver;
            private const string Url = "https://www.epam.com/";
            private HomePage _home;
            private RusPage _homeRus;
            private InsightsPage _insights;
            private CareersPage _careers;

            [SetUp]
            public void TestInitialize()
            {
                var options = new ChromeOptions();
                options.AddArgument("start-maximized");

                _driver = new ChromeDriver("/usr/local/bin", options);
                _driver.Navigate().GoToUrl(Url);

                new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(driver => driver.Url == Url);

                _home = new HomePage(_driver);
                _homeRus = new RusPage(_driver);
                _insights = new InsightsPage(_driver);
                _careers = new CareersPage(_driver);
                _driver.SwitchTo().Window(_driver.WindowHandles.First());
            }

            [TearDown]
            public void TestFinalize()
            {
                _driver.Quit();
            }
            
            [Test]
            public void SocialNetworks()
            {
                _home.AgreeWithCookies();
                
                string linkedin = _home.ToLinkedIn();
                Assert.AreEqual("https://www.linkedin.com/company/epam-systems/", linkedin);
                
                string twitter = _home.ToTwitter();
                Assert.AreEqual("https://twitter.com/EPAMSYSTEMS", twitter);
                
                string facebook = _home.ToFacebook();
                Assert.AreEqual("https://www.facebook.com/EPAM.Global", facebook);
                
                string instagram = _home.ToInstagram();
                Assert.AreEqual("https://www.instagram.com/epamsystems/", instagram);
            }
            
            [Test]
            public void ChangeLanguage()
            {
                _home.AgreeWithCookies();
                _home.ChangeLanguage();
                
                string services = _homeRus.GetRussianWordServices();
                Assert.AreEqual("Услуги", services);
                
                string approaches = _homeRus.GetRussianWordApproaches();
                Assert.AreEqual("Подходы", approaches);
            }
            
            [Test]
            public void ToDifferentOffices()
            {
                _home.AgreeWithCookies();
                
                string res = _home.FindOffice();
                Assert.AreEqual("Asia", res);
            }

            [Test]
            public void GoToMainPage()
            {
                _home.OpenWorkPage();
                _home.OpenHomePage();
                string res = _home.GetDriverUrl();
            
                Assert.AreEqual(Url, res);
            }
            
            [Test]
            public void SearchInfo()
            {
                _home.AgreeWithCookies();
                string res = _home.SearchInfo();
            
                Assert.AreEqual("Open Source", res);
            }
            
            [Test]
            public void FilterIndustry()
            {
                _home.AgreeWithCookies();
                _home.ToInsights();
                
                string res = _insights.Filter();
                Assert.AreEqual("Healthcare", res);
            }

            [Test]
            public void ContactUs()
            {
                _home.OpenContactUsPage();
                string number = _home.FindPhoneNumber();
            
                Assert.AreEqual("+1-267-759-8989", number);
            }
            
            [Test]
            public void ApplyJobVacancy()
            {
                _home.AgreeWithCookies();
                _home.ApplyCandidacy();
                string res = _careers.GetJobTitle();
            
                Assert.AreNotEqual(string.Empty, res);
            }
        }
    }
}