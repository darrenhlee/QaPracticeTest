using Microsoft.Playwright;

namespace QaPracticeTest.Pages.NewTab
{
    public abstract class NewTabPage : ResultPage
    {
        public ILocator NewTabLocator { get; private set; }

        protected NewTabPage(IPage page, string url, ILocator newTabLocator) : base(page, url)
        {
            NewTabLocator = newTabLocator;
        }

        public async Task ClickNewTabOpener() => await NewTabLocator.ClickAsync();
    }
}
