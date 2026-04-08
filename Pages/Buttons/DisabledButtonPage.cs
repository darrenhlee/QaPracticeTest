using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Buttons
{
    public class DisabledButtonPage : ButtonPage
    {
        public ILocator SelectState { get; private set; }

        public DisabledButtonPage(IPage page) : base(page, "https://www.qa-practice.com/elements/button/disabled", page.GetByRole(AriaRole.Button, new()
        { NameString = "Submit" }))
        {
            SelectState = page.Locator("id=id_select_state");
        }

        public async Task EnableButton() => await SelectState.SelectOptionAsync("enabled");

        public async Task DisableButton() => await SelectState.SelectOptionAsync("disabled");
    }
}
