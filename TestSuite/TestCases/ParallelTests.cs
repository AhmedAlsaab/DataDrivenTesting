using NUnit.Framework;
using TestSuite.Web;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using TestSuite.Service;
using System.Collections.Generic;

namespace TestSuite.TestCases
{
    [TestFixture]
    public class ParallelTests : ThreadedChromeService
    {
        public string chromeDriverPath = @"C:\Automation";
        public static string testURL = "https://demoqa.com/html-contact-form/";
        readonly int startRecord = 2;
        readonly int endRecord = 5;

        ThreadedContactForm TcontactForm = new ThreadedContactForm();


        // Testing the same targetted website
        // With a different data set each loop
        // At the same time (each loop runs on a new instance & thread as the other loops || Parallel)

        [Test]
        public void ParallTesting()
        {

            var chromeOptions = new ChromeOptions();

            chromeOptions.AddArguments(new List<string>() {
           "--window-size=1920,1080",
           "--start-maximized",
           "--proxy-server='direct://'",
           "--disable-extensions",
           "--proxy-bypass-list=*",
            "--disable-gpu",
            "no-sandbox",
            "headless"});


            Parallel.For(startRecord, endRecord, i =>
            {
                SetDriver(new ChromeDriver(chromeDriverPath, chromeOptions));
                GetDriver().Url = testURL;
                TrackThreads();
                WaitForPageLoad();
                TcontactForm.InsertData(i);
                GetDriver().Close();
                GetDriver().Quit();
            });
            
        }

       
    }
    
}
