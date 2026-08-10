using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Iframes
{
    public class IframePage : QaPracticePage
    {
        public IframePage(IPage page) : base(page, "/elements/iframe/iframe_page")
        {
        }

        public ILocator Iframe => Page.Locator("iframe");
        public IFrameLocator FrameContent => Page.FrameLocator("iframe");
        public IframeAlbumPage AlbumPage => new IframeAlbumPage(FrameContent);
    }
}
