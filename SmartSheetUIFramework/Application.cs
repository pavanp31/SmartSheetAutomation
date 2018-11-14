using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using CommonUtil;

namespace SmartSheetUIFramework
{
    public class Application
    {
        public static IWebDriver driver = SetAppTestEnvironment();

        public static IWebDriver SetAppTestEnvironment(bool needToInitializeDriver = false)
        {
            if(driver==null)
            {
                BrowserUtil.CloseAllBrowsers();

                if (Constant.TargetedBrowser.ToLower().Contains("ch"))
                {
                    ChromeOptions options = new ChromeOptions();
                    string user = Environment.UserName;
                    options.AddArguments("user-data-dir=C:\\Users\\" + user + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default", "--disable-session-crashed-bubble");

                    try
                    {
                        driver = new ChromeDriver(Environment.CurrentDirectory, options);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message + ex.StackTrace + ex.Source);
                    }
                }
                else if(Constant.TargetedBrowser.ToLower().Contains("ie"))
                {
                    driver = new InternetExplorerDriver();
                }
                else
                {
                    throw new Exception("Failed: Trgeted browser entry is not valid ");
                }
            }
            return driver;
        }
    }
}
