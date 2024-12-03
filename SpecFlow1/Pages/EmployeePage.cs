using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow1.Pages
{
    public class EmployeePage
    {
        //private WebDriverWait wait;

        private IWebElement WaitForElementToBeClickable(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }
        private IWebElement WaitForElementToBeVisible(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }


        public void CreateEmployeeRecord(IWebDriver driver)
        {
            //create a Employee record
            //click on create  button
            IWebElement createButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createButton.Click();

            // Fill out employee details

            //type name into name textbox
            IWebElement nameTextbox = driver.FindElement(By.Id("Name"));
            nameTextbox.SendKeys("Boney Varkey");

            //type username into username textbox

            IWebElement usernameTextbox = driver.FindElement(By.Id("Username"));
            usernameTextbox.SendKeys("Boney");

            //type contact  into contact textbox
            IWebElement contactTextbox = driver.FindElement(By.Id("ContactDisplay"));
            contactTextbox.SendKeys("ABC");

            //type password into password textbox
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("Boney@12345");

            //type retypepassword into retype password textbox

            IWebElement retypePasswordTextbox = driver.FindElement(By.Id("RetypePassword"));
            retypePasswordTextbox.SendKeys("Boney@12345");


            // Save the record

            //driver.FindElement(By.Id("SaveButton")).Click();

            IWebElement saveButton = WaitForElementToBeClickable(driver, By.Id("SaveButton"));
            saveButton.Click();

            //Bacl to List button
            IWebElement backToListButton = WaitForElementToBeClickable(driver, By.XPath("//*[@id=\"container\"]/div/a"));
            backToListButton.Click();
            Thread.Sleep(5000);

            //check if  time record has been created successfully
            IWebElement lastPageButton = WaitForElementToBeClickable(driver, By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
            lastPageButton.Click();
            Thread.Sleep(5000);

            // Ensure the table is visible before proceeding
            //IWebElement table = WaitForElementToBeVisible(driver, By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody"));

         
            // Helper method to get text of the last created record

          
        }

        public string NewName(IWebDriver driver)
        {
            IWebElement newName = WaitForElementToBeClickable(driver, By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last]/td[1]"));
            return newName.Text;
        }
        public string NewUserName(IWebDriver driver)
        {
            IWebElement newUserName = WaitForElementToBeClickable(driver, By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last]/td[2]]"));
            return newUserName.Text;
        }
        //Edit employee record
        public void EditEmployeeRecord(IWebDriver driver)
        {
            Thread.Sleep(4000);
            //Select a record and click edit button
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
            lastPageButton.Click();
            Thread.Sleep(2000);

            //Edit a Employee record
            //click on Edit  button
            //IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[3]/td[3]/a[1]"));
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[1]"));
            editButton.Click();

            //type name into name textbox
            IWebElement nameTextbox = driver.FindElement(By.Id("Name"));
            nameTextbox.Clear();
            nameTextbox.SendKeys("Elaine");

            //type username into username textbox

            IWebElement usernameTextbox = driver.FindElement(By.Id("Username"));
            usernameTextbox.Clear();
            usernameTextbox.SendKeys("Liz");

            //type contact  into contact textbox
            IWebElement contactTextbox = driver.FindElement(By.Id("ContactDisplay"));
            contactTextbox.Clear();
            contactTextbox.SendKeys("NZ");

            //type password into password textbox
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.Clear();
            passwordTextbox.SendKeys("Elaine@12345");

            //type retypepassword into retype password textbox

            IWebElement retypePasswordTextbox = driver.FindElement(By.Id("RetypePassword"));
            retypePasswordTextbox.Clear();
            retypePasswordTextbox.SendKeys("Elaine@12345");


            // Save the record

            IWebElement saveButton = WaitForElementToBeClickable(driver, By.Id("SaveButton"));
            saveButton.Click();

            //Bacl to List button
            IWebElement backToListButton = WaitForElementToBeClickable(driver, By.XPath("//*[@id=\"container\"]/div/a"));
            backToListButton.Click();
            Thread.Sleep(5000);
          

            //check if  time record has been created successfully
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            
        }

        // Get edited name
        public string GetEditedName(IWebDriver driver)
        {
            IWebElement editedName = WaitForElementToBeClickable(driver, By.XPath("///*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last]/td[1]"));
            return editedName.Text;
        }

        // Get edited username
        public string GetEditedUsername(IWebDriver driver)
        {
            IWebElement editedUsername= WaitForElementToBeClickable(driver, By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last]/td[2]]"));
            return editedUsername.Text;
        }

        public void DeleteEmployeeRecord(IWebDriver driver)
        {
            Thread.Sleep(4000);
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
            lastPageButton.Click();
            Thread.Sleep(3000);

            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[2]"));
            deleteButton.Click();

            Thread.Sleep(1500);

            // Accept delete confirmation
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IAlert alert = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            alert.Accept();

            // Wait for deletion to reflect
            driver.Navigate().Refresh();
            lastPageButton = WaitForElementToBeClickable(driver, By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
            lastPageButton.Click();

            IWebElement deletedName = WaitForElementToBeClickable(driver, By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));


            //Check if the record is deleted
            // Verify deletion
            if (deletedName.Text != "Boney Varkey")
            {
                Assert.Pass("Employee Record deleted successfully");
            }
            else
            {
                Assert.Fail("Employee Record has not been deleted.");
            }
        }
    }
}
