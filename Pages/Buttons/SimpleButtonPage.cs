using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Buttons
{
    public class SimpleButtonPage : ButtonPage
    {
        public SimpleButtonPage(IPage page) : base(page, "https://www.qa-practice.com/elements/button/simple", page.Locator("id=submit-id-submit"))
        {
        }
    }
}
