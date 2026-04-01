using Microsoft.Playwright;
using QaPracticeTest.Pages.Inputs;

namespace QaPracticeTest.Pages
{
    internal class EmailTextInputPage : InputPage
    {
        internal EmailTextInputPage(IPage page)
            : base(
                  page,
                 "https://www.qa-practice.com/elements/input/simple",
                  page.GetByPlaceholder("Submit me"),
                  page.Locator("id=result-text"),
                  page.Locator("id=error_1_id_email"))
        {
        }

    }
}
