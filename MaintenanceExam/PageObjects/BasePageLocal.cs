using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MaintenanceExam.PageObjects
{
    public class BasePageLocal
    {
        protected IWebDriver Driver;

        public BasePageLocal(IWebDriver driver)
        {
            Driver = driver;
        }

        // Any methods that are WebDriver specific and would go into BasePage but only apply to this project go here

        /// <summary>
        /// Clicks on an element
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <param name="timeOut">[Optional] How long to wait for the element (in seconds). The default timeOut is 10s.</param>
        public virtual void Click(By locator, int timeOut = 10)
        {
            DateTime now = DateTime.Now;
            while (DateTime.Now < now.AddSeconds(timeOut))
            {
                try
                {
                    ScrollToElement(locator, timeOut);
                    new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOut)).Until(ExpectedConditions.ElementToBeClickable(locator)).Click();

                    return;
                }
                catch (ElementClickInterceptedException)
                {
                    // do nothing, loop again
                }
                catch (StaleElementReferenceException)
                {
                    // do nothing, loop again
                }
            }

            throw new Exception($"Not able to click element <{locator}> within {timeOut}s.");
        }

        /// <summary>
        /// Finds the element using the provided wait condition
        /// </summary>
        /// <param name="waitCondition">The wait condition can be an ExpectedCondition or a custom wait that returns an IWebElement</param>
        /// <param name="timeOut">[Optional] How long to wait for the element (in seconds). The default timeOut is 10s.</param>
        /// <returns>The found IWebElement</returns>
        public virtual IWebElement FindElement(Func<IWebDriver, IWebElement> waitCondition, int timeOut = 10)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOut)).Until(waitCondition);
        }

        /// <summary>
        /// Finds all elements with the provided locator
        /// </summary>
        /// <param name="locator">The locator used to find the elements.</param>
        /// <returns>The collection of IWebElement</returns>
        public virtual IReadOnlyCollection<IWebElement> FindElements(By locator)
        {
            return Driver.FindElements(locator);
        }

        /// <summary>
        /// Finds all elements using the provided wait condition
        /// </summary>
        /// <param name="waitCondition">The wait condition can be an ExpectedCondition or a custom wait that returns a collection of IWebElement</param>
        /// <param name="timeOut">[Optional] How long to wait for the element (in seconds). The default timeOut is 10s.</param>
        /// <returns>The collection of found IWebElements</returns>
        public virtual IReadOnlyCollection<IWebElement> FindElements(Func<IWebDriver, IReadOnlyCollection<IWebElement>> waitCondition, int timeOut = 10)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOut)).Until(waitCondition);
        }

        /// <summary>
        /// Returns the text of the desired element
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns>The text contained in the element</returns>
        public virtual string GetText(By locator)
        {
            int timeOut = 10;
            DateTime now = DateTime.Now;
            while (DateTime.Now < now.AddSeconds(timeOut))
            {
                try
                {
                    return FindElement(ExpectedConditions.ElementIsVisible(locator)).Text;
                }
                catch (StaleElementReferenceException)
                {
                    // do nothing, loop again
                }
            }

            throw new Exception($"Not able to get .Text from element <{locator}> within {timeOut}s.");
        }

        /// <summary>
        /// Scrolls the specified element to the center of the window using Javascript.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <param name="timeOut">How long to wait for the element in seconds (optional). The default timeOut is 10s.</param>
        public virtual void ScrollToElement(By locator, int timeOut = 10)
        {
            try
            {
                Driver.ExecuteJavaScript("window.scrollTo(0, arguments[0].getBoundingClientRect().top + window.pageYOffset - (window.innerHeight / 2));", FindElement(ExpectedConditions.ElementIsVisible(locator), timeOut));
            }
            catch (Exception e)
            {
                throw new Exception("Unable to scroll to the given web element.", e);
            }
        }

        /// <summary>
        /// Enters the provided text into the specified element.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <param name="text">The text to be entered.</param>
        public virtual void SendKeys(By locator, string text)
        {
            FindElement(ExpectedConditions.ElementIsVisible(locator)).SendKeys(text);
        }

        /// <summary>
        /// Sets the dropdown to the desired value by text.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <param name="text">The text to be selected from the dropdown.</param>
        public void SetDropdownByText(By locator, string text)
        {
            IWebElement e = FindElement(ExpectedConditions.ElementIsVisible(locator));
            new SelectElement(e).SelectByText(text);
        }
    }
}