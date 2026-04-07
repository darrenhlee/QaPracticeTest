namespace QaPracticeTest.Tests.Inputs
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class SimpleTextInputTests : InputTestBase
    {
        [SetUp]
        public void SetUp()
        {
            InputPage = new Pages.SimpleTextInputPage(Page);
        }

        private static IEnumerable<string> ValidInputTestCases()
        {
            yield return "Ab";
            yield return "A1_-z";
            yield return "x".PadLeft(25, 'x');
        }

        [TestCaseSource(nameof(ValidInputTestCases))]
        public new async Task UserCanSubmitValidStrings(string text) => await base.UserCanSubmitValidStrings(text);

        private static IEnumerable<InvalidInputTestCase> InvalidInputWithExpectedError()
        {
            yield return new InvalidInputTestCase
            {
                Input = "A",
                ExpectedError = "Please enter 2 or more characters"
            }; // Too short
            yield return new InvalidInputTestCase
            {
                Input = "x".PadLeft(26, 'x'),
                ExpectedError = "Please enter no more than 25 characters"
            }; // Too long
            yield return new InvalidInputTestCase
            {
                Input = "Invalid!@#",
                ExpectedError = "Enter a valid string consisting of letters, numbers, underscores or hyphens."
            }; // Contains allowed and disallowed characters
            yield return new InvalidInputTestCase
            {
                Input = "Ĩňvąŀīď",
                ExpectedError = "Enter a valid string consisting of letters, numbers, underscores or hyphens."
            }; // Contains disallowed characters
        }

        [TestCaseSource(nameof(InvalidInputWithExpectedError))]
        public new async Task InvalidTextIsRejected(InvalidInputTestCase testCase) => await base.InvalidTextIsRejected(testCase);
    }
}