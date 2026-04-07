using QaPracticeTest.Pages.Buttons;

namespace QaPracticeTest.Tests.Buttons
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class SimpleButtonTests : ButtonTestBase
    {
        [SetUp]
        public void SetUp()
        {
            ButtonPage = new SimpleButtonPage(Page);
        }

        [Test]
        public async Task UserCanClickTheButton()
        {
            await ButtonPage.GoToAsync();
            Assert.That(await ButtonPage.IsButtonEnabled(), Is.True);
            Assert.That(await ButtonPage.GetButtonLabel(), Is.EqualTo("Click"));
            await ButtonPage.ClickButton();
            var result = await ButtonPage.GetResult();
            Assert.That(result, Is.EqualTo("Submitted"));
        }
    }
}
