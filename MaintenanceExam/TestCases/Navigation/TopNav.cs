using MaintenanceExam.PageObjects;
using NUnit.Framework;

namespace MaintenanceExam.TestCases.Navigation
{
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
            string[] expectedMenuItems = { "Checking & Savings", "Loans & Credit", "Account Services", "Insurance & Investments", "Business" };
            CollectionAssert.AreEqual(expectedMenuItems, actualMenuItems, "Verify second level of top nav menu");
        }
    }
}