using QaPracticeTest.Pages.Select;

namespace QaPracticeTest.Tests.Select
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class SingleSelectTests : PageTest
    {
        private SingleSelectPage SelectPage { get; set; }

        [SetUp]
        public async Task SetUp()
        {
            SelectPage = new SingleSelectPage(Page);
            await SelectPage.GoToAsync();
        }

        [Test]
        public async Task FieldNameIsCorrect() => await Expect(SelectPage.SelectFieldName).ToContainTextAsync("Choose language");

        [Test]
        public async Task FieldIsRequired() => await Expect(SelectPage.SingleSelect).ToHaveAttributeAsync("required", string.Empty);

        private static List<string> SelectOptions =>
        [
            "Python",
            "Ruby",
            "JavaScript",
            "Java",
            "C#"
        ];

        [TestCaseSource(nameof(SelectOptions))]
        public async Task AnyOptionCanBeSubmitted(string option)
        {
            await SelectPage.SelectOption(option);
            await SelectPage.ClickSubmit();
            await Expect(SelectPage.Result).ToHaveTextAsync(option);
        }
    }
}
