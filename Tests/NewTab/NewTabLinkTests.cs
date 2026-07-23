using QaPracticeTest.Pages.NewTab;

namespace QaPracticeTest.Tests.NewTab
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class NewTabLinkTests : NewTabTestBase
    {
        [SetUp]
        public async Task SetUp()
        {
            NewTabPage = new NewTabLinkPage(Page);
            await NewTabPage.GoToAsync();
        }
    }
}
