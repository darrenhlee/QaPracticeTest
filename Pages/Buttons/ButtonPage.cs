using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Buttons
{
    abstract public class ButtonPage : QaPracticePage, IButtonPage
    {
        public ILocator Button { get; private set; }
        public ILocator Result { get; private set; }

        public ButtonPage(IPage page, string url, ILocator button) : base(page, url)
        {
            Button = button;
            Result = page.Locator("id=result-text");
        }

        public async Task ClickButton() => await Button.ClickAsync();
    }
}
