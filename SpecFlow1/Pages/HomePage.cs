using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlow1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow1.Pages
{
    public class HomePage
    {
        public void navigatetoTMPage(IWebDriver driver)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                // Navigate to Time and Material module
                IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a/span"));
                administrationTab.Click();
            

                IWebElement timeAndMaterialOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
                timeAndMaterialOption.Click();

                // Verify successful login
                VerifySuccessfulLogin(driver);
            }
            catch (Exception ex)
            {
                Assert.Fail("Error occurred while navigating to TM page: " + ex.Message);
            }
           
        }

        public void navigatetoEmployeePage(IWebDriver driver)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));  // Increase the timeout duration

                // Navigate to Employee module
                IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a/span"));
                administrationTab.Click();


                 IWebElement employeeOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a"));
                 employeeOption.Click();

                // Wait for a specific element that indicates the page has loaded (e.g., employee list or table)
                // IWebElement employeeTable = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//table[@id='employeeGrid']"))); // Example XPath

                // Verify successful login
                VerifySuccessfulLogin(driver);
            }
            catch (Exception ex)
            {
                Assert.Fail("Error occurred while navigating to Employee page: " + ex.Message);
            }

        }
        private void VerifySuccessfulLogin(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement helloHari = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a")));

            // Use Assert.IsTrue instead of Assert.Pass
            Assert.IsTrue(helloHari.Text == "Hello hari!", "USER HAS NOT LOGGED IN SUCCESSFULLY. TEST FAILED");
        }

      //  internal void NavigatetoEmployeePage(IWebDriver driver)
       // {
       //     throw new NotImplementedException();
       // }
    }

}
