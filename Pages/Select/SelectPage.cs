using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Select
{
    public abstract class SelectPage : ResultPage
    {
        public ILocator SubmitButton => _page.GetByRole(AriaRole.Button, new() { NameString = "Submit" });

        public SelectPage(IPage page, string url) : base(page, url)
        {
        }

        public async Task ClickSubmit() => await SubmitButton.ClickAsync();
    }
}
