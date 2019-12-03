// A class for some sample logic for an improved chrome service 

namespace AutomationTest.TestSuite
{
   public class DriverLogic
    {
       // ... omitted
       // Declare your URl's here
        

    // Which options to run Chrome with
        public void SetupAndPrepareChromeDriver(int sheetNum)
        {
            var chromeOptions = new ChromeOptions();

            chromeOptions.AddArguments(new List<string>() {
           "--window-size=1920,1080",
           "--start-maximized",
           //  "--proxy-server='direct://'",
           "--disable-extensions",
            //  "--proxy-bypass-list=*",
            //   "--disable-gpu",
            //     "no-sandboxgit st
            //   "headless"
            });

            try
            {
                if (sheetNum == 2)
                {
                    System.Diagnostics.Debug.WriteLine("Starting Automation for Y");
                    chrome = new ChromeDriver(chromeDriverPath, chromeOptions)
                    {

                        // .. Your URL
                    };
                }
                else if (sheetNum == 1 || sheetNum == 3)
                {
                    System.Diagnostics.Debug.WriteLine("Starting Automation for X");
                    chrome = new ChromeDriver(chromeDriverPath, chromeOptions)
                    {

                        // .. Your URL 
                    };
                }
            }
            catch (WebDriverException)
            {
                System.Diagnostics.Debug.WriteLine("Caught Receive Failure (Automation stopped?)");
            }
            
            
        }

        public IWebElement FindByXpath(string elementLocation)
        {
            var waitForElementToLoad = new WebDriverWait(chrome, TimeSpan.FromSeconds(secondsToWait));
            IWebElement elementXpath = waitForElementToLoad.Until(SE.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(elementLocation)));
            return elementXpath;
        }

        public IWebElement FindById(string elementLocation)
        {
            var waitForElementToLoad = new WebDriverWait(chrome, TimeSpan.FromSeconds(secondsToWait));
            IWebElement elementByID = waitForElementToLoad.Until(SE.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(elementLocation)));
            return elementByID;
        }

       // Element Automation
       // How the specified element is automated is based on which argument is given
        public void WebdriverOperations(string elementLocation, int methodToUse, string whatToSend = "")
        {

            try
            {
                switch (methodToUse)
                {
                    // Find By Xpath and Click
                    case 1:
                        FindByXpath(elementLocation).Click();
                        Assert.IsTrue(FindByXpath(elementLocation).Displayed);
                        break;

                    // Find By Xpath and Send Keys (Type into field)
                    case 2:
                        FindByXpath(elementLocation).SendKeys(whatToSend);
                        Assert.AreEqual(FindByXpath(elementLocation).GetAttribute("value"), whatToSend);

                        System.Diagnostics.Debug.WriteLine("Assessing...");
                        System.Diagnostics.Debug.WriteLine("Value", FindByXpath(elementLocation).GetAttribute("value"));
                        System.Diagnostics.Debug.WriteLine("What To Send", whatToSend);
                        break;

                    // Find By Xpath, Scroll into view and Click
                    case 3:
                        ((IJavaScriptExecutor)chrome).ExecuteScript("arguments[0].scrollIntoView(true);", FindByXpath(elementLocation));
                        ((IJavaScriptExecutor)chrome).ExecuteScript("arguments[0].click();", FindByXpath(elementLocation));
                        break;

                    // Find By ID and Send Keys
                    case 4:
                        FindById(elementLocation).SendKeys(whatToSend);
                        Assert.AreEqual(FindById(elementLocation).GetAttribute("value"), whatToSend);
                        System.Diagnostics.Debug.WriteLine("The data has matched the expected input\n", whatToSend);
                        break;

                    // Find by ID and Click
                    case 5:
                        FindById(elementLocation).Click();
                        Assert.IsTrue(FindById(elementLocation).Displayed);
                        break;

                    // Find By ID and Pick Date
                    case 6:
                        ((IJavaScriptExecutor)chrome).ExecuteScript("arguments[0].scrollIntoView(true);", FindById(elementLocation));
                        ((IJavaScriptExecutor)chrome).ExecuteScript("document.getElementById('" + elementLocation + "').setAttribute('value', '" + whatToSend + "')");
                        break;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write("ELEMENT NOT FOUND\n", elementLocation);
                ErrorLogging(e);
            }
        }
        // ... Omitted the rest 
        
    }
