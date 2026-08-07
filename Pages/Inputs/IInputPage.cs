using Microsoft.Playwright;
using QaPracticeTest.Components;

namespace QaPracticeTest.Pages.Inputs
{
    public interface IInputPage : IQaPracticePage
    {
        public ILocator Input { get; }
        public Result Result { get; }
        public ILocator ErrorMessage { get; }

        Task SubmitText(string text);
        Task<string> GetResult();
        Task<string> GetErrorMessage();
        Task<bool> IsInputVisible();
        Task<bool> IsInputEnabled();
        Task<bool> IsInputRequired();
    }
}
