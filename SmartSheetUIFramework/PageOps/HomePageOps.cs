using CommonUtil;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSheetUIFramework.PageOps
{
    public class HomePageOps
    {
        [FindsBy(How = How.XPath, Using = "//")]
        IWebElement TableGrid;

        [FindsBy(How = How.XPath, Using = "//")]
        IWebElement TableRow;

        [FindsBy(How = How.XPath, Using = "//div[@class='clsButtonContent']//span[text()='Create New']")]
        IWebElement CreateNewButton;

        [FindsBy(How = How.XPath, Using = "//table[@class='clsHomePageDetailTable']")]
        IWebElement CreateNewSheetListTable;

        List<IWebElement> Sheets
        {
            get
            {
                return Application.driver.FindElements(By.XPath("//div[contains(@class, 'clsCellContent clsDetailItemOpenable clsImageRenderi')]")).ToList<IWebElement>();
            }
        }

        public HomePageOps()
        {
            PageFactory.InitElements(Application.driver, this);
        }

        /// <summary>
        /// Method to open sheet from the display grid
        /// </summary>
        /// <param name="sheetName">provide sheet name</param>
        public void OpenSheetFromTable(string sheetName)
        {
            try
            {
                BrowserUtil.RefreshBrowser(Application.driver);
                //List<IWebElement> sheets = Application.driver.FindElements(By.XPath("//div[contains(@class, 'clsCellContent clsDetailItemOpenable clsImageRenderi')]")).ToList<IWebElement>();

                IWebElement sheet = Sheets.Find(t => t.Text == sheetName);

                CommonUIOperation.ClickOnAnObject(sheet, "Click on sheet");
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("Unable to find sheet with name: {0}",sheetName));
            }
        }

        


    }
}
