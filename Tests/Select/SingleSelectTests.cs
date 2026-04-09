using QaPracticeTest.Pages.Select;

namespace QaPracticeTest.Tests.Select
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class SingleSelectTests : PageTest
    {
        private SingleSelectPage SelectPage { get; set; }
        
        [SetUp]
        public void SetUp() => SelectPage = new SingleSelectPage(Page);

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
            await SelectPage.GoToAsync();
            await SelectPage.SelectOption(option);
            await SelectPage.ClickSubmit();
            await Expect(SelectPage.Result).ToHaveTextAsync(option);
        }
    }
}
