using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFLPlanYourJourney.Helper;

namespace TFLPlanYourJourney.Pages.Components
{
    public class CookiesCmpnt 
    {
        private IWebDriver _webDriver;
        private By acceptCookiesBy = By.XPath("//button//strong[contains(text(),'Accept all cookies')]");
        private IWebElement acceptCookies => _webDriver.FindElement(acceptCookiesBy);
        private By manageCookiesBy = By.XPath("//button//strong[contains(text(),'Accept all cookies')]");
        private IWebElement manageCookies => _webDriver.FindElement(manageCookiesBy);
        public CookiesCmpnt(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public bool IsCookiesBannerDisplayed()
        {
            return _webDriver.IsDisplayed(manageCookiesBy);
        }
        public void AcceptAllCookies()
        {
            _webDriver.Click(acceptCookiesBy);
        }
    }
}
