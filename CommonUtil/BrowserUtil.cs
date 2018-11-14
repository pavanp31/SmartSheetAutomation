using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonUtil
{
    public static class BrowserUtil
    {
        public static void CloseAllBrowsers()
        {
            List<string> browserList = new List<string>() { "iexplore", "chrome" };

            Process[] process = Process.GetProcesses().Where(x => browserList.Contains(x.ProcessName))
                .ToArray();

            foreach (Process proc in process)
            {
                if (proc.MainWindowTitle != "")
                {
                    proc.Kill();
                    while (!proc.HasExited) { }
                }
            }
        }

        public static bool VerifyPopupMessageAndTakeAction(IWebDriver driver, bool dismissPopup = false)
        {
            try
            {
                // Accept the changes
                var windows = driver.WindowHandles;

                var ele = driver.FindElements(By.XPath("//button")).ToList<IWebElement>();

                var name = ele.Find(t => t.Text.Contains("Continue"));
               // var popup = driver.SwitchTo().Alert().Text;
                if (dismissPopup)
                    driver.SwitchTo().Alert().Dismiss();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void RefreshBrowser(IWebDriver driver)
        {
            string currentURL = driver.Url;
            driver.Navigate().GoToUrl(currentURL);
            // This delay is required to load page
            Thread.Sleep(2000);
        }
    }
}
