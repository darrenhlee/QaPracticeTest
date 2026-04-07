using QaPracticeTest.Pages.Inputs;

namespace QaPracticeTest.Tests.Inputs
{
    public abstract class InputTestBase : PageTest
    {
        public required IInputPage InputPage { get; set; }

        public class InvalidInputTestCase
        {
            public required string Input { get; set; }
            public required string ExpectedError { get; set; }

            public override string ToString() => $"Input: '{Input}' | Expected: '{ExpectedError}'";
        }

        [Test]
        public async Task InputIsVisibleAndEnabled()
        {
            await InputPage.GoToAsync();
            Assert.That(await InputPage.IsInputVisible(), Is.True);
            Assert.That(await InputPage.IsInputEnabled(), Is.True);
        }

        protected async Task UserCanSubmitValidStrings(string text)
        {
            await InputPage.GoToAsync();
            await InputPage.SubmitText(text);
            var result = await InputPage.GetResult();
            Assert.That(result, Is.EqualTo(text));
        }

        [Test]
        public async Task InputIsRequired()
        {
            await InputPage.GoToAsync();
            Assert.That(await InputPage.IsInputRequired(), Is.True);
        }

        protected async Task InvalidTextIsRejected(InvalidInputTestCase testCase)
        {
            await InputPage.GoToAsync();
            await InputPage.SubmitText(testCase.Input);
            Assert.That(await InputPage.GetErrorMessage(), Is.EqualTo(testCase.ExpectedError));
        }
    }
}
