using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using TFLPlanYourJourney.Helper;

namespace TFLPlanYourJourney.Pages
{
    internal class PlanYourJourneyPage
    {
        private IWebDriver _webDriver;        
        private By planJourneyTitleBy => By.XPath("//h1[normalize-space()='Plan a journey']");
        private By fromStationBy => By.XPath("//input[@name='InputFrom']");
        private By toStationBy => By.XPath("//input[@name='InputTo']");
        private By submitButtonBy => By.XPath("//div[@id='plan-a-journey']//input[@value='Plan my journey']");       
        private By fromErrorMessage => By.XPath("//span[@class='field-validation-error']//span[@id='InputFrom-error']");
        private By toErrorMessage => By.XPath("//span[@class='field-validation-error']//span[@id='InputTo-error']");       
        private By moreLocationsBy => By.CssSelector(".info-message.disambiguation");      
        private By firstSuggestedStationBy => By.CssSelector("#disambiguation-options-to li:nth-child(1)");
        private By viewDetailsButtonBy => By.XPath("//div[@id='option-1-content']//a[text()='View details']");
        public PlanYourJourneyPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;               
        }

        public void LoadPlanYourJourneyPage()
        {
            var url = "https://tfl.gov.uk/plan-a-journey/";
            Uri pageLink = new Uri(url);
            _webDriver.Navigate().GoToUrl(pageLink);               
        }
        public bool IsPlanYourJourneyTitleDisplayed()
        {            
            return _webDriver.IsDisplayed(planJourneyTitleBy);
        }
        public void EnterFromStation(string fromStation)
        {
            _webDriver.ClearAndSendKeys(fromStationBy, fromStation);
            
        }
        public void EnterToStation(string toStation)
        {
            _webDriver.ClearAndSendKeys(toStationBy, toStation);  
        }
        public void SubmitPlanMyJourney()
        {           
            _webDriver.Click(submitButtonBy);    

            bool moreStationsAvailable = _webDriver.ElementExists(moreLocationsBy);
 
            if (moreStationsAvailable)
            {
                BaseClass.WaitUntilElementExists(_webDriver, firstSuggestedStationBy);
                _webDriver.Click(firstSuggestedStationBy);
                BaseClass.WaitUntilElementExists(_webDriver, viewDetailsButtonBy);                             
            }
        }

        public string GetFromErrorMessage()
        {
            return _webDriver.GetText(fromErrorMessage);
        }
        public string GetToErrorMessage()
        {
            return _webDriver.GetText(toErrorMessage);
        }
    }
}
