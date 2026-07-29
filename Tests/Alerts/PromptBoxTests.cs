using QaPracticeTest.Pages.Alerts;

namespace QaPracticeTest.Tests.Alerts
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class PromptBoxTests : PageTest
    {
        private PromptBoxPage PromptBoxPage { get; set; }

        [SetUp]
        public async Task SetUp()
        {
            PromptBoxPage = new PromptBoxPage(Page);
            await PromptBoxPage.GoToAsync();
            await PromptBoxPage.ClickButton.ClickAsync();
        }

        private static readonly string[] promptTexts =
        [
            "Hello, World!",
            string.Empty
        ];

        [TestCaseSource(nameof(promptTexts))]
        public async Task UserCanEnterPromptTextAndAccept(string promptText)
        {
            await PromptBoxPage.AssertDialogMessageAndAccept(expectedMessage: "Please enter some text", promptText: promptText);
            await Expect(PromptBoxPage.Result).ToHaveTextAsync(promptText == string.Empty ? "You entered nothing" : promptText);
        }

        [Test]
        public async Task UserCanDismissPromptBox()
        {
            await PromptBoxPage.AssertDialogMessageAndDismiss(expectedMessage: "Please enter some text");
            await Expect(PromptBoxPage.Result).ToHaveTextAsync("You canceled the prompt");
        }
    }
}
