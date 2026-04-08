using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Checkboxes
{
    public interface ICheckboxPage : IQaPracticePage
    {
        public ILocator SubmitButton { get; }
        public ILocator Result { get; }
        Task ClickButton();
    }
}
