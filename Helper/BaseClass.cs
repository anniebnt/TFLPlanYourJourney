using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace TFLPlanYourJourney.Helper
{
    public static class BaseClass
    {
        private static readonly TimeSpan implicitTimeout;
        private static readonly int timeout;
        internal static void Click(this IWebDriver webDriver, By locator)
        {
            webDriver.FindElement(locator).Click();
        }
        internal static void ClickAndTabOut(this IWebDriver webDriver, By locator, int? wait = null)
        {
            webDriver.FindElement(locator).Click();           
            if (wait != null)
            {
                SetImplicitWaitToDefaultValue(webDriver, 5);
            }
            Actions navigator = new Actions(webDriver);
            navigator.SendKeys(Keys.Tab)
                .SendKeys(Keys.Enter)
                .Perform();

        }

        internal static void ClearAndSendKeys(this IWebDriver webDriver, By locator, string text, int? wait = null)
        {
            webDriver.FindElement(locator).Clear();
            webDriver.FindElement(locator).SendKeys(text);
            if (wait != null)
            {                
                SetImplicitWaitToDefaultValue(webDriver,5);
            }
            webDriver.FindElement(locator).SendKeys(Keys.Tab);
        }


        internal static string GetText(this IWebDriver webDriver, By locator)
        {
            return webDriver.FindElement(locator).Text.Trim();
        }
        internal static bool IsDisplayed(this IWebDriver webDriver, By locator)
        {
            return webDriver.FindElement(locator).Displayed;
        }
       
        private static void setImplicitTimeout(this IWebDriver driver, int timeout)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
        }
        private static void SetImplicitWaitToDefaultValue(this IWebDriver webDriver, int wait = 5)
        {
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds((double)wait);
        }
        private static void resetImplicitTimeOut(this IWebDriver driver)
        {
            setImplicitTimeout(driver, timeout);
        }
        internal static bool ElementExists(this IWebDriver driver, By identifier)
        {
            return ElementExists(driver, identifier, implicitTimeout);
        }

        internal static bool ElementExists(this IWebDriver driver, By identifier, TimeSpan timeout)
        {
            bool result = false;
            try
            {               
                WebDriverWait wait = new WebDriverWait(driver, timeout);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(identifier));
                result = true;
            }
            catch (WebDriverTimeoutException)
            {
                result = false;
            }
            finally
            {
                resetImplicitTimeOut(driver);
            }
            return result;
        }
        public static IWebElement WaitUntilElementExists(this IWebDriver driver,By elementLocator, int timeout = 12)
        {
            try
            {
                var wait = new WebDriverWait(driver,TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementExists(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }

    }
}
