using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SE = SeleniumExtras;
using System.Threading;
using NUnit.Framework;

namespace TestSuite.Service
{
    public class ThreadedChromeService
    {
        readonly int secondsToWait = 5;

        // Starting a new thread for each driver (chrome) instance
        public static ThreadLocal<IWebDriver> driverInstance = new ThreadLocal<IWebDriver>();

        // Invoked for WebDriver operations
        public static IWebDriver GetDriver()
        {

            return driverInstance.Value;
        }

        // Setting the argument (driver) to the thread created
        public static void SetDriver(IWebDriver driver)
        {

            driverInstance.Value = driver;

        }

        // Tracking how many threads are created via ID
        public static void TrackThreads()
        {
            var listThreadIds = Thread.CurrentThread.ManagedThreadId.ToString();
            System.Diagnostics.Debug.Write("Thread Id: \n", listThreadIds);
        }

        public static void CleanThreadsUp()
        {
            driverInstance.Dispose();
        }

        // Javascript used to assess whether the document (page) is ready (complete)
        // This method can be used to wait for page loads (usually after a submit button)
        public void WaitForPageLoad()
        {
            new WebDriverWait(GetDriver(), TimeSpan.FromMinutes(1)).Until(
            d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        // Method to use for entering text into fields that permit (and makes sense to) text/data entry
        public void WaitForElementAndSendKeys(string elementLocation, string whatToType)
        {
            var waitForElementToLoad = new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(secondsToWait));
            try
            {
                var selectedElement = waitForElementToLoad.Until(SE.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(elementLocation)));

                if (selectedElement.Displayed && selectedElement.Enabled)
                {

                    selectedElement.SendKeys(whatToType);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write("ELEMENT NOT FOUND", elementLocation);
            }

        }
    }
}
