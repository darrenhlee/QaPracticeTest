using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Buttons
{
    public interface IButtonPage : IQaPracticePage
    {
        public ILocator Button { get; }
        public ILocator Result { get; }
        public async Task ClickButton() => await Button.ClickAsync();
    }
}
