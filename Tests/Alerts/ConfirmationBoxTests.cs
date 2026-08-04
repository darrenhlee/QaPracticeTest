using QaPracticeTest.Pages.Alerts;

namespace QaPracticeTest.Tests.Alerts
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class ConfirmationBoxTests : PageTest
    {
        private ConfirmationBoxPage ConfirmationBoxPage { get; set; }

        [SetUp]
        public async Task SetUp()
        {
            ConfirmationBoxPage = new ConfirmationBoxPage(Page);
            await ConfirmationBoxPage.GoToAsync();
        }

        [Test]
        public async Task UserCanClickButtonToTriggerConfirmationBox()
        {
            await ConfirmationBoxPage.AssertDialogMessageAndAccept(expectedMessage: "Select Ok or Cancel");
            await Expect(ConfirmationBoxPage.Result.ResultText).ToHaveTextAsync("Ok");
        }

        [Test]
        public async Task UserCanClickButtonToTriggerConfirmationBoxAndDismiss()
        {
            await ConfirmationBoxPage.AssertDialogMessageAndDismiss(expectedMessage: "Select Ok or Cancel");
            await Expect(ConfirmationBoxPage.Result.ResultText).ToHaveTextAsync("Cancel");
        }
    }
}
