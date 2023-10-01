using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFLPlanYourJourney.Pages;
using TFLPlanYourJourney.Pages.Components;

namespace TFLPlanYourJourney.StepDefinitions
{
    [Binding]
    public sealed class PlanYourJourneySteps
    {
        private IWebDriver _webDriver;
        private PlanYourJourneyPage PlanYourJourney => new(_webDriver);
        private CookiesCmpnt CookiesCmpnt => new(_webDriver);
        public PlanYourJourneySteps(IWebDriver webDriver)
        {
            this._webDriver = webDriver;
        }

        
        [Given(@"I open tfl plan your journey page")]
        public void GivenIOpenTflPlanYourJourneyPage()
        {
            PlanYourJourney.LoadPlanYourJourneyPage();
            CookiesCmpnt.IsCookiesBannerDisplayed();
            CookiesCmpnt.AcceptAllCookies();           
        }
        [Given(@"Tfl journey planner page is displayed")]
        public void GivenTflJourneyPlannerPageIsDisplayed()
        {
            Assert.IsTrue(PlanYourJourney.IsPlanYourJourneyTitleDisplayed());
        }

        [When(@"I enter From '(.*)' and To '(.*)' station")]
        public void WhenIEnterFromAndToStation(string fromStation, string toStation)
        {
            PlanYourJourney.EnterFromStation(fromStation);
            PlanYourJourney.EnterToStation(toStation);            
        }

        [When(@"click on plan my journey button")]
        public void WhenClickOnPlanMyJourneyButton()
        {
            PlanYourJourney.SubmitPlanMyJourney();
        }

        [Then(@"error under From station is displayed as '(.*)'")]
        public void ThenErrorUnderFromStationIsDisplayedAs(string fromError)
        {
            Assert.AreEqual(fromError, PlanYourJourney.GetFromErrorMessage());
        }
        [Then(@"error under To station is displayed as '(.*)'")]
        public void ThenErrorUnderToStationIsDisplayedAs(string toError)
        {
            Assert.AreEqual(toError, PlanYourJourney.GetToErrorMessage());
        }

    }
}
