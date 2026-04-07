using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Inputs
{
    internal class PasswordInputPage : InputPage
    {
        internal PasswordInputPage(IPage page)
            : base(
                  page,
                  "https://www.qa-practice.com/elements/input/passwd",
                  page.Locator("id=error_1_id_password"))
        {
        }
    }
}
