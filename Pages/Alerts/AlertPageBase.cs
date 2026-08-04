using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Alerts
{
    abstract public class AlertPageBase : QaPracticePage
    {
        public ILocator ClickButton => Page.GetByRole(AriaRole.Link, new() { NameString = "Click" });

        internal AlertPageBase(IPage page, string url) : base(page, url)
        {
        }

        public async Task AssertDialogMessageAndAccept(string expectedMessage, string? promptText = null)
        {
            ListenForDialogAssertAndAccept(expectedMessage, promptText);
            await ClickButton.ClickAsync();
        }

        public async Task AssertDialogMessageAndDismiss(string expectedMessage)
        {
            ListenForDialogAssertAndDismiss(expectedMessage);
            await ClickButton.ClickAsync();
        }

        private void ListenForDialogAssertAndAccept(string expectedMessage, string? promptText = null)
        {
            Page.Dialog += async (_, dialog) =>
            {
                if (expectedMessage != null)
                {
                    Assert.That(dialog.Message, Is.EqualTo(expectedMessage));
                }

                await dialog.AcceptAsync(promptText);
            };
        }

        private void ListenForDialogAssertAndDismiss(string expectedMessage)
        {
            Page.Dialog += async (_, dialog) =>
            {
                if (expectedMessage != null)
                {
                    Assert.That(dialog.Message, Is.EqualTo(expectedMessage));
                }

                await dialog.DismissAsync();
            };
        }
    }
}
