using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Checkboxes
{
    public abstract class CheckboxPage : ResultPage
    {
        public ILocator Checkboxes { get; private set; }
        public ILocator SubmitButton { get; private set; }

        public CheckboxPage(IPage page, string url) : base(page, url)
        {
            SubmitButton = page.GetByRole(AriaRole.Button, new() { NameString = "Submit" });
            Checkboxes = page.GetByRole(AriaRole.Checkbox);
        }

        public async Task ClickSubmit() => await SubmitButton.ClickAsync();
    }
}
