using Atata;
using static System.Net.Mime.MediaTypeNames;
using _ = AutomationTask2.Tests.PageModels.VacanciesSearchPage;

namespace AutomationTask2.Tests.PageModels
{
    public class VacanciesSearchPage : Page<_>
    {
        [FindById("cookiescript_close")]
        public Clickable<_> CookieScriptClose { get; private set; }

        [FindByPlaceholder("Keyword")]
        public SearchInput<_> Keywords { get; private set; }

        [Term("All departments")]
        public Button<_> Departments { get; private set; }

        [Term("All languages")]
        public Button<_> Languages { get; private set; }

        public _ SelectDepartment(string text)
        {
            if (Departments.Attributes["aria-expanded"].Value == "false")
            {
                Departments.Click();
            }
            Find<Link<_>>(new TermAttribute(text)).Click();
            return this;
        }

        public _ SelectLanguages(string[] languages)
        {
            if (Languages.Attributes["aria-expanded"].Value == "false")
            {
                Languages.Click();
            }
            foreach (var lang in languages)
            {
                Find<CheckBox<_>>(new FindByLabelAttribute(lang)).Check();
            }
            return this;
        }
        /// <summary>
        /// Reliable clear form using javascript. The Clear_filters link is covered 
        /// by drop-down menues and prevents the driver click to work.
        /// </summary>
        public void ClearForm()
        {
            //make sure 'clear filter' is clicked
            var script = @"var btn = document.evaluate(""//button[text()='Clear filters']"", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue; btn.click();";
            Context.Driver.AsScriptExecutor()
            .ExecuteScript(script);
        }

        /// <summary>
        /// Finds search results elements using data-vacancy attribute. 
        /// It's more reliable than using class name.
        /// </summary>
        public ControlList<Link<_>, _> SearchResults
            => FindAll<Link<_>>(new ControlDefinitionAttribute("a[@data-vacancy]"));
    }
}
