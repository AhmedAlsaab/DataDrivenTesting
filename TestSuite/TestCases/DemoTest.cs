using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestSuite
{
    [TestFixture]
    public class DemoTest 
    {
        public string chromeDriverPath = @"C:\Automation";
        public static string testURL = "https://demoqa.com/html-contact-form/";
        public static IWebDriver chrome;


        // SetUp will run before the tests are called
        [SetUp]
        public void SetupAndPrepareChromeDriver()
        {
            chrome = new ChromeDriver(chromeDriverPath)
            {
                Url = testURL
            };
        }

        [Test, Order(1)]
        public void FirstContactFormTest()
        {

        }

        [Test, Order(2)]
        public void SecondContactFormTest()
        {

        }

        [Test, Order(3)]
        public void ThirdContactFormTest()
        {

        }

        // TearDown will make sure all garbage (chrome, processes etc) are closed down
        [TearDown]
        public void TearDown()
        {
            chrome.Close();
            chrome.Quit();
        }
    }
}
