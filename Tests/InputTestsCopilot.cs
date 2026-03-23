using QaPracticeTest.Pages;

namespace QaPracticeTest.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class InputTestsCopilot : PageTest
    {
        private InputPageCopilot PageObject() => new(Page);

        private static readonly Regex AllowedCharsRegex = new(@"^[A-Za-z0-9_-]+$");

        [Test]
        public async Task Field_IsVisible_RequiredAndEnabled()
        {
            var p = PageObject();
            await p.NavigateAsync();

            Assert.That(await p.IsVisibleAsync(), Is.True, "Input should be visible.");
            Assert.That(await p.IsEnabledAsync(), Is.True, "Input should be enabled.");

            // If the element declares 'required' attribute, assert it; otherwise ensure empty submit does not display a value.
            if (await p.HasRequiredAttributeAsync())
            {
                Assert.Pass("Input has 'required' attribute.");
            }
            else
            {
                // Try submitting empty and assert nothing is displayed
                await p.ClearAsync();
                await p.SubmitWithEnterAsync();
                var emptyDisplayed = await p.HasSubmittedTextAsync(string.Empty);
                Assert.That(emptyDisplayed, Is.False, "Empty submission should not display a submitted value.");
            }
        }

        private static IEnumerable<string> ValidInputTestCases()
        {
            yield return "Ab";
            yield return "A1";
            yield return "Valid_Name-123";
            yield return "x".PadLeft(25, 'x');
        }

        [TestCaseSource(nameof(ValidInputTestCases))]
        public async Task ValidInput_SubmitsAndDisplays(string value)
        {
            // Ensure allowed chars and length
            Assert.That(value.Length, Is.InRange(2, 25), "Test value must be within length constraints.");
            Assert.That(AllowedCharsRegex.IsMatch(value), Is.True, "Test value must contain only allowed characters.");

            var p = PageObject();
            await p.NavigateAsync();

            await p.ClearAsync();
            await p.EnterTextAsync(value);

            // Verify input reflects typed value
            var inputValue = await p.GetInputValueAsync();
            Assert.That(inputValue, Is.EqualTo(value), "Input should reflect the typed value.");

            await p.SubmitWithEnterAsync();

            // After submission, the entered text should be displayed on the page
            var displayed = await p.FindSubmittedTextAnywhereAsync(value);
            Assert.That(displayed, Is.EqualTo(value), "After submission the entered text should be displayed on the page.");
        }

        private static IEnumerable<string> TooShortInputValues()
        {
            yield return "A";
            yield return "".PadLeft(1, 'a');
            yield return string.Empty;
        }

        [TestCaseSource(nameof(TooShortInputValues))]
        public async Task TooShortInput_IsRejected_OnSubmit(string value)
        {
            Assert.That(value.Length, Is.LessThan(2), "Test precondition: value is shorter than min length.");

            var p = PageObject();
            await p.NavigateAsync();

            await p.ClearAsync();
            await p.EnterTextAsync(value);
            await p.SubmitWithEnterAsync();

            var displayed = await p.HasSubmittedTextAsync(value);
            Assert.That(displayed, Is.False, "Input shorter than minimum length should not be accepted for submission.");
        }

        [Test]
        public async Task TooLongInput_IsRejected_OnSubmit()
        {
            var value = new string('a', 26);
            Assert.That(value.Length, Is.GreaterThan(25), "Test precondition: value is longer than max length.");

            var p = PageObject();
            await p.NavigateAsync();

            await p.ClearAsync();
            await p.EnterTextAsync(value);
            await p.SubmitWithEnterAsync();

            var displayed = await p.HasSubmittedTextAsync(value);
            Assert.That(displayed, Is.False, "Input longer than maximum length should not be accepted for submission.");
        }

        [TestCase("Invalid!"), TestCase("bad@chars"), TestCase("space notallowed")]
        public async Task InvalidCharacters_AreRejected_OnSubmit(string value)
        {
            Assert.That(AllowedCharsRegex.IsMatch(value), Is.False, "Precondition: value contains invalid characters.");

            var p = PageObject();
            await p.NavigateAsync();

            await p.ClearAsync();
            await p.EnterTextAsync(value);

            // Input may accept the characters in-field; ensure input reflects typed value
            var inputValue = await p.GetInputValueAsync();
            Assert.That(inputValue, Is.EqualTo(value), "Input should reflect what the user typed (field-level).");

            await p.SubmitWithEnterAsync();

            // The form should not accept submission of invalid-character strings
            var displayed = await p.HasSubmittedTextAsync(value);
            Assert.That(displayed, Is.False, "Input containing invalid characters should not be accepted for submission.");
        }
    }
}