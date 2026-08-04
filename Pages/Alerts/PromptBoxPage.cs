using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Alerts
{   

    internal class PromptBoxPage(IPage page) : AlertPageBase(page, "/elements/alert/prompt")
    {
        internal Result Result { get; private set; } = new Result(page);
    }
}
