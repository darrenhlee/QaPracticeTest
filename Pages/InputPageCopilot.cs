using Microsoft.Playwright;

namespace QaPracticeTest.Pages
{
    public class InputPageCopilot
    {
        private readonly IPage _page;

        // Selectors - adapt if the real page uses different IDs/classes.
        private readonly string _url = "https://www.qa-practice.com/elements/input/simple";
        private readonly string _inputSelector = "input[type=\"text\"], input";
        private readonly string[] _resultSelectors = new[] { "#result", "#output", ".result", ".submitted", ".submitted-text", "p#result", "div.result" };

        public InputPageCopilot(IPage page)
        {
            _page = page ?? throw new ArgumentNullException(nameof(page));
        }

        public async Task<InputPageCopilot> NavigateAsync()
        {
            await _page.GotoAsync(_url);
            return this;
        }

        public ILocator Input => _page.Locator(_inputSelector);

        public async Task<bool> IsVisibleAsync() => await Input.IsVisibleAsync();

        public async Task<bool> IsEnabledAsync() => !await Input.IsDisabledAsync();

        public async Task<bool> HasRequiredAttributeAsync()
        {
            var attr = await Input.GetAttributeAsync("required");
            return attr != null;
        }

        public async Task<InputPageCopilot> ClearAsync()
        {
            await Input.FillAsync(string.Empty);
            return this;
        }

        public async Task<InputPageCopilot> EnterTextAsync(string text)
        {
            await Input.FillAsync(text);
            return this;
        }

        public async Task<string> GetInputValueAsync()
        {
            return await Input.InputValueAsync();
        }

        public async Task<InputPageCopilot> SubmitWithEnterAsync()
        {
            // Use Press to simulate Enter on the input field.
            await Input.PressAsync("Enter");
            // allow potential navigation/submission effects to settle
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            return this;
        }

        public async Task<string?> GetSubmittedTextByKnownSelectorsAsync()
        {
            foreach (var sel in _resultSelectors)
            {
                var locator = _page.Locator(sel);
                if (await locator.CountAsync() > 0 && await locator.IsVisibleAsync())
                {
                    var text = (await locator.AllInnerTextsAsync()).FirstOrDefault(t => !string.IsNullOrWhiteSpace(t));
                    if (!string.IsNullOrWhiteSpace(text))
                        return text.Trim();
                }
            }

            return null;
        }

        public async Task<string?> FindSubmittedTextAnywhereAsync(string expected)
        {
            // First try known selectors
            var fromKnown = await GetSubmittedTextByKnownSelectorsAsync();
            if (!string.IsNullOrEmpty(fromKnown))
                return fromKnown;

            // Fallback: find an element (not an input) whose trimmed textContent exactly equals expected
            var script = @"(expected) => {
                const elements = Array.from(document.body.querySelectorAll('*'));
                for (const el of elements) {
                    if (el.tagName.toLowerCase() === 'input' || el.tagName.toLowerCase() === 'textarea' || el.tagName.toLowerCase() === 'select') continue;
                    const text = el.textContent ? el.textContent.trim() : '';
                    if (text === expected) return text;
                }
                return null;
            }";
            return await _page.EvaluateAsync<string?>(script, expected);
        }

        public async Task<bool> HasSubmittedTextAsync(string expected)
        {
            var found = await FindSubmittedTextAnywhereAsync(expected);
            return !string.IsNullOrEmpty(found);
        }
    }
}