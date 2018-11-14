using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSheetUIFramework
{
    public class CommonUIOperation
    {

        public static string ClickOnAnObject(IWebElement uiElementObject, string ObjectDescriptiveName)
        {
            try
            {
                // Check for the element exist first then click on the object.
                uiElementObject.Click();
                System.Threading.Thread.Sleep(2000);
            }
            catch (Exception ex)
            {

              throw new Exception("Failed : Cannot click on the specified the object : " + ObjectDescriptiveName +
                  Environment.NewLine + ex.Message + Environment.NewLine + ex.Source
                  + Environment.NewLine + ex.TargetSite);
            }
            return "**PASSED: Clicked on Object '" + ObjectDescriptiveName + "'";
        }

        public static string EnterTextInTextBox(IWebElement uiElementObject, string Parameter, string ObjectDescriptiveName)
        {
            try
            {
                uiElementObject.Clear();
                uiElementObject.SendKeys(Parameter);
            }
            catch (NoSuchElementException)
            {
                throw new Exception("Failed to insert text in text box field");
            }
            return "**PASSED: Entered ' " + Parameter + "' in TextBox '" + ObjectDescriptiveName + "'";
        }

        public static string RightClickOnAnObjectByMouse(IWebDriver driver, IWebElement ObjectName, string ObjectDescriptiveName)
        {
            try
            {
                System.Threading.Thread.Sleep(3000);
                // Check for the element exist first then click on the object.
                Actions myMouse = new Actions(driver);
                myMouse.ContextClick(ObjectName).Build().Perform();
                System.Threading.Thread.Sleep(3000);

            }
            catch
            {
                throw new Exception("Failed to click to perform right click on given object" + ObjectDescriptiveName);
                // stacktrace//
                //return "**FAILED: " + ex.Message;
            }
            return "**PASSED: Clicked on Object '" + ObjectDescriptiveName + "'";
        }
    }
}
