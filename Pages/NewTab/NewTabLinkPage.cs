using Microsoft.Playwright;

namespace QaPracticeTest.Pages.NewTab
{
    public class NewTabLinkPage : QaPracticePage
    {
        public ILocator Link { get; private set; }

        public NewTabLinkPage(IPage page) : base(page, "https://www.qa-practice.com/elements/new_tab/link")
        {
            Link = page.GetByRole(AriaRole.Link, new() { NameString = "New page will be opened on a new tab" });
        }

        public async Task ClickLink() => await Link.ClickAsync();
    }
}
