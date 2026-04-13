using QaPracticeTest.Pages.Select;

namespace QaPracticeTest.Tests.Select
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class MultipleSelectTests : PageTest
    {
        private MultipleSelectPage SelectPage { get; set; }

        [SetUp]
        public async Task SetUp()
        {
            SelectPage = new MultipleSelectPage(Page);
            await SelectPage.GoToAsync();
        }

        [Test]
        public async Task FieldNamesAreCorrect()
        {
            await Expect(SelectPage.PlaceSelectLabel).ToContainTextAsync("Choose the place you want to go");
            await Expect(SelectPage.HowSelectLabel).ToContainTextAsync("Choose how you want to get there");
            await Expect(SelectPage.WhenSelectLabel).ToContainTextAsync("Choose when you want to go");
        }

        [Test, Pairwise]
        public async Task AllFieldsAreRequired([Values] bool placeIsBlank, [Values] bool howIsBlank, [Values] bool whenIsBlank)
        {
            if (!placeIsBlank) await SelectPage.SelectPlace(1);
            if (!howIsBlank) await SelectPage.SelectHow(1);
            if (!whenIsBlank) await SelectPage.SelectWhen(1);

            await Expect(SelectPage.PlaceSelect).ToHaveAttributeAsync("required", string.Empty);
            await Expect(SelectPage.HowSelect).ToHaveAttributeAsync("required", string.Empty);
            await Expect(SelectPage.WhenSelect).ToHaveAttributeAsync("required", string.Empty);
        }

        private static List<string> PlaceValues =>
        [
            "Sea",
            "Mountains",
            "Old town",
            "Ocean",
            "Restaurant"
        ];

        private static List<string> HowValues =>
        [
            "Car",
            "Bus",
            "Train",
            "Air"
        ];

        private static List<string> WhenValues =>
        [
            "Today",
            "Tomorrow",
            "Next week"
        ];

        [Test, Pairwise]
        public async Task AnyCombinationOfOptionsCanBeSubmitted(
            [ValueSource(nameof(PlaceValues))] string place,
            [ValueSource(nameof(HowValues))] string how,
            [ValueSource(nameof(WhenValues))] string when)
        {
            await SelectPage.SelectPlace(place);
            await SelectPage.SelectHow(how);
            await SelectPage.SelectWhen(when);
            await SelectPage.ClickSubmit();
            var expectedResult = $"to go by {how} to the {place} {when}".ToLowerInvariant();
            await Expect(SelectPage.Result).ToHaveTextAsync(expectedResult);
        }
    }
}
