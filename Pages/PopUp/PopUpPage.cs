using Microsoft.Playwright;
using QaPracticeTest.Components;

namespace QaPracticeTest.Pages.PopUp
{
    public class PopUpPage : QaPracticePage
    {
        public ILocator LaunchPopUpButton => Page.GetByRole(AriaRole.Button, new() { NameRegex = new("Launch Pop-Up", RegexOptions.IgnoreCase) });
        public Result Result => new(Page);
        public PopUpPageModal PopUpModal => new(Page, "I am a Pop-Up");

        public PopUpPage(IPage page) : base(page, "/elements/popup/modal")
        {
        }
    }
}
