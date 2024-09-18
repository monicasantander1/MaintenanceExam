using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace MaintenanceExam.PageObjects
{
    public class TopNavPanel : BasePageLocal
    {
        private readonly By _middleMenuLocator = By.CssSelector("nav.navbar-dark ul.navbar-nav:not(.hidden-md-up):not(.navbar-right) > li");

        public TopNavPanel(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Returns the second level of top nav menu items
        /// </summary>
        /// <returns>The second level menu items</returns>
        public string[] GetSecondLevelMenuItems()
        {
            return FindElements(ExpectedConditions.VisibilityOfAllElementsLocatedBy(_middleMenuLocator)).Select(e => e.Text).ToArray();
        }

        /// <summary>
        /// Clicks the Products & Services top nav option
        /// </summary>
        public void ProductsServices()
        {
            Click(By.XPath("//a[text()='Products & Services']"));
        }
    }
}