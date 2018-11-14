using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtil;
using OpenQA.Selenium;

namespace SmartSheetUIFramework
{
    public class PageOperationBase
    {
        /// <summary>
        /// Method to handle page load
        /// </summary>
        /// <returns></returns>
        public bool WaitForPageLoad()
        {
            int waitTime = 60;

            while (!(((IJavaScriptExecutor)Application.driver).ExecuteScript("return (document.readyState == 'complete')").ToString().ToLower() == "true") ? true : false)
            {
                if (waitTime == 0) break;

                System.Threading.Thread.Sleep(1000);
                waitTime--;
            }

            return ((IJavaScriptExecutor)Application.driver).ExecuteScript("return document.readyState").Equals("complete");

        }

        /// <summary>
        /// Set driver time-out for rendering issue
        /// </summary>
        /// <param name="seconds"></param>
        public void SetDriverTimeOutForExceptionHandling(int seconds = 3000)
        {
            Application.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(seconds);
        }

        /// <summary>
        /// reset driver time out to 20 sec
        /// </summary>
        public void ResetDriverTimeOutToDefault()
        {
            Application.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(7000);
        }
    }
}
