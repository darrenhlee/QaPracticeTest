namespace QaPracticeTest.Tests.Inputs
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class SimpleTextInputTests : PageTest
    {
        public class InvalidInputTestCase
        {
            public string Input { get; set; }
            public string ExpectedError { get; set; }

            public override string ToString() => $"Input: '{Input}' | Expected: '{ExpectedError}'";
        }

        [Test]
        public async Task InputIsVisibleAndEnabled()
        {
            var page = new Pages.EmailTextInputPage(Page);
            await page.GoToAsync();
            Assert.That(await page.IsInputVisible(), Is.True, "Expected the input to be visible.");
            Assert.That(await page.IsInputEnabled(), Is.True, "Expected the input to be enabled.");
        }

        private static IEnumerable<string> ValidInputTestCases()
        {
            yield return "Ab";
            yield return "A1_-z";
            yield return "x".PadLeft(25, 'x');
        }

        [TestCaseSource(nameof(ValidInputTestCases))]
        public async Task UserCanSubmitValidStrings(string text)
        {
            var page = new Pages.EmailTextInputPage(Page);
            await page.GoToAsync();
            await page.SubmitText(text);
            var result = await page.GetResult();
            Assert.That(result, Is.EqualTo(text));
        }

        [Test]
        public async Task InputIsRequired()
        {
            var page = new Pages.EmailTextInputPage(Page);
            await page.GoToAsync();
            Assert.That(await page.IsInputRequired(), Is.True, "Expected the input to be required.");
        }

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
        public async Task InvalidTextIsRejected(InvalidInputTestCase testCase)
        {
            var page = new Pages.EmailTextInputPage(Page);
            await page.GoToAsync();
            await page.SubmitText(testCase.Input);
            Assert.That(await page.GetErrorMessage(), Is.EqualTo(testCase.ExpectedError));
        }
    }
}