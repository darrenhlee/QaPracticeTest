using Microsoft.Playwright;

namespace QaPracticeTest.Pages
{
    public class ResultPage : QaPracticePage
    {
        public ILocator Result { get; private set; }

        public ResultPage(IPage page, string url) : base(page, url)
        {
            Result = page.Locator("id=result-text");
        }
    }
}