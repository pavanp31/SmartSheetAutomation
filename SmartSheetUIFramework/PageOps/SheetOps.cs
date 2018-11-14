using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSheetUIFramework.PageOps
{
    public class SheetOps :PageOperationBase
    {
        [FindsBy(How = How.XPath, Using = "//")]
        IWebElement TableGrid;

        [FindsBy(How = How.XPath, Using = "//")]
        IWebElement TableRow;

        //*[@id="foid:11"]/div/span[1]
        [FindsBy(How = How.XPath, Using = "//div[@class='clsButtonContent']//span[text()='Create New']")]
        IWebElement CreateNewButton;

        [FindsBy(How = How.XPath, Using = "//table[@class='clsHomePageDetailTable']")]
        IWebElement CreateNewSheetListTable; 

        List<IWebElement> ColumnNameElements
        { get {return Application.driver.FindElements(By.XPath("//div[@class='clsTableHeadingText']")).ToList<IWebElement>(); } }// and @text='" + columnName + "']"));

        IWebElement ContextmenuTable
        { get { return Application.driver.FindElement(By.XPath("//div[@class='clsPopupMenu clsMediumDropShadow']")); } }

        IWebElement DeleteOption
        {
            get
            {
                return ContextmenuTable.FindElement(By.XPath("//div[@class='clsPopupMenu clsMediumDropShadow']//table/tbody/tr[3]/td[2]"));
            }
        }

        public SheetOps()
        {
            PageFactory.InitElements(Application.driver, this);
        }

        public bool DeleteColumnFromSheetAndVerify(string columnName)
        {
            try
            {
                SetDriverTimeOutForExceptionHandling(10000);
                WaitForPageLoad();
                
                // Find all the column form the displayed sheet
                var columnCountBeforeDeleteOps = ColumnNameElements.Count;

                // Filter the column by name which we want to delete
                IWebElement columnNameElement = ColumnNameElements.Find(t => t.Text.Contains(columnName));

                // Right-Click on column and perform delete operation
                CommonUIOperation.RightClickOnAnObjectByMouse(Application.driver, columnNameElement, "Right Click on Column");
                CommonUIOperation.ClickOnAnObject(DeleteOption, "Select Delete column option from the list");

                // Verify column should be deleted
                var columnCountAfterDeleteOps = ColumnNameElements.Count;
                if (columnCountBeforeDeleteOps> columnCountAfterDeleteOps)
                    return true;
                else
                    return false;
            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
                ResetDriverTimeOutToDefault();
            }
        }


    }
}
