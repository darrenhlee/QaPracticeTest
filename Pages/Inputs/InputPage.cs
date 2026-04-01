using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaPracticeTest.Pages.Inputs
{
    abstract internal class InputPage : QaPracticePage
    {
        protected readonly ILocator _input;
        protected readonly ILocator _result;
        protected readonly ILocator _errorMessage;

        internal InputPage(IPage page, string url, ILocator input, ILocator result, ILocator errorMessage) : base(page, url)
        {
            _input = input ?? throw new ArgumentNullException(nameof(input));
            _result = result ?? throw new ArgumentNullException(nameof(result));
            _errorMessage = errorMessage ?? throw new ArgumentNullException(nameof(errorMessage));
        }   

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
