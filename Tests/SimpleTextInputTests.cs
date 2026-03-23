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
    }
}
