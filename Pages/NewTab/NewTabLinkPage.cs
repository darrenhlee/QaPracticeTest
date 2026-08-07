using Microsoft.Playwright;
using QaPracticeTest.Components;

namespace QaPracticeTest.Pages.NewTab
{
    public class NewTabLinkPage : QaPracticePage, INewTabPage
    {
        public ILocator NewTabLocator { get; set; }
        public Result Result { get; private set; }

        public NewTabLinkPage(IPage page) : base(page,"https://www.qa-practice.com/elements/new_tab/link")
        {
            NewTabLocator = page.GetByRole(AriaRole.Link, new() { NameString = "New page will be opened on a new tab" });
            Result = new Result(page);
        }
    }
}
