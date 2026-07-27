using QaPracticeTest.Pages.TextArea;

namespace QaPracticeTest.Tests.TextArea
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class SingleTextAreaTests : PageTest
    {
        private SingleTextAreaPage TextAreaPage { get; set; }

        [SetUp]
        public async Task SetUp()
        {
            TextAreaPage = new SingleTextAreaPage(Page);
            await TextAreaPage.GoToAsync();
        }

        [Test]
        public async Task UserCanEnterAndSubmitAnyTextIntoThisField()
        {
            string text = "This is a test\r\ninput for the text area.";
            await TextAreaPage.TextArea.FillAsync(text);
            await TextAreaPage.SubmitButton.ClickAsync();
            await Expect(TextAreaPage.Result).ToHaveTextAsync(text);
        }

        [Test]
        public async Task FieldIsRequired() => await Expect(TextAreaPage.TextArea).ToHaveAttributeAsync("required", string.Empty);
    }
}
