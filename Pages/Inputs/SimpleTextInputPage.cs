using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Inputs
{
    internal class SimpleTextInputPage : InputPage
    {
        internal SimpleTextInputPage(IPage page) 
            : base(
                page,
                "https://www.qa-practice.com/elements/input/simple",
                page.Locator("id=error_1_id_text_string"))
        {
        }
    }
}
