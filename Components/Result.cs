using Microsoft.Playwright;

namespace QaPracticeTest.Components
{
    public class Result
    {
        private readonly IPage? page;
        private readonly ILocator? parentLocator;

        public Result(IPage page)
        {
            this.page = page;
        }

        public Result(ILocator parentLocator)
        {
            this.parentLocator = parentLocator;
        }

        internal ILocator ResultRoot => page?.Locator("id=result") ?? parentLocator!.Locator("id=result");
        internal ILocator ResultHead => ResultRoot.Locator("id=result-head");
        internal ILocator ResultText => ResultRoot.Locator("id=result-text");
    }

}
