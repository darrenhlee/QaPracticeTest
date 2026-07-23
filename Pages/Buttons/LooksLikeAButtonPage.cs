using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Buttons
{
    public class LooksLikeAButtonPage : ResultPage, IButtonPage
    {
        public ILocator Button { get; private set; }

        public LooksLikeAButtonPage(IPage page) : base(page, "https://www.qa-practice.com/elements/button/like_a_button")
        {
            Button = page.GetByRole(AriaRole.Link, new() { NameString = "Click" });
        }
    }
}
