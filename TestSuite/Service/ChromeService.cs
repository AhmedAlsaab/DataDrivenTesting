using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestSuite.Service
{
    public class ChromeService
    {

        public string chromeDriverPath = @"C:\Automation";
        public static string testURL = "https://demoqa.com/html-contact-form/";
        public static IWebDriver chrome;
        readonly int secondsToWait = 5;


        public void SetupAndPrepareChromeDriver()
        {
            chrome = new ChromeDriver(chromeDriverPath)
            {
                Url = testURL
            };
        }

        // Method to use for entering text into fields that permit (and makes sense to) text/data entry
        public void WaitForElementAndSendKeys(string elementLocation, string whatToType)
        {
            var waitForElementToLoad = new WebDriverWait(chrome, TimeSpan.FromSeconds(secondsToWait));
            try
            {
                var selectedElement = waitForElementToLoad.Until(ExpectedConditions.ElementToBeClickable(By.Id(elementLocation)));

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
