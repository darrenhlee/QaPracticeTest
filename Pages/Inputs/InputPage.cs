using Microsoft.Playwright;
using QaPracticeTest.Components;

namespace QaPracticeTest.Pages.Inputs
{
    abstract public class InputPage(IPage page, string url, ILocator errorMessage) : QaPracticePage(page, url), IInputPage
    {
        public ILocator Input { get; private set; } = page.GetByPlaceholder("Submit me");
        public ILocator ErrorMessage { get; private set; } = errorMessage ?? throw new ArgumentNullException(nameof(errorMessage));
        public Result Result { get; private set; } = new Result(page);

        public async Task SubmitText(string text)
        {
            await Input.FillAsync(text);
            await Input.PressAsync("Enter");
        }

        public async Task<string> GetResult() => await Result.ResultText.InnerTextAsync();

        public async Task<string> GetErrorMessage() => await ErrorMessage.InnerTextAsync();

        public async Task<bool> IsInputVisible() => await Input.IsVisibleAsync();

        public async Task<bool> IsInputEnabled() => !await Input.IsDisabledAsync();

        public async Task<bool> IsInputRequired() => await Input.GetAttributeAsync("required") != null;
    }
}
