using QaPracticeTest.Pages.Checkboxes;

namespace QaPracticeTest.Tests.Checkboxes
{
    public class MultipleCheckboxTests : PageTest
    {
        private MultipleCheckboxPage CheckboxPage { get; set; }

        [SetUp]
        public async Task SetUp()
        {
            CheckboxPage = new MultipleCheckboxPage(Page);
            await CheckboxPage.GoToAsync();
        }

        [Test]
        public async Task NumberOfCheckboxesIsCorrect() => await Expect(CheckboxPage.Checkboxes).ToHaveCountAsync(3);

        [Test]
        public async Task LabelsOfCheckboxesAreCorrect()
        {
            var expectedLabels = new[]
            {
                "One",
                "Two",
                "Three"
            };

            for (var i = 0; i < expectedLabels.Length; i++)
            {
                var checkboxID = await CheckboxPage.Checkboxes.Nth(i).GetAttributeAsync("id");
                if (checkboxID is not null)
                {
                    var label = Page.Locator($"[for={checkboxID}]");
                    await Expect(label).ToHaveTextAsync(expectedLabels[i]);
                }
            }
        }
    }
}
