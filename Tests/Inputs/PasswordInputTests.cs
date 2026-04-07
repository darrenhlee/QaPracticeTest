namespace QaPracticeTest.Tests.Inputs
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class PasswordInputTests : InputTestBase
    {
        [SetUp]
        public void SetUp()
        {
            InputPage = new Pages.Inputs.PasswordInputPage(Page);
        }

        private static IEnumerable<string> ValidInputTestCases()
        {
            yield return "3pJu*#%Q";
        }

        [TestCaseSource(nameof(ValidInputTestCases))]
        public new async Task UserCanSubmitValidStrings(string text) => await base.UserCanSubmitValidStrings(text);

        private const string ExpectedError = "Low password complexity";

        private static IEnumerable<InvalidInputTestCase> InvalidInputWithExpectedError()
        {
            yield return new InvalidInputTestCase
            {
                Input = "Tpw@6Y&",
                ExpectedError = ExpectedError
            }; // Too short
            yield return new InvalidInputTestCase
            {
                Input = "Password3",
                ExpectedError = ExpectedError
            }; // No special characters
            yield return new InvalidInputTestCase
            {
                Input = "password1$",
                ExpectedError = ExpectedError
            }; // No uppercase letters
            yield return new InvalidInputTestCase
            {
                Input = "PASSWORD1$",
                ExpectedError = ExpectedError
            }; // No lowercase letters
            yield return new InvalidInputTestCase
            {
                Input = "Password$",
                ExpectedError = ExpectedError
            }; // No digits
        }

        [TestCaseSource(nameof(InvalidInputWithExpectedError))]
        public new async Task InvalidTextIsRejected(InvalidInputTestCase testCase) => await base.InvalidTextIsRejected(testCase);
    }
}
