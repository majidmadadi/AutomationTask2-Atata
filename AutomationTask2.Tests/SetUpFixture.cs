using Atata;
using NUnit.Framework;

namespace AutomationTask2.Tests
{
    [SetUpFixture]
    public class SetUpFixture
    {
        [OneTimeSetUp]
        public void GlobalSetUp()
        {
            // Find information about AtataContext set-up on https://atata.io/getting-started/#set-up
            AtataContext.GlobalConfiguration
                .UseChrome()
                    .WithArguments("start-maximized")
                .UseBaseUrl("https://cz.careers.veeam.com/vacancies")
                .UseCulture("en-US")
                .UseAllNUnitFeatures()
                .ScreenshotConsumers.AddFile();

            AtataContext.GlobalConfiguration.AutoSetUpDriverToUse();
        }
    }
}
