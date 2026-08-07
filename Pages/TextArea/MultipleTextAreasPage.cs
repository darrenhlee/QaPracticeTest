using Microsoft.Playwright;
using QaPracticeTest.Components;

namespace QaPracticeTest.Pages.TextArea
{
    public class MultipleTextAreasPage(IPage page) : QaPracticePage(page, $"{BaseUrl}/elements/textarea/textareas")
    {
        public ILocator FirstChapter => Page.GetByRole(AriaRole.Textbox, new() { NameString = "First chapter*" });
        public ILocator SecondChapter => Page.GetByRole(AriaRole.Textbox, new() { NameString = "Second chapter" });
        public ILocator ThirdChapter => Page.GetByRole(AriaRole.Textbox, new() { NameString = "Third chapter" });
        public ILocator SubmitButton => Page.GetByRole(AriaRole.Button, new() { NameString = "Submit" });
        public Result Result { get; private set; } = new Result(page);
    }
}
