using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Iframes
{
    public class IframeAlbumPage
    {
        public IFrameLocator FrameLocator { get; }
        public ILocator PageContent => FrameLocator.Locator("div.page-content");

        public IframeAlbumPage(IFrameLocator frameLocator)
        {
            FrameLocator = frameLocator;
        }
    }
}
