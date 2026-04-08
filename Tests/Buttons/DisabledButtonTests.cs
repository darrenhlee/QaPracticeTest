using QaPracticeTest.Pages.Buttons;

namespace QaPracticeTest.Tests.Buttons
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class DisabledButtonTests : PageTest
    {
        public required DisabledButtonPage ButtonPage { get; set; }

        [SetUp]
        public void SetUp()
        {
            ButtonPage = new DisabledButtonPage(Page);
        }

        [Test]
        public async Task ButtonIsDisabledByDefault()
        {
            await ButtonPage.GoToAsync();
            await Expect(ButtonPage.Button).ToBeDisabledAsync();
        }

        [Test]
        public async Task UserCanEnableAndDisableTheButton()
        {
            await ButtonPage.GoToAsync();

            await ButtonPage.EnableButton();
            await Expect(ButtonPage.Button).ToBeEnabledAsync();

            await ButtonPage.DisableButton();
            await Expect(ButtonPage.Button).ToBeDisabledAsync();
        }

        [Test]
        public async Task UserCanClickTheButton()
        {
            await ButtonPage.GoToAsync();
            await ButtonPage.EnableButton();
            await Expect(ButtonPage.Button).ToBeEnabledAsync();
            await ButtonPage.ClickButton();
            await Expect(ButtonPage.Result).ToHaveTextAsync("Submitted");
        }
    }
}
