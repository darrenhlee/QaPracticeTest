using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Iframes
{
    public class IframeAlbumPage(IFrameLocator frameLocator)
    {
        public IFrameLocator FrameLocator { get; } = frameLocator;
        public ILocator PageContent => FrameLocator.Locator("div.page-content");
    }
}
