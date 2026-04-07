namespace QaPracticeTest.Pages.Inputs
{
    public interface IInputPage : IQaPracticePage
    {
        Task SubmitText(string text);
        Task<string> GetResult();
        Task<string> GetErrorMessage();
        Task<bool> IsInputVisible();
        Task<bool> IsInputEnabled();
        Task<bool> IsInputRequired();
    }
}
