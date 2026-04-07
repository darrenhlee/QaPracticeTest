using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Inputs
{
    abstract public class InputPage : QaPracticePage, IInputPage
    {
        protected readonly ILocator _input;
        protected readonly ILocator _result;
        protected readonly ILocator _errorMessage;

        public InputPage(IPage page, string url, ILocator input, ILocator result, ILocator errorMessage) : base(page, url)
        {
            _input = input ?? throw new ArgumentNullException(nameof(input));
            _result = result ?? throw new ArgumentNullException(nameof(result));
            _errorMessage = errorMessage ?? throw new ArgumentNullException(nameof(errorMessage));
        }   

        public async Task SubmitText(string text)
        {
            await _input.FillAsync(text);
            await _input.PressAsync("Enter");
        }

        public async Task<string> GetResult() => await _result.InnerTextAsync();

        public async Task<string> GetErrorMessage() => await _errorMessage.InnerTextAsync();

        public async Task<bool> IsInputVisible() => await _input.IsVisibleAsync();

        public async Task<bool> IsInputEnabled() => !await _input.IsDisabledAsync();

        public async Task<bool> IsInputRequired() => await _input.GetAttributeAsync("required") != null;
    }
}
