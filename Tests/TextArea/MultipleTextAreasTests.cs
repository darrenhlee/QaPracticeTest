using QaPracticeTest.Pages.TextArea;

namespace QaPracticeTest.Tests.TextArea
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class MultipleTextAreasTests : QaPracticeTestBase
    {
        private MultipleTextAreasPage TextAreasPage { get; set; }

        [SetUp]
        public async Task SetUp()
        {
            TextAreasPage = new MultipleTextAreasPage(Page);
            await TextAreasPage.GoToAsync();
        }

        private static readonly List<string> FirstChapterInputs =
        [
            "This is the first input for the first chapter.",
            "Another input for\r\nthe first chapter, with carriage return and newline."
        ];

        private static readonly List<string> SecondChapterInputs =
        [
            "This is the first input for the second chapter.",
            "Another input for\r\nthe second chapter, with carriage return and newline.",
            string.Empty
        ];

        private static readonly List<string> ThirdChapterInputs =
        [
            "This is the first input for the third chapter.",
            "Another input for\r\nthe third chapter, with carriage return and newline.",
            string.Empty
        ];

        [Test, Pairwise]
        public async Task UserCanEnterAndSubmitAnyTextInEachField(
            [ValueSource(nameof(FirstChapterInputs))] string firstChapterInput,
            [ValueSource(nameof(SecondChapterInputs))] string secondChapterInput,
            [ValueSource(nameof(ThirdChapterInputs))] string thirdChapterInput)
        {
            await ExpectFieldNotToBeRequired(TextAreasPage.SecondChapter);
            await ExpectFieldNotToBeRequired(TextAreasPage.ThirdChapter);
            await TextAreasPage.FirstChapter.FillAsync(firstChapterInput);
            await TextAreasPage.SecondChapter.FillAsync(secondChapterInput);
            await TextAreasPage.ThirdChapter.FillAsync(thirdChapterInput);
            await TextAreasPage.SubmitButton.ClickAsync();
            await Expect(TextAreasPage.Result.ResultText).ToHaveTextAsync($"{firstChapterInput}{secondChapterInput}{thirdChapterInput}");
        }

        [Test]
        public async Task FirstChapterIsRequired() => await ExpectFieldToBeRequired(TextAreasPage.FirstChapter);
    }
}
