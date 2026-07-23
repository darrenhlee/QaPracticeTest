using QaPracticeTest.Pages.NewTab;

namespace QaPracticeTest.Tests.NewTab
{
    public abstract class NewTabTestBase : PageTest
    {
        [Test]
        public async Task OpenNewTab()
        {
            var page = new NewTabLinkPage(Page);
            await page.GoToAsync();
            var newTab = new NewPage(await Context.RunAndWaitForPageAsync(page.ClickNewTabOpener));
            await Expect(newTab.Result).ToHaveTextAsync("I am a new page in a new tab");
        }
    }
}
