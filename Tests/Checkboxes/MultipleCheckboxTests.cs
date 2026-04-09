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

        [Test, Pairwise]
        public async Task UserCanSelectAnyCombinationOfCheckboxes(
            [Values] bool selectFirst,
            [Values] bool selectSecond,
            [Values] bool selectThird)
        {
            if (selectFirst) await CheckboxPage.CheckCheckbox(1);
            if (selectSecond) await CheckboxPage.CheckCheckbox(2);
            if (selectThird) await CheckboxPage.CheckCheckbox(3);
            await CheckboxPage.ClickSubmit();

            var expectedResult = string.Join(", ", new[]
            {
                selectFirst ? "one" : null,
                selectSecond ? "two" : null,
                selectThird ? "three" : null
            }.Where(s => s is not null));

            if (selectFirst && selectSecond && selectThird == false)
            { 
                await Expect(CheckboxPage.Result).ToHaveTextAsync(expectedResult); 
            }
            else
            {
                await Expect(CheckboxPage.Result).Not.ToBeVisibleAsync();
            }
        }
    }
}
