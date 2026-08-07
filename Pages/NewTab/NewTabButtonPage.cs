using Microsoft.Playwright;
using QaPracticeTest.Components;

namespace QaPracticeTest.Pages.NewTab
{
    public class NewTabButtonPage : QaPracticePage, INewTabPage
    {
        public ILocator NewTabLocator { get; private set; }
        public Result Result { get; private set; }

        public NewTabButtonPage(IPage page) : base(page, "https://www.qa-practice.com/elements/new_tab/button")
        {
            NewTabLocator = page.GetByRole(AriaRole.Link, new() { NameString = "Click" });
            Result  = new Result(page);
        }
    }
}
