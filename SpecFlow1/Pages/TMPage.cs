using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlow1.Utilities;
using OpenQA.Selenium.Support.UI;

namespace SpecFlow1.Pages
{
    public class TMPage
    {
        private IWebElement WaitForElementToBeClickable(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }
        public void CreateTimeRecord(IWebDriver driver)
        {
            try
            {
                // Click "Create New" button
                IWebElement createNewButton = WaitForElementToBeClickable(driver, By.XPath("//*[@id=\"container\"]/p/a"));
                //IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
                createNewButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Create New button hasn't been found." + ex.Message);
            }

            // Select Time from dropdown
            IWebElement typeCodeDropdown = WaitForElementToBeClickable(driver, By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown.Click();

            IWebElement timeOption = WaitForElementToBeClickable(driver, By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            timeOption.Click();




            // Type code into Code textbox
            IWebElement codeTextbox = WaitForElementToBeClickable(driver, By.Id("Code"));
            codeTextbox.SendKeys("TA Programme");

            // Type description into Description textbox
            IWebElement descriptionTextbox = WaitForElementToBeClickable(driver, By.Id("Description"));
            descriptionTextbox.SendKeys("This is a description");

            // Type price into Price textbox
            IWebElement priceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTagOverlap.Click();

            IWebElement priceTextbox = WaitForElementToBeClickable(driver, By.Id("Price"));
            priceTextbox.SendKeys("12");

            // Click Save button
            IWebElement saveButton = WaitForElementToBeClickable(driver, By.Id("SaveButton"));
            saveButton.Click();

            // Wait for record creation and go to last page
            IWebElement goToLastPageButton = WaitForElementToBeClickable(driver, By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
        }

        // Helper method to get text of the last created record
        public string GetCode(IWebDriver driver)
        {
            IWebElement newCode = WaitForElementToBeClickable(driver, By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return newCode.Text;
        }

        public string GetDescription(IWebDriver driver)
        {
            IWebElement newDescription = WaitForElementToBeClickable(driver, By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return newDescription.Text;
        }

        public string GetPrice(IWebDriver driver)
        {
            IWebElement newPrice = WaitForElementToBeClickable(driver, By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return newPrice.Text;
        }

        // Edit time record
        public void EditTimeRecord(IWebDriver driver, string code, string description)
        {
            // Go to the last page
            IWebElement lastPageButton = WaitForElementToBeClickable(driver, By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lastPageButton.Click();

            // Wait for the edit button and click it
            IWebElement editButton = WaitForElementToBeClickable(driver, By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();

            // Update the code and description
            IWebElement codeTextbox = WaitForElementToBeClickable(driver, By.Id("Code"));
            codeTextbox.Clear();
            codeTextbox.SendKeys(code);

            IWebElement descriptionTextbox = WaitForElementToBeClickable(driver, By.Id("Description"));
            descriptionTextbox.Clear();
            descriptionTextbox.SendKeys(description);

            // Click Save
            IWebElement saveButton = WaitForElementToBeClickable(driver, By.Id("SaveButton"));
            saveButton.Click();

            // Go to the last page again
            lastPageButton = WaitForElementToBeClickable(driver, By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lastPageButton.Click();
        }

        // Get edited code
        public string GetEditedCode(IWebDriver driver)
        {
            IWebElement editedCode = WaitForElementToBeClickable(driver, By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return editedCode.Text;
        }

        // Get edited description
        public string GetEditedDescription(IWebDriver driver)
        {
            IWebElement editedDescription = WaitForElementToBeClickable(driver, By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return editedDescription.Text;
        }

        // Delete time record
        public void DeleteTimeRecord(IWebDriver driver)
        {
            IWebElement lastPageButton = WaitForElementToBeClickable(driver, By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lastPageButton.Click();

            // Click on delete button
            IWebElement deleteButton = WaitForElementToBeClickable(driver, By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();

            // Accept delete confirmation
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IAlert alert = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            alert.Accept();

            // Wait for deletion to reflect
            driver.Navigate().Refresh();
            lastPageButton = WaitForElementToBeClickable(driver, By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lastPageButton.Click();

            IWebElement deletedCode = WaitForElementToBeClickable(driver, By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            // Verify deletion
            if (deletedCode.Text != "Edit Code TA Programme")
            {
                Assert.Pass("Record deleted successfully");
            }
            else
            {
                Assert.Fail("Record has not been deleted.");
            }
        }
    }
}