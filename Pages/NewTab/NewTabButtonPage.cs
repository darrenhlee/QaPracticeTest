using Microsoft.Playwright;

namespace QaPracticeTest.Pages.NewTab
{
    public class NewTabButtonPage : ResultPage, INewTabPage
    {
        public ILocator NewTabLocator { get; private set; }

        public NewTabButtonPage(IPage page) : base(page, "https://www.qa-practice.com/elements/new_tab/button")
        {
            NewTabLocator = page.GetByRole(AriaRole.Link, new() { NameString = "Click" });
        }
    }
}
