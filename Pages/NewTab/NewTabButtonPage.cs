using Microsoft.Playwright;

namespace QaPracticeTest.Pages.NewTab
{
    public class NewTabButtonPage : NewTabPage
    {
        public NewTabButtonPage(IPage page) : base(
            page, 
            "https://www.qa-practice.com/elements/new_tab/button", 
            page.GetByRole(AriaRole.Link, new() { NameString = "Click" }))
        {
        }
    }
}
