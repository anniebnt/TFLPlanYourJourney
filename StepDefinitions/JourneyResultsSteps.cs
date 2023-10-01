using NUnit.Framework;
using TechTalk.SpecFlow;
using TFLPlanYourJourney.Pages;

namespace TFLPlanYourJourney.StepDefinitions
{
    [Binding]
    public class JourneyResultsSteps
    {
        JourneyResultsPage _journeyResultsPage;
        public JourneyResultsSteps(JourneyResultsPage journeyResultsPage)
        {
            _journeyResultsPage = journeyResultsPage;
        }

        [StepDefinition(@"results page is displayed with title Journey results")]
        public void ThenResultsPageIsDisplayedWithTitleJourneyResults()
        {
            Assert.IsTrue(_journeyResultsPage.IsJourneyResultTitleDisplayed());
        }

        [StepDefinition(@"results page shows From station as '(.*)'")]
        public void ThenResultsPageShowsFromStationAs(string fromStation)
        {
            Assert.AreEqual(fromStation, _journeyResultsPage.GetResultsFromStation());
        }

        [StepDefinition(@"results page shows To station as '(.*)'")]
        public void ThenResultsPageShowsToStationAs(string toStation)
        {
            Assert.AreEqual(toStation, _journeyResultsPage.GetResultsToStation());
        }

        [StepDefinition(@"View Cycling and other options are displayed")]
        public void ThenViewCyclingAndOtherOptionsAreDisplayed()
        {
            Assert.IsTrue(_journeyResultsPage.IsJourneyResultWithCylingDisplayed());
        }

        [StepDefinition(@"journey results page shows an error message '(.*)'")]
        public void ThenJourneyResultsPageShowsAnErrorMessage(string errorMessage)
        {
            Assert.AreEqual(errorMessage, _journeyResultsPage.GetNoResultsErrormessage());
        }
        [StepDefinition(@"click on Edit journey option in results page")]
        public void WhenClickOnEditJourneyOptionInResultsPage()
        {
            _journeyResultsPage.SelectEditJourney();
        }

        [StepDefinition(@"I clear From and To stations in journey results page")]
        public void WhenIClearFromAndToStationsFromJourneyResultsPage()
        {
            _journeyResultsPage.ClearToStation();
            _journeyResultsPage.ClearFromStation();
            
        }
        [StepDefinition(@"I click on Update journey button")]
        public void WhenIClickOnUpdateJourneyButton()
        {
            _journeyResultsPage.ClickUpdteJourney();
        }

        [StepDefinition(@"switch To and From stations in journey results page")]
        public void ThenSwitchToAndFromStationsInJourneyResultsPage()
        {
            _journeyResultsPage.SwitchToAndFrom();
        }
    }
}
