using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestSuite.Service;
using TestSuite.Web;

namespace TestSuite 
{
    // Basic Test that combines the Service and Contact Form class to pass different data sets into the targetted WebSite (Contact Form)
    // First approach towards Data Driven Tests
    [TestFixture]
    public class DemoTest : ChromeService
    {

        ContactForm contactForm = new ContactForm();
        
      
        [Test, Order(1)]
        public void FirstContactFormTest()
        {
            int row = 2;
            SetupAndPrepareChromeDriver();
            contactForm.InsertData(row);

        }

        [Test, Order(2)]
        public void SecondContactFormTest()
        {
            int row = 3;
            SetupAndPrepareChromeDriver();
            contactForm.InsertData(row);
        }

        [Test, Order(3)]
        public void ThirdContactFormTest()
        {
            int row = 4;
            SetupAndPrepareChromeDriver();
            contactForm.InsertData(row);
        }

        // TearDown will make sure all garbage (chrome, processes etc) are closed after each test has finished operating
        [TearDown]
        public void TearDown()
        {
            chrome.Close();
            chrome.Quit();
        }
    }
}
