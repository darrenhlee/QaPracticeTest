using QaPracticeTest.Pages.NewTab;

namespace QaPracticeTest.Tests.NewTab
{
    public abstract class NewTabTestBase : PageTest
    {
        public required INewTabPage NewTabPage { get; set; }

        [Test]
        public async Task OpenNewTab()
        {
            var newTab = new NewPage(await Context.RunAndWaitForPageAsync(NewTabPage.ClickNewTabOpener));
            await Expect(newTab.Result).ToHaveTextAsync("I am a new page in a new tab");
        }
    }
}
