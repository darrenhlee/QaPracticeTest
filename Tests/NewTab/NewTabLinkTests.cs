using QaPracticeTest.Pages.NewTab;

namespace QaPracticeTest.Tests.NewTab
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class NewTabLinkTests : PageTest
    {
        [Test]
        public async Task NewTabLinkTest()
        {
            var newPage = new NewTabLinkPage(Page);
            await newPage.GoToAsync();
            var newTab = new NewPage(await Context.RunAndWaitForPageAsync(newPage.ClickLink));
            await Expect(newTab.Result).ToHaveTextAsync("I am a new page in a new tab");
        }
    }
}
