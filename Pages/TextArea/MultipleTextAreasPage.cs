using Microsoft.Playwright;

namespace QaPracticeTest.Pages.TextArea
{
    public class MultipleTextAreasPage : ResultPage
    {
        public ILocator FirstChapter => Page.GetByRole(AriaRole.Textbox, new() { NameString = "First chapter*" });
        public ILocator SecondChapter => Page.GetByRole(AriaRole.Textbox, new() { NameString = "Second chapter" });
        public ILocator ThirdChapter => Page.GetByRole(AriaRole.Textbox, new() { NameString = "Third chapter" });
        public ILocator SubmitButton => Page.GetByRole(AriaRole.Button, new() { NameString = "Submit" });

        public MultipleTextAreasPage(IPage page) : base(page, $"{BaseUrl}/elements/textarea/textareas")
        {
        }
    }
}
