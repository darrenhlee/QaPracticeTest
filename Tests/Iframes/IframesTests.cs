using QaPracticeTest.Pages.Iframes;

namespace QaPracticeTest.Tests.Iframes
{
    public class IframesTests : PageTest
    {
        private IframePage IframePage { get; set; }

        [SetUp]
        public async Task SetUp()
        {
            IframePage = new IframePage(Page);
            await IframePage.GoToAsync();
        }

        [Test]
        public async Task IframeIsVisible()
        {
            await Expect(IframePage.Iframe).ToBeVisibleAsync();
            const string expectedLeadText = "Something short and leading about the collection below—its contents, the creator, etc. " +
                "Make it short and sweet, but not too short so folks don’t simply skip over it entirely.";
            await Expect(IframePage.AlbumPage.PageContent).ToContainTextAsync(expectedLeadText);
        }
    }
}
