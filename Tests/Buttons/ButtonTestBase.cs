using QaPracticeTest.Pages.Buttons;

namespace QaPracticeTest.Tests.Buttons
{
    public abstract class ButtonTestBase : PageTest
    {
        public required IButtonPage ButtonPage { get; set; }
        public required string ExpectedButtonText { get; set; }

        [Test]
        public async Task UserCanClickTheButton()
        {
            await ButtonPage.GoToAsync();
            await Expect(ButtonPage.Button).ToBeEnabledAsync();
            await Expect(ButtonPage.Button).ToHaveTextAsync(ExpectedButtonText);

            await ButtonPage.ClickButton();
            await Expect(ButtonPage.Result).ToHaveTextAsync("Submitted");
        }
    }
}
