using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartSheetUIFramework;
using SmartSheetUIFramework.PageOps;
using SmartSheetObjectModel;

namespace SmartSheetTest
{
    /// <summary>
    /// Summary description for BaseTestUI
    /// </summary>
    [TestClass]
    public class BaseTest
    {
        public LoginPageOps loginPageOpsObj { get; }
        public SheetOps SheetOpsObj { get; }
        public HomePageOps homePageOps { get; }

        public BaseTest()
        {
            loginPageOpsObj = new LoginPageOps();
            SheetOpsObj = new SheetOps();
            homePageOps = new HomePageOps();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        public bool DeleteSpecificColumnFromSheet(Sheet sheet)
        {
            // Open sheet from the table to perform delete column operation
            homePageOps.OpenSheetFromTable(sheet.name);

            bool notPrimary = false;

            // Find the non-primary
            foreach (var column in sheet.columns)
            {
                if (column.primary == false)
                {
                    notPrimary = true;

                    // Perform delete operation for Non-Primary column
                   return SheetOpsObj.DeleteColumnFromSheetAndVerify(column.title);
                }
            }

            if (!notPrimary)
                Assert.Fail("Test Failed: The created sheet has only primary column, can't delete primary column");
           return false;
        }
    }
}
