using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Checkboxes
{
    internal class SingleCheckboxPage : CheckboxPage
    {
        public SingleCheckboxPage(IPage page) : base(page, "https://www.qa-practice.com/elements/checkbox/single_checkbox")
        {
            //Checkbox = page.GetByRole(AriaRole.Checkbox, new() { NameString = "checkbox" });
        }

        public async Task CheckCheckbox() => await Checkboxes.First.CheckAsync();

        public async Task UncheckCheckbox() => await Checkboxes.First.UncheckAsync();
    }
}
