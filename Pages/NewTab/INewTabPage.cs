using Microsoft.Playwright;

namespace QaPracticeTest.Pages.NewTab
{
    public interface INewTabPage : IQaPracticePage
    {
        public ILocator NewTabLocator { get; }

        public async Task ClickNewTabOpener() => await NewTabLocator.ClickAsync();
    }
}
