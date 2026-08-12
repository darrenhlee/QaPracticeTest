using QaPracticeTest.Pages.PopUp;

namespace QaPracticeTest.Tests.PopUp
{
    [Parallelizable(ParallelScope.Self)]
    public class IFramePopUpTests : PageTest
    {
        private IframePopUpPage IframePopUpPage { get; set; }

        [SetUp]
        public async Task SetUp()
        {
            IframePopUpPage = new IframePopUpPage(Page);
            await IframePopUpPage.GoToAsync();
            await IframePopUpPage.LaunchPopUpButton.ClickAsync();
        }

        const string expectedCopyText = "I am the text you want to copy";

        public static readonly List<object> UserCanSubmitTextCopiedFromModalTestCases =
        [
            new object[] 
            {
                expectedCopyText, 
                "Correct!" 
            },
            new object[] 
            { 
                "I am not the text you want to copy", 
                "Nope. Better luck next time!"
            }
        ];

        [TestCaseSource(nameof(UserCanSubmitTextCopiedFromModalTestCases))]
        public async Task UserCanSubmitTextCopiedFromModal(string inputText, string expectedResultText)
        {
            await Expect(IframePopUpPage.Modal.Title).ToHaveTextAsync("Iframe page title");
            await Expect(IframePopUpPage.Modal.TextToCopy).ToHaveTextAsync(expectedCopyText);

            await IframePopUpPage.Modal.CheckButton.ClickAsync();

            await IframePopUpPage.TextFromIframeInput.FillAsync(inputText);
            await Expect(IframePopUpPage.TextFromIframeInput).ToHaveValueAsync(inputText);

            await IframePopUpPage.SubmitButton.ClickAsync();
            await Expect(IframePopUpPage.CheckResult).ToHaveTextAsync(expectedResultText);
        }

        [Test]
        public async Task InputDoesNotAppearWhenModalIsClosed()
        {
            await IframePopUpPage.Modal.CloseButton.ClickAsync();
            await Expect(IframePopUpPage.TextFromIframeInput).Not.ToBeVisibleAsync();
        }

        [Test]
        public async Task InputDoesNotAppearWhenModalIsXClosed()
        {
            await IframePopUpPage.Modal.CloseXButton.ClickAsync();
            await Expect(IframePopUpPage.TextFromIframeInput).Not.ToBeVisibleAsync();
        }
    }
}
