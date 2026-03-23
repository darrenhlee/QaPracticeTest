using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaPracticeTest.Pages
{
    internal class SimpleTextInputPage
    {
        private readonly IPage _page;
        private readonly ILocator _input;

        public SimpleTextInputPage(IPage page)
        {
            _page = page ?? throw new ArgumentNullException(nameof(page));
            _input = _page.GetByPlaceholder("Submit me");
        }

        public async Task GoToAsync() => await _page.GotoAsync("https://www.qa-practice.com/elements/input/simple");

        public async Task SubmitText(string text)
        {
            await _input.FillAsync(text);
            await _input.PressAsync("Enter");
        }

        public async Task<bool> IsInputVisible() => await _input.IsVisibleAsync();

        public async Task<bool> IsInputEnabled() => !await _input.IsDisabledAsync();
    }
}
