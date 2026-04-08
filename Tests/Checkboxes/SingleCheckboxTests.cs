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
    }
}
