using Microsoft.Playwright;
using QaPracticeTest.Components;

namespace QaPracticeTest.Pages.Checkboxes
{
    public abstract class CheckboxPage : QaPracticePage
    {
        public ILocator Checkboxes { get; private set; }
        public ILocator SubmitButton { get; private set; }
        public Result Result { get; private set; }

        public CheckboxPage(IPage page, string url) : base(page, url)
        {
            SubmitButton = page.GetByRole(AriaRole.Button, new() { NameString = "Submit" });
            Checkboxes = page.GetByRole(AriaRole.Checkbox);
            Result = new Result(page);
        }

        public async Task ClickSubmit() => await SubmitButton.ClickAsync();
    }
}
