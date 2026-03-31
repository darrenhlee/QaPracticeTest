using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaPracticeTest.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class SimpleTextInputTests : PageTest
    {
        [Test]
        public async Task InputIsVisibleAndEnabled()
        {
            var page = new Pages.SimpleTextInputPage(Page);
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
            var page = new Pages.SimpleTextInputPage(Page);
            await page.GoToAsync();
            await page.SubmitText(text);
            var result = await page.GetResult();
            Assert.That(result, Is.EqualTo(text));
        }

        [Test]
        public async Task InputIsRequired()
        {
            var page = new Pages.SimpleTextInputPage(Page);
            await page.GoToAsync();
            Assert.That(await page.IsInputRequired(), Is.True, "Expected the input to be required.");
        }
    }
}