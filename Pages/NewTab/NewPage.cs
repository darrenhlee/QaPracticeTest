using Microsoft.Playwright;
using QaPracticeTest.Components;

namespace QaPracticeTest.Pages.NewTab
{
    public class NewPage(IPage page) : QaPracticePage(page, "https://www.qa-practice.com/elements/new_tab/new_page")
    {
        public Result Result { get; private set; } = new Result(page);
    }
}
