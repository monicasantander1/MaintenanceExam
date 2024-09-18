using OpenQA.Selenium;

namespace MaintenanceExam.PageObjects
{
    public class LoginPage : BasePageLocal
    {
        private readonly By _logInLocator = By.XPath("//button[contains(.,'Log In')]");
        private readonly By _passwordLocator = By.Id("Password");
        private readonly By _usernameLocator = By.Id("Username");
        private readonly By _searchBoxLocator = By.CssSelector("div.search-field input");
        private readonly By _routingNumberLocator = By.CssSelector("div.pull-right strong");
        private readonly By _productServicesLocator = By.XPath("//a[text()='Products & Services']");
        private readonly By _myApplications = By.XPath("//a[contains(text(),'My Applications')]");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Logs in using the provided username and password
        /// </summary>
        public void Login(string username, string password)
        {
            SendKeys(_usernameLocator, username);
            SendKeys(_passwordLocator, password);
            Click(_logInLocator);
        }
    }
}