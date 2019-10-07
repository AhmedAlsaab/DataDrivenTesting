using NUnit.Framework;
using TestSuite.Service;
using TestSuite.Web;

namespace TestSuite.TestCases
{
    [TestFixture]
    public class LoopedTests : ChromeService
    {
        ContactForm contactForm = new ContactForm();

        // Testing the same targetted sections
        // But with different data each loop

        [Test]
        public void LoopingThisTest()
        {
            for (int i = 2; i < 5; i++)
            {
                SetupAndPrepareChromeDriver();
                contactForm.InsertData(i);
                TearDown();
            }
        }

        [TearDown]
        public void TearDown()
        {
            chrome.Close();
            chrome.Quit();
        }
    }
}
