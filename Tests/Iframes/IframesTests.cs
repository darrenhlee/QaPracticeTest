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
            await Expect(IframePage.FrameContent.Locator("div.page-content")).ToHaveTextAsync(new Regex(".+"));
        }
    }
}
