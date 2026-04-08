using QaPracticeTest.Pages.Buttons;

namespace QaPracticeTest.Tests.Buttons
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class LooksLikeABuittonTests : ButtonTestBase
    {
        [SetUp]
        public void SetUp()
        {
            ButtonPage = new LooksLikeAButtonPage(Page);
            ExpectedButtonText = "Click";
        }
    }
}
