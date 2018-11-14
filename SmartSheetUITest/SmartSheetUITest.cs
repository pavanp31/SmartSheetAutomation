using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartSheet.ServiceHelper;
using SmartSheetObjectModel;
using System;

namespace SmartSheetTest
{
    [TestClass]
    public class SmartSheetUITest : BaseTest
    {
        [TestMethod]
        [Description("Verify Delete column operation")]
        [Priority(1)]
        [Owner("Pavan Patel")]
        [TestCategory("UITesting")]
        public void VerifySmartSheetDeleteColumnOperation()
        {
            try
            {
                // Create test data from API, 
                var newSheet = SmartSheetObjectModelHelper.CreateSheetObjectWithDefaultValue(2);
                SmartSheetWebAPIServiceHelper serviceHelper = new SmartSheetWebAPIServiceHelper(newSheet);
                Assert.IsNotNull(serviceHelper.CreateSheet(), "Failed to create sheet");

                // Launch and login to app
                Assert.IsTrue(loginPageOpsObj.LaunchAndLoginToApp(), "Failed to perform login operation");

                Assert.IsTrue(DeleteSpecificColumnFromSheet(newSheet), string.Format("Failed to perform column delete operation for given sheet: {0}", newSheet.name));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
