using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Alerts
{
    public class AlertBoxPage(IPage page) : QaPracticePage(page, "/elements/alert/alert")
    {
        public ILocator ClickButton => _page.GetByRole(AriaRole.Link, new() { NameString = "Click" });

        public void AssertDialogMessageAndAccept(string expectedMessage)
        {
            _page.Dialog += async (_, dialog) =>
            {
                Assert.That(dialog.Message, Is.EqualTo(expectedMessage));
                await dialog.AcceptAsync();
            };
        }
    }
}
