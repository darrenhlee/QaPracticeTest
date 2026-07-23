using Microsoft.Playwright;

namespace QaPracticeTest.Pages.NewTab
{
    public class NewTabLinkPage : NewTabPage
    {
        public NewTabLinkPage(IPage page) : base(
            page,
            "https://www.qa-practice.com/elements/new_tab/link",
            page.GetByRole(AriaRole.Link, new() { NameString = "New page will be opened on a new tab" }))
        {
        }
    }
}
