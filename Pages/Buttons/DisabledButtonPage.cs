using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Buttons
{
    public class DisabledButtonPage : QaPracticePage, IButtonPage
    {
        public ILocator SelectState => Page.Locator("id=id_select_state");
        public ILocator Button { get; private set; }
        public Result Result { get; }

        public DisabledButtonPage(IPage page) : base(page, "https://www.qa-practice.com/elements/button/disabled")
        {
            Button = page.GetByRole(AriaRole.Button, new() { NameString = "Submit" });
            Result = new Result(page);
        }

        public async Task EnableButton() => await SelectState.SelectOptionAsync("enabled");

        public async Task DisableButton() => await SelectState.SelectOptionAsync("disabled");

        public async Task ClickButton() => await Button.ClickAsync();
    }
}
