using Microsoft.Playwright;

namespace QaPracticeTest.Pages.TextArea
{
    public class MultipleTextAreasPage : ResultPage
    {
        public ILocator FirstChapter => _page.GetByRole(AriaRole.Textbox, new() { NameString = "First chapter*" });
        public ILocator SecondChapter => _page.GetByRole(AriaRole.Textbox, new() { NameString = "Second chapter" });
        public ILocator ThirdChapter => _page.GetByRole(AriaRole.Textbox, new() { NameString = "Third chapter" });
        public ILocator SubmitButton => _page.GetByRole(AriaRole.Button, new() { NameString = "Submit" });

        public MultipleTextAreasPage(IPage page) : base(page, $"{BaseUrl}/elements/textarea/textareas")
        {
        }
    }
}
