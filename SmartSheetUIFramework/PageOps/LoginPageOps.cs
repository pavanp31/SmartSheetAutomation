using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using CommonUtil;

namespace SmartSheetUIFramework.PageOps
{
    public class LoginPageOps : PageOperationBase
    {
        [FindsBy(How = How.Id, Using = "loginEmail")]
        IWebElement UserName;

        [FindsBy(How = How.Id, Using = "loginPassword")]
        IWebElement Pwd;

        [FindsBy(How = How.XPath, Using = "//input[@value='Log In']")]
        IWebElement loginButton;

        [FindsBy(How = How.XPath, Using = "//*[@class='clsDesktopTabContent']")]
        IWebElement HomeIcon;

        public LoginPageOps()
        {
            PageFactory.InitElements(Application.driver, this);
        }

        /// <summary>
        /// Method to launch and login to an app
        /// </summary>
        /// <returns>Operation result : true or false </returns>
        public bool LaunchAndLoginToApp()
        {
            try
            {
                SetDriverTimeOutForExceptionHandling(10000);
                
                // Navigate to app url
                Application.driver.Url = Constant.AppURL;
                try
                {
                    // Login to app
                    LoginToApp();
                }
                catch
                {
                    try
                    {
                        // handle continue window flow
                        CommonUIOperation.EnterTextInTextBox(UserName, Constant.UserName, "Insert userName");
                        CommonUIOperation.ClickOnAnObject(Application.driver.FindElement(By.XPath("//input[@value='Continue']")),"Click on continue button");
                        LoginToApp();
                    }
                    catch
                    {
                       //ignore this exception as Continue flow may be 
                    }
                }

                // check if home screen is showing up or not after login
                WaitForPageLoad();
                if (HomeIcon.Displayed)
                {
                    // Click on home icon
                    CommonUIOperation.ClickOnAnObject(HomeIcon, "Click on Home icon");
                }
                else
                {
                    throw new Exception("Failed to perform launch and login app");
                }
                
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to perform Login operation" + Environment.NewLine + ex.Message);
            }
            finally
            {
                ResetDriverTimeOutToDefault();
            }

        }

        /// <summary>
        /// Method to perform action on login page
        /// </summary>
        public void LoginToApp()
        {
            CommonUIOperation.EnterTextInTextBox(UserName, Constant.UserName, "Insert userName");
            CommonUIOperation.EnterTextInTextBox(Pwd, Constant.Password, "Enter password");
            CommonUIOperation.ClickOnAnObject(loginButton, "Click on login button");
        }


    }
}
