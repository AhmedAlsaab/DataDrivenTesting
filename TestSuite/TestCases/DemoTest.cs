using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestSuite.Service;

namespace TestSuite 
{
    [TestFixture]
    public class DemoTest : ChromeService
    {
        
      
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
