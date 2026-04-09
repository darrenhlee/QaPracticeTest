using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Select
{
    public class SingleSelectPage : SelectPage
    {
        public ILocator SingleSelect => _page.GetByLabel("Choose language*");
        //public ILocator SingleSelect => _page.Locator("#id_choose_language");

        public SingleSelectPage(IPage page) : base(page, "https://www.qa-practice.com/elements/select/single_select")
        {
        }

        public async Task SelectOption(string option)
        {
            await SingleSelect.SelectOptionAsync(new[] { new SelectOptionValue() { Label = option } });
        }
    }
}
