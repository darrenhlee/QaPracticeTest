using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Buttons
{
    public class SimpleButtonPage : QaPracticePage, IButtonPage
    {
        public ILocator Button { get; }
        public Result Result { get; }

        public SimpleButtonPage(IPage page) : base(page, "https://www.qa-practice.com/elements/button/simple")
        {
            Button = page.GetByRole(AriaRole.Button, new() { NameString = "Click" });
            Result = new Result(page);
        }        
    }
}
