using QaPracticeTest.Pages.Buttons;

namespace QaPracticeTest.Tests.Buttons
{
    public abstract class ButtonTestBase : PageTest
    {
        public required IButtonPage ButtonPage { get; set; }
    }
}
