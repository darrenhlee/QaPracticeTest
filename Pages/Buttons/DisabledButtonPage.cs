using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Buttons
{
    public class DisabledButtonPage : ResultPage, IButtonPage
    {
        public ILocator SelectState => Page.Locator("id=id_select_state");
        public ILocator Button { get; private set; }

        public DisabledButtonPage(IPage page) : base(page, "https://www.qa-practice.com/elements/button/disabled")
        {
            Button = page.GetByRole(AriaRole.Button, new() { NameString = "Submit" });
        }

        public async Task EnableButton() => await SelectState.SelectOptionAsync("enabled");

        public async Task DisableButton() => await SelectState.SelectOptionAsync("disabled");

        public async Task ClickButton() => await Button.ClickAsync();
    }
}
