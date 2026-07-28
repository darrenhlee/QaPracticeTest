using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Select
{
    public class SingleSelectPage(IPage page) : SelectPage(page, "https://www.qa-practice.com/elements/select/single_select")
    {
        public ILocator SingleSelect => Page.Locator("#id_choose_language");

        public ILocator SelectFieldName => Page.Locator($"[for={SingleSelect.GetAttributeAsync("id").Result}]");

        public async Task SelectOption(string option) => await SingleSelect.SelectOptionAsync([new SelectOptionValue() { Label = option }]);
    }
}
