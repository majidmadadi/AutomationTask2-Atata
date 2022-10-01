using Atata;
using AutomationTask2.Tests.PageModels;
using NUnit.Framework;

namespace AutomationTask2.Tests
{
    public class VacanciesSearchResultTests : UITestFixture
    {
        protected VacanciesSearchPage vPage;

        [OneTimeSetUp]
        public void OpenPage()
        {
            vPage = Go.To<VacanciesSearchPage>().CookieScriptClose.Click();
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            vPage.Context.CleanUp();
        }

        [SetUp]
        public void ClearForm()
        {
            vPage.ClearForm();
        }

        [Test]
        [TestCase("", "Research & Development", new[] { "English" }, 11)]
        [TestCase("Webdriver C# best practices", "Research & Development", new[] { "English" }, 0)]
        [TestCase("Page Object", "Research & Development", new[] { "English" }, 0)]
        [TestCase("implicit/explicit waits", "Research & Development", new[] { "English" }, 0)]
        [TestCase("reliable/fragile locators", "Research & Development", new[] { "English" }, 0)]
        [TestCase("NUnit", "Research & Development", new[] { "English" }, 0)]
        public void SearchResultsBeCorrect(string keyword, string department, string[] languages, int numberOfResults)
        {
            vPage
                .SelectDepartment(department)
                .SelectLanguages(languages)
                .Keywords.Set(keyword)
                .SearchResults
                .Should
                .HaveCount(numberOfResults);
        }
    }
}
