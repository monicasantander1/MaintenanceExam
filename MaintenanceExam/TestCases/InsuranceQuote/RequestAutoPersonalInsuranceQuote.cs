using MaintenanceExam.PageObjects;
using NUnit.Framework;

namespace MaintenanceExam.TestCases.InsuranceQuote
{
    class RequestAutoPersonalInsuranceQuote : BaseTestLocal
    {
        [Test]
        [Category("Insurance Quote")]
        public void RequestAutoPersonalInsuranceQuoteCase()
        {
            // Update the test case to incorporate the new requirements and pass.
            // TODO: The insurance quote page has been updated to include Interest: Home and Language Preference,
            // the default language preference is "English".
            // TODO: Add an assert in the test to validate the confirmation message after submission.

            // hack to get to the page faster
            Driver.Value!.Url = "https://www-qa.mybranchqa.org/insurance/personal/request-a-quote";

            new GetAQuotePage(Driver.Value!).CreateRequest(true, false);

            GetAQuotePage getAQuotePage = new GetAQuotePage(Driver.Value!);

            string confirmationMessageResults = getAQuotePage.ConfirmationMessage();

            Assert.Pass(confirmationMessageResults, "Confirmation Message does display.");
        }
    }
}