using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SpecFlow1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow1.Pages
{
    public class LoginPage
    {
        // Functions that allow users to login to TurnUp portal
        public void LoginActions(IWebDriver driver)
        {
            // Launch TurnUp portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(9000);


            try
            {
                // Identify username textbox and enter valid username
                IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
                usernameTextbox.SendKeys("hari");
            }
            catch (Exception ex)
            {
                Assert.Fail("Username textbox not located.");
            }


            //identify password textbox and enter valid password 
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("123123");


            //identify login button and click it
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            loginButton.Click();
            Thread.Sleep(2000);

        }

        internal void LoginActions()
        {
            throw new NotImplementedException();
        }
    }
}