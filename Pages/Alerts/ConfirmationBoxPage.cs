using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Alerts
{
    public class ConfirmationBoxPage(IPage page) : AlertPageBase(page, "/elements/alert/confirm")
    {
    }
}
