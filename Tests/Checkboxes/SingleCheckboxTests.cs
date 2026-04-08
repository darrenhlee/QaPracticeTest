using QaPracticeTest.Pages.Checkboxes;

namespace QaPracticeTest.Tests.Checkboxes
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]

    public class SingleCheckboxTests : PageTest
    {
        private SingleCheckboxPage CheckboxPage { get; set; }

        [SetUp]
        public async void SetUp()
        {
            CheckboxPage = new SingleCheckboxPage(Page);
            await CheckboxPage.GoToAsync();
        }

        [Test]
        public async Task ThereIsOnlyOneCheckbox()
        {
            await Expect(CheckboxPage.Checkboxes).ToHaveCountAsync(1);
        }

        [Test]
        public async Task LabelOfCheckboxIsCorrect()
        {
            await Expect(CheckboxPage.Label).ToHaveTextAsync("Select me or not");
        }

        [Test]
        public async Task SubmitButtonIsAlwaysEnabled()
        {
            await Expect(CheckboxPage.SubmitButton).ToBeEnabledAsync();

            await CheckboxPage.CheckCheckbox();
            await Expect(CheckboxPage.SubmitButton).ToBeEnabledAsync();

            await CheckboxPage.UncheckCheckbox();
            await Expect(CheckboxPage.SubmitButton).ToBeEnabledAsync();

        }

        [Test]
        public async Task UserCanSelectCheckboxAndSubmit()
        {
            await CheckboxPage.CheckCheckbox();
            await CheckboxPage.ClickSubmit();
            await Expect(CheckboxPage.Result).ToHaveTextAsync("select me or not");
        }

        [Test]
        public async Task UserCanSubmitWithoutSelectingCheckbox()
        {
            await CheckboxPage.UncheckCheckbox();
            await CheckboxPage.ClickSubmit();
            await Expect(CheckboxPage.Result).Not.ToBeVisibleAsync();
        }
    }
}
