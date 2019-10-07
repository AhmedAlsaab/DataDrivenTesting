using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SE = SeleniumExtras;
using System.Threading;
using NUnit.Framework;

namespace TestSuite.Service
{
    class ThreadedChromeService
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

    }
}
