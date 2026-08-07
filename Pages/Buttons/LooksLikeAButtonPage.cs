using Microsoft.Playwright;
using QaPracticeTest.Components;

namespace QaPracticeTest.Pages.Buttons
{
    public class LooksLikeAButtonPage : QaPracticePage, IButtonPage
    {
        public ILocator Button { get; }
        public Result Result { get; }

        public LooksLikeAButtonPage(IPage page) : base(page, "https://www.qa-practice.com/elements/button/like_a_button")
        {
            Button = page.GetByRole(AriaRole.Link, new() { NameString = "Click" });
            Result = new Result(page);
        }
    }
}
