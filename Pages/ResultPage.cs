using Microsoft.Playwright;

namespace QaPracticeTest.Pages
{
    public class ResultPage(IPage page, string url) : QaPracticePage(page, url)
    {
        public ILocator Result { get; private set; } = page.Locator("id=result-text");
    }
}