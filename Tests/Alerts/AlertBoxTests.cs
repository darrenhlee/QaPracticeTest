namespace QaPracticeTest.Tests.Alerts
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class AlertBoxTests : PageTest
    {
        [Test]
        public async Task UserCanClickButtonToTriggerAlert()
        {
            var alertBoxPage = new Pages.Alerts.AlertBoxPage(Page);
            await alertBoxPage.GoToAsync();
            await alertBoxPage.ClickButton.ClickAsync();
            await alertBoxPage.AssertDialogMessageAndAccept("I am an alert!");
        }
    }
}
