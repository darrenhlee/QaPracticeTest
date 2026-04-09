using QaPracticeTest.Pages.Inputs;

namespace QaPracticeTest.Tests.Inputs
{
    public abstract class InputTestBase : PageTest
    {
        public required IInputPage InputPage { get; set; }

        public class InvalidInputTestCase
        {
            public required string Input { get; set; }
            public required string ExpectedError { get; set; }

            public override string ToString() => $"Input: '{Input}' | Expected: '{ExpectedError}'";
        }

        [Test]
        public async Task InputIsVisibleAndEnabled()
        {
            await InputPage.GoToAsync();
            await Expect(InputPage.Input).ToBeVisibleAsync();
            await Expect(InputPage.Input).ToBeEnabledAsync();
        }

        protected async Task UserCanSubmitValidStrings(string text)
        {
            await InputPage.GoToAsync();
            await InputPage.SubmitText(text);
            await Expect(Page.GetByText(text)).ToBeVisibleAsync();
        }

        [Test]
        public async Task InputIsRequired()
        {
            await InputPage.GoToAsync();
            await Expect(InputPage.Input).ToHaveAttributeAsync("required", string.Empty);
        }

        protected async Task InvalidTextIsRejected(InvalidInputTestCase testCase)
        {
            await InputPage.GoToAsync();
            await InputPage.SubmitText(testCase.Input);
            await Expect(InputPage.ErrorMessage).ToHaveTextAsync(testCase.ExpectedError);
        }
    }
}
