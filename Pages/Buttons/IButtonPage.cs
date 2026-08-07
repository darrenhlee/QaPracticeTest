using Microsoft.Playwright;
using QaPracticeTest.Components;

namespace QaPracticeTest.Pages.Buttons
{
    public interface IButtonPage : IQaPracticePage
    {
        internal ILocator Button { get; }
        public Result Result { get; }
        internal async Task ClickButton() => await Button.ClickAsync();
    }
}
