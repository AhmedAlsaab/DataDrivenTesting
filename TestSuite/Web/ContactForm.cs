using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSuite.Service;
using ExcelOperations;

namespace TestSuite.Web
{
    class ContactForm
    {
        ExcelFileReader excel = new ExcelFileReader();
        ChromeService methodToUse = new ChromeService();


        // Method can be invoked 
        // Created for contact-form input
        public void InsertData(int row)
        {
            string firstName = excel.ExcelLookup(1, row, 1);
            string firstNameElementLocator = "//input[contains(@class, 'firstname') and contains(@placeholder, 'Your name..')]";
            methodToUse.WaitForElementAndSendKeys(firstNameElementLocator, firstName);
            

            string lastName = excel.ExcelLookup(2, row, 1);
            string lastNameElementLocator = "//input[contains(@id, 'lname') and contains(@placeholder, 'Your last name..')]";
            methodToUse.WaitForElementAndSendKeys(lastNameElementLocator, lastName);


            string country = excel.ExcelLookup(3, row, 1);
            string countryLocator = "//input[contains(@name, 'country') and contains(@placeholder, 'Enter your Country')]";
            methodToUse.WaitForElementAndSendKeys(countryLocator, country);

            string subject = excel.ExcelLookup(4, row, 1);
            string subjectLocator = "//input[contains(@id, 'subject') and contains(@placeholder, 'Write something')]";
            methodToUse.WaitForElementAndSendKeys(subjectLocator, subject);


        }
    }
}
