using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace QaPracticeTest.Pages
{
    internal class SimpleTextInputPage
    {
        private readonly IPage _page;
        private readonly ILocator _input;
        private readonly ILocator _result;
        private readonly ILocator _errorMessage;

        internal SimpleTextInputPage(IPage page)
        {
            _page = page ?? throw new ArgumentNullException(nameof(page));
            _input = _page.GetByPlaceholder("Submit me");
            _result = _page.Locator("id=result-text");
            _errorMessage = _page.Locator("id=error_1_id_text_string");
        }

        internal async Task GoToAsync() => await _page.GotoAsync("https://www.qa-practice.com/elements/input/simple");

        internal async Task SubmitText(string text)
        {
            await _input.FillAsync(text);
            await _input.PressAsync("Enter");
        }

        internal async Task<string> GetResult() => await _result.InnerTextAsync();

        internal async Task<string> GetErrorMessage() => await _errorMessage.InnerTextAsync();

        internal async Task<bool> IsInputVisible() => await _input.IsVisibleAsync();

        internal async Task<bool> IsInputEnabled() => !await _input.IsDisabledAsync();

        internal async Task<bool> IsInputRequired() => await _input.GetAttributeAsync("required") != null;
    }
}
