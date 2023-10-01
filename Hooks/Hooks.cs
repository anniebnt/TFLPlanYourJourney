using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TFLPlanYourJourney.Helper;
using TechTalk.SpecFlow;

namespace TFLPlanYourJourney.Hooks
{
    [Binding]
    public sealed class Hooks: ExtentReports
    {
        public readonly IObjectContainer _objectContainer;
        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {

        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();

            _objectContainer.RegisterInstanceAs<IWebDriver>(webDriver);

        }


        [AfterScenario]
        public void AfterScenario()
        {
            var webDriver = _objectContainer.Resolve<IWebDriver>();
            if (webDriver != null)
            {
                webDriver.Quit();
            }
        }
    }
}