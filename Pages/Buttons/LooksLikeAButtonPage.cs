using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Buttons
{
    public class LooksLikeAButtonPage : ButtonPage
    {
        public LooksLikeAButtonPage(IPage page) : base(page, "https://www.qa-practice.com/elements/button/like_a_button", page.GetByRole(AriaRole.Link, new()
        { NameString = "Click" }))
        {
        }
    }
}
