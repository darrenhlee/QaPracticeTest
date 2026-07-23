using Microsoft.Playwright;

namespace QaPracticeTest.Pages.NewTab
{
    public class NewPage : ResultPage
    {
        public NewPage(IPage page) : base(page, "https://www.qa-practice.com/elements/new_tab/new_page")
        {
        }
    }
}
