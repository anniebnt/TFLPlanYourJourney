using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V115.Emulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFLPlanYourJourney.Helper;

namespace TFLPlanYourJourney.Pages
{
    public class JourneyResultsPage
    {
        private IWebDriver _webDriver;
        private By journeyResultsTitleBy => By.XPath("//h1//span[contains(text(),'Journey results')]");
        private By resultsFromBy => By.CssSelector(".from-to-wrapper>div:nth-child(1) strong");
        private By resultsToBy => By.CssSelector(".from-to-wrapper>div:nth-child(2) strong");
        private By resultsCyclingBy => By.XPath("//h2[text()='Cycling and other options']");
        private By noResultsErrorMessageBy => By.XPath("//ul[@class='field-validation-errors']//li");
        private By editJourneyBy => By.XPath("//a[@class='edit-journey']//span");
        private By clearFromStationBy => By.XPath("//div//a[text()='Clear From location']");
        private By clearToStationBy => By.XPath("//div//a[text()='Clear To location']");
        private By switchToFromBy => By.XPath("//div//a[text()='Switch from and to']");
        private By updateJourneyBy = By.CssSelector("#plan-journey-button");
        private By moreLocationsBy => By.CssSelector(".info-message.disambiguation");        
        private By firstSuggestedStationBy => By.CssSelector("#disambiguation-options-from li:nth-child(1)");
        private By viewDetailsButtonBy => By.XPath("//div[@id='option-1-content']//a[text()='View details']");

        public JourneyResultsPage(IWebDriver webDriver)
        {
            _webDriver= webDriver;  
        }

        public bool IsJourneyResultTitleDisplayed()
        {            
            return _webDriver.IsDisplayed(journeyResultsTitleBy);            
        }
        public string GetResultsFromStation()
        {
            BaseClass.WaitUntilElementExists(_webDriver,resultsFromBy);
            return _webDriver.GetText(resultsFromBy);
        }

        public string GetResultsToStation()
        {
            BaseClass.WaitUntilElementExists(_webDriver, resultsToBy);
            return _webDriver.GetText(resultsToBy);
        }
        

        public bool IsJourneyResultWithCylingDisplayed()
        {            
            BaseClass.WaitUntilElementExists(_webDriver, resultsCyclingBy);

            if (_webDriver.ElementExists(resultsCyclingBy))
            {
                return _webDriver.IsDisplayed(resultsCyclingBy);
            }
            else return false;

        }
        public string GetNoResultsErrormessage()
        {
            BaseClass.WaitUntilElementExists(_webDriver,noResultsErrorMessageBy);
            return _webDriver.GetText(noResultsErrorMessageBy);
        }
        public void SelectEditJourney()
        {
            _webDriver.Click(editJourneyBy);
        }
        public void ClearFromStation()
        {
            _webDriver.ClickAndTabOut(clearFromStationBy,5);           
        }
        public void ClearToStation()
        {
            _webDriver.ClickAndTabOut(clearToStationBy,5);
        }
        public void SwitchToAndFrom()
        {
            _webDriver.Click(switchToFromBy);
        }

        public void ClickUpdteJourney()
        {
            _webDriver.Click(updateJourneyBy);

            bool moreStationsAvailable = _webDriver.ElementExists(moreLocationsBy);
           
            if (moreStationsAvailable)
            {
                BaseClass.WaitUntilElementExists(_webDriver, firstSuggestedStationBy);
                _webDriver.Click(firstSuggestedStationBy);
                BaseClass.WaitUntilElementExists(_webDriver, viewDetailsButtonBy);

            }
            

        }
    }
}
