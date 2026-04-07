namespace QaPracticeTest.Tests.Inputs
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class EmailInputTests : InputTestBase
    {
        [SetUp]
        public void SetUp()
        {
            InputPage = new Pages.Inputs.EmailTextInputPage(Page);
        }

        private static IEnumerable<string> ValidInputTestCases()
        {
            yield return "a@b.ca";
            yield return "AbuG0123.456789!#$%&'*+-/=?^_`{|}~@localhost";
        }

        [TestCaseSource(nameof(ValidInputTestCases))]
        public new async Task UserCanSubmitValidStrings(string text) => await base.UserCanSubmitValidStrings(text);

        private const string InvalidEmailError = "Enter a valid email address.";

        private static IEnumerable<InvalidInputTestCase> InvalidInputWithExpectedError()
        {
            yield return new InvalidInputTestCase
            {
                Input = "A@a.",
                ExpectedError = InvalidEmailError
            }; // Missing TLD.
            yield return new InvalidInputTestCase
            {
                Input = "A@a",
                ExpectedError = InvalidEmailError
            }; // Missing dot and TLD.
            yield return new InvalidInputTestCase
            {
                Input = "a.ca",
                ExpectedError = InvalidEmailError
            }; // Missing local part.
            yield return new InvalidInputTestCase
            {
                Input = "John..Doe@example.com",
                ExpectedError = InvalidEmailError
            }; // Contains consecutive dots in the local part.
            yield return new InvalidInputTestCase
            {
                Input = ".JohnDoe@example.com",
                ExpectedError = InvalidEmailError
            }; // Contains a dot at the start of the local part.
            yield return new InvalidInputTestCase
            {
                Input = "JohnDoe.@example.com",
                ExpectedError = InvalidEmailError
            }; // Contains a dot at the end of the local part.
            yield return new InvalidInputTestCase
            {
                Input = "\\\"(),:;<>@[\\]@example.com",
                ExpectedError = InvalidEmailError
            }; // Contains special characters in the local part that are not allowed without quotes.
        }

        [TestCaseSource(nameof(InvalidInputWithExpectedError))]
        public new async Task InvalidTextIsRejected(InvalidInputTestCase testCase) => await base.InvalidTextIsRejected(testCase);
    }
}
