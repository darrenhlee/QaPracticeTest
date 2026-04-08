using QaPracticeTest.Pages.Checkboxes;

namespace QaPracticeTest.Tests.Checkboxes
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]

    public class SingleCheckboxTests : PageTest
    {
        private SingleCheckboxPage CheckboxPage { get; set; }

        [SetUp]
        public void SetUp()
        {
            CheckboxPage = new SingleCheckboxPage(Page);
        }

        [Test]
        public async Task ThereIsOnlyOneCheckbox()
        {
            await CheckboxPage.GoToAsync();
            await Expect(CheckboxPage.Checkboxes).ToHaveCountAsync(1);
        }

        [Test]
        public async Task LabelOfCheckboxIsCorrect()
        {
            await CheckboxPage.GoToAsync();
            await Expect(CheckboxPage.Label).ToHaveTextAsync("Select me or not");
        }

        [Test]
        public async Task SubmitButtonIsAlwaysEnabled()
        {
            await CheckboxPage.GoToAsync();
            await Expect(CheckboxPage.SubmitButton).ToBeEnabledAsync();

            await CheckboxPage.CheckCheckbox();
            await Expect(CheckboxPage.SubmitButton).ToBeEnabledAsync();

            await CheckboxPage.UncheckCheckbox();
            await Expect(CheckboxPage.SubmitButton).ToBeEnabledAsync();

        }

        [Test]
        public async Task UserCanSelectCheckboxAndSubmit()
        {
            await CheckboxPage.GoToAsync();
            await CheckboxPage.CheckCheckbox();
            await CheckboxPage.ClickSubmit();
            await Expect(CheckboxPage.Result).ToHaveTextAsync("select me or not");
        }

        [Test]
        public async Task UserCanSubmitWithoutSelectingCheckbox()
        {
            await CheckboxPage.GoToAsync();
            await CheckboxPage.UncheckCheckbox();
            await CheckboxPage.ClickSubmit();
            await Expect(CheckboxPage.Result).Not.ToBeVisibleAsync();
        }
    }
}
