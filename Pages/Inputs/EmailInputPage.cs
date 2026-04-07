using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Inputs
{
    internal class EmailTextInputPage : InputPage
    {
        internal EmailTextInputPage(IPage page)
            : base(
                  page,
                  "https://www.qa-practice.com/elements/input/email",
                  page.Locator("id=error_1_id_email"))
        {
        }
    }
}
