using Microsoft.Playwright;

namespace QaPracticeTest.Pages
{
    public interface IQaPracticePage
    {
        IPage Page { get; }
        string Url { get; }

        Task GoToAsync();
    }
}
