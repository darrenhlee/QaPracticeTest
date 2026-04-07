namespace QaPracticeTest.Pages.Buttons
{
    public interface IButtonPage : IQaPracticePage
    {
        Task ClickButton();
        Task<string> GetResult();
        Task<bool> IsButtonVisible();
        Task<bool> IsButtonEnabled();
        Task<string?> GetButtonLabel();
    }
}
