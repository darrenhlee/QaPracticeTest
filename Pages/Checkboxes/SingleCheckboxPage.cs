using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Checkboxes
{
    internal class SingleCheckboxPage : CheckboxPage
    {
        public ILocator Label
        {
            get
            {
                var id = Checkboxes.First.GetAttributeAsync("id").Result;
                return _page.Locator($"[for={id}]");
            }
        }

        public SingleCheckboxPage(IPage page) : base(page, "https://www.qa-practice.com/elements/checkbox/single_checkbox")
        {
        }

        public async Task CheckCheckbox() => await Checkboxes.First.CheckAsync();

        public async Task UncheckCheckbox() => await Checkboxes.First.UncheckAsync();
    }
}
