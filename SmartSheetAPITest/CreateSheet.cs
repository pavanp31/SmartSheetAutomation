using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartSheetObjectModel;
using SmartSheet.ServiceHelper;

namespace SmartSheetAPITest
{
    [TestClass]
    public class CreateSheetTest :BaseTestAPI
    {
        [TestMethod]
        [Description("Create Sheet in 'Sheets' Folder")]
        [Priority(1)]
        [Owner("Pavan Patel")]
        [TestCategory("API testing")]
        public void VerifyCreateSheetAPI()
        {
            try
            {
                // Create sheet with two columns
                var newSheet = SmartSheetObjectModelHelper.CreateSheetObjectWithDefaultValue(4);
                SmartSheetWebAPIServiceHelper serviceHelper = new SmartSheetWebAPIServiceHelper(newSheet);
                var response = serviceHelper.CreateSheet();

                // Verify API response: Success
                Assert.IsNotNull(response, "Failed to add sheet via API");
                VerifyResponse(response);
            }
            catch(Exception ex)
            {
                Assert.Fail("Failed to createSheet via Web API");
            }
        }
    }
}
