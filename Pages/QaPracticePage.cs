using Microsoft.Playwright;

namespace QaPracticeTest.Pages
{
    abstract internal class QaPracticePage
    {
        protected readonly IPage _page;
        protected readonly string _url;

        internal QaPracticePage(IPage page, string url)
        {
            _page = page ?? throw new ArgumentNullException(nameof(page));
            _url = url ?? throw new ArgumentNullException(nameof(url));
        }

        internal async Task GoToAsync() => await _page.GotoAsync(_url);
    }
}
