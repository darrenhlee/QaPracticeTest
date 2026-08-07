using Microsoft.Playwright;
using QaPracticeTest.Components;

namespace QaPracticeTest.Pages.Select
{
    public abstract class SelectPage(IPage page, string url) : QaPracticePage(page, url)
    {
        public ILocator SubmitButton => Page.GetByRole(AriaRole.Button, new() { NameString = "Submit" });
        public Result Result { get; private set; } = new Result(page);

        public async Task ClickSubmit() => await SubmitButton.ClickAsync();
    }
}
