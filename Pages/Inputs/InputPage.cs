using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Inputs
{
    abstract public class InputPage : QaPracticePage, IInputPage
    {
        public ILocator Input { get; private set; }
        public ILocator Result { get; private set; }
        public ILocator ErrorMessage { get; private set; }

        public InputPage(IPage page, string url, ILocator errorMessage) : base(page, url)
        {
            Input = page.GetByPlaceholder("Submit me");
            Result = page.Locator("id=result-text");
            ErrorMessage = errorMessage ?? throw new ArgumentNullException(nameof(errorMessage));
        }   

        public async Task SubmitText(string text)
        {
            await Input.FillAsync(text);
            await Input.PressAsync("Enter");
        }

        public async Task<string> GetResult() => await Result.InnerTextAsync();

        public async Task<string> GetErrorMessage() => await ErrorMessage.InnerTextAsync();

        public async Task<bool> IsInputVisible() => await Input.IsVisibleAsync();

        public async Task<bool> IsInputEnabled() => !await Input.IsDisabledAsync();

        public async Task<bool> IsInputRequired() => await Input.GetAttributeAsync("required") != null;
    }
}
