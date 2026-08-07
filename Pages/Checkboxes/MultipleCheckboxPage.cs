using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Checkboxes
{
    public class MultipleCheckboxPage(IPage page) : CheckboxPage(page, "https://www.qa-practice.com/elements/checkbox/mult_checkbox")
    {
        public ILocator Checkbox1 => Checkboxes.Nth(0);
        public ILocator Checkbox2 => Checkboxes.Nth(1);
        public ILocator Checkbox3 => Checkboxes.Nth(2);

        public async Task CheckCheckbox(int checkbox) => await Checkboxes.Nth(checkbox - 1).CheckAsync();

    }
}
