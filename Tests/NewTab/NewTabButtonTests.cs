using QaPracticeTest.Pages.NewTab;

namespace QaPracticeTest.Tests.NewTab
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class NewTabButtonTests : NewTabTestBase
    {
        [SetUp]
        public async Task SetUp()
        {
            NewTabPage = new NewTabButtonPage(Page);
            await NewTabPage.GoToAsync();
        }
    }
}
