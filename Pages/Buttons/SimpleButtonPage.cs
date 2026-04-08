using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Buttons
{
    public class SimpleButtonPage : ButtonPage
    {
        public SimpleButtonPage(IPage page) : base(page, "https://www.qa-practice.com/elements/button/simple", page.GetByRole(AriaRole.Button, new() { NameString = "Click" }))
        {
        }
    }
}
