using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaPracticeTest.Pages.Buttons
{
    abstract public class ButtonPage : QaPracticePage, IButtonPage
    {
        protected readonly ILocator _button;
        protected readonly ILocator _result;

        public ButtonPage(IPage page, string url, ILocator button) : base(page, url)
        {
            _button = button;
            _result = page.Locator("id=result-text");
        }

        public async Task ClickButton() => await _button.ClickAsync();

        public async Task<string> GetResult() => await _result.InnerTextAsync();

        public async Task<bool> IsButtonVisible() => await _button.IsVisibleAsync();

        public async Task<bool> IsButtonEnabled() => !await _button.IsDisabledAsync();

        public async Task<string?> GetButtonLabel() => await _button.GetAttributeAsync("value");
    }
}
