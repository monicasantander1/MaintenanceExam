using MaintenanceExam.Common;
using OpenQA.Selenium;

namespace MaintenanceExam.PageObjects
{
    public class GetAQuotePage : BasePageLocal
    {
        private readonly By _autoInterestLocator = By.XPath("//label[text()='Auto']");
        private readonly By _emailAddressLocator = By.Id("Email");
        private readonly By _firstNameLocator = By.Id("FirstName");
        private readonly By _lastNameLocator = By.Id("LastName");
        private readonly By _otherInterestLocator = By.XPath("//label[text()='Other']");
        private readonly By _phoneNumberLocator = By.Id("PhoneNumber");
        private readonly By _phoneNumberTypeDropdownLocator = By.Id("PhoneNumberType");
        private readonly By _preferredContactMethodDropdownLocator = By.Id("PreferredContactMethod");
        private readonly By _prospectivePolicyStateDropdownLocator = By.Id("State");
        private readonly By _submitLocator = By.XPath("//button[text()='Submit']");
        private readonly By _zipCodeLocator = By.Id("ZipCode");
        private readonly By _homeInterestLocator = By.XPath("//label[text()='Home']");
        private readonly By _languagePreferenceDropdownLocator = By.Id("LanguagePreference");
        private readonly By _confirmationMessageLocator = By.XPath("//h3[contains(text(),'Thank')]");

        public GetAQuotePage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Creates an insurance quote request.
        /// </summary>
        /// <param name="autoInterest">True if interested in an Auto quote, False otherwise.</param>
        /// <param name="otherInterest">True if interested in an Other quote, False otherwise.</param>
        public void CreateRequest(bool autoInterest, bool otherInterest)
        {
            string firstName = Utils.GenerateRandomString(6);
            string lastName = Utils.GenerateRandomString(8);
            string phoneNumber = "(210) 555-" + Utils.GenerateRandomNumber(1000, 10000);

            SendKeys(_firstNameLocator, firstName);
            SendKeys(_lastNameLocator, lastName);
            SendKeys(_emailAddressLocator, "autotest10@ssfcu.org");
            SendKeys(_phoneNumberLocator, phoneNumber);
            SetDropdownByText(_phoneNumberTypeDropdownLocator, "Mobile");
            SetDropdownByText(_preferredContactMethodDropdownLocator, "Email");
            SetDropdownByText(_prospectivePolicyStateDropdownLocator, "Texas");
            SendKeys(_zipCodeLocator, "78249");
            Click(_homeInterestLocator);
            SetDropdownByText(_languagePreferenceDropdownLocator, "English");
            if (autoInterest)
            {
                Click(_autoInterestLocator);
            }
            if (otherInterest)
            {
                Click(_otherInterestLocator);
            }
            Click(_submitLocator);
        }
        /// <summary>
        /// Confirmation Message after submission
        /// </summary>
        /// <returns>Confirmation Message</returns>
        public string ConfirmationMessage()
        {
            return GetText(_confirmationMessageLocator);
        }
    }
}