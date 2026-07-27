using Microsoft.Playwright;

namespace QaPracticeTest.Pages.TextArea
{
    public class SingleTextAreaPage(IPage page) : ResultPage(page, "https://www.qa-practice.com/elements/textarea/single")
    {
        public ILocator TextArea => _page.GetByRole(AriaRole.Textbox, new() { NameString = "Text area*" });
        public ILocator SubmitButton => _page.GetByRole(AriaRole.Button, new() { NameString = "Submit" });
    }
}
