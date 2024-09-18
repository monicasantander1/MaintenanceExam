using MaintenanceExam.PageObjects;
using NUnit.Framework;

namespace MaintenanceExam.TestCases.Navigation
{
    [TestFixture]
    [Ignore("Wait for bug #123 to be fixed in the Digital Platform Project", Until = "2024-09-23 12:00Z")]
    class TopNav : BaseTestLocal
    {
        [Test]
        [Category("Navigation")]
        public void TopNavCase()
        {
            // Update the test case to incorporate the new requirements and pass.
            // TODO: The top nav options have been updated.

            TopNavPanel topNavPanel = new TopNavPanel(Driver.Value!);
            topNavPanel.ProductsServices();
            string[] actualMenuItems = topNavPanel.GetSecondLevelMenuItems();
            string[] expectedMenuItems = { "Checking & Savings", "Loans & Credit", "Home Loans", "Account Services", "Insurance", "Investments", "Business", "Schedule Appointment" };
            CollectionAssert.AreEqual(expectedMenuItems, actualMenuItems, "Verify second level of top nav menu");
        }
    }
}