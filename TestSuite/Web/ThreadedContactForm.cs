using TestSuite.Service;
using ExcelOperations;


namespace TestSuite.Web
{
    // Demo class, using the ThreadedVersion for ParallelTesting
    public class ThreadedContactForm : ThreadedChromeService
    {
        ExcelFileReader excel = new ExcelFileReader();


        // Method can be invoked 
        // Created for contact-form input
        public void InsertData(int row)
        {
            string firstName = excel.ExcelLookup(1, row, 1);
            string firstNameElementLocator = "//input[contains(@class, 'firstname') and contains(@placeholder, 'Your name..')]";
            WaitForElementAndSendKeys(firstNameElementLocator, firstName);


            string lastName = excel.ExcelLookup(2, row, 1);
            string lastNameElementLocator = "//input[contains(@id, 'lname') and contains(@placeholder, 'Your last name..')]";
            WaitForElementAndSendKeys(lastNameElementLocator, lastName);


            string country = excel.ExcelLookup(3, row, 1);
            string countryLocator = "//input[contains(@name, 'country') and contains(@placeholder, 'Enter your Country')]";
            WaitForElementAndSendKeys(countryLocator, country);

            string subject = excel.ExcelLookup(4, row, 1);
            string subjectLocator = "//textarea[contains(@id, 'subject') and contains(@placeholder, 'Write something')]";
            WaitForElementAndSendKeys(subjectLocator, subject);


        }
    }
}
