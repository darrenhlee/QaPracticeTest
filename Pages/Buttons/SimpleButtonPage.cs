using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Buttons
{
    public class SimpleButtonPage : ResultPage, IButtonPage
    {
        public ILocator Button { get; private set; }

        public SimpleButtonPage(IPage page) : base(page, "https://www.qa-practice.com/elements/button/simple")
        {
            Button = page.GetByRole(AriaRole.Button, new() { NameString = "Click" });
        }        
    }
}
