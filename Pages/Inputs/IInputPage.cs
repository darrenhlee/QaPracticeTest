using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Inputs
{
    public interface IInputPage : IQaPracticePage
    {
        public ILocator Input { get; }
        public ILocator Result { get; }
        public ILocator ErrorMessage { get; }

        Task SubmitText(string text);
        Task<string> GetResult();
        Task<string> GetErrorMessage();
        Task<bool> IsInputVisible();
        Task<bool> IsInputEnabled();
        Task<bool> IsInputRequired();
    }
}
