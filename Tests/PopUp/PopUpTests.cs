using QaPracticeTest.Pages.PopUp;

namespace QaPracticeTest.Tests.PopUp
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class PopUpTests : PageTest
    {
        private PopUpPage PopUpPage { get; set; }

        [SetUp]
        public async Task SetUp()
        {
            PopUpPage = new PopUpPage(Page);
            await PopUpPage.GoToAsync();
            await PopUpPage.LaunchPopUpButton.ClickAsync();
        }

        [Test]
        public async Task SendCheckboxValue([Values] bool selectValue)
        {
            await PopUpPage.PopUpModal.SelectMeOrNotCheckbox.SetCheckedAsync(selectValue);
            await PopUpPage.PopUpModal.SendButton.ClickAsync();
            var expectedResult = $"Selected checkboxes:{Environment.NewLine}{(selectValue ? "select me or not" : "None")}";
            await Expect(PopUpPage.Result.ResultRoot).ToHaveTextAsync(expectedResult);
        }

        [Test]
        public async Task CheckboxValueIsNotSentWhenModalCloseButtonIsClicked([Values] bool selectValue)
        {
            await PopUpPage.PopUpModal.SelectMeOrNotCheckbox.SetCheckedAsync(selectValue);
            await PopUpPage.PopUpModal.CloseButton.ClickAsync();
            await Expect(PopUpPage.Result.ResultRoot).Not.ToBeVisibleAsync();
        }

        [Test]
        public async Task CheckboxValueIsNotSentWhenModalCloseXButtonIsClicked([Values] bool selectValue)
        {
            await PopUpPage.PopUpModal.SelectMeOrNotCheckbox.SetCheckedAsync(selectValue);
            await PopUpPage.PopUpModal.CloseXButton.ClickAsync();
            await Expect(PopUpPage.Result.ResultRoot).Not.ToBeVisibleAsync();
        }
    }
}
