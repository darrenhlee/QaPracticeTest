using Microsoft.Playwright;

namespace QaPracticeTest.Pages
{
    abstract public class QaPracticePage : IQaPracticePage
    {
        public const string BaseUrl = "https://www.qa-practice.com";
        public IPage Page { get; private set; }
        public string Url { get; private set; }

        internal QaPracticePage(IPage page, string url)
        {
            Page = page ?? throw new ArgumentNullException(nameof(page));
            Url = url ?? throw new ArgumentNullException(nameof(url));
        }

        public async Task GoToAsync() => await Page.GotoAsync(Url.StartsWith(BaseUrl) ? Url : $"{BaseUrl}{Url}");
    }
}
