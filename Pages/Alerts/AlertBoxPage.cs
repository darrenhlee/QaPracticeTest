using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Alerts
{
    public class AlertBoxPage(IPage page) : AlertPageBase(page, "/elements/alert/alert")
    {
    }
}
