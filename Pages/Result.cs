using Microsoft.Playwright;

namespace QaPracticeTest.Pages
{
    public class Result(IPage page)
    {
        internal ILocator ResultLocator => page.Locator("id=result");
        internal ILocator ResultHead => ResultLocator.Locator("id=result-head");
        internal ILocator ResultText => ResultLocator.Locator("id=result-text");
    }
}
