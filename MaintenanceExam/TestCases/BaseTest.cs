using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MaintenanceExam.TestCases
{
    public abstract class BaseTest
    {
        public ThreadLocal<IWebDriver> Driver = new();
        public string Url = string.Empty;

        [OneTimeSetUp]
        public virtual void OneTimeSetup()
        {
            Url = "https://www-qa.mybranchqa.org/login";
        }

        [SetUp]
        public virtual void Setup()
        {
            Driver.Value = new ChromeDriver();
            Driver.Value.Manage().Window.Maximize();
            Driver.Value.Url = Url;
        }

        [TearDown]
        public virtual void TearDown()
        {
            Driver.Value?.Quit();
        }
    }
}