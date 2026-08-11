using Microsoft.Playwright;
using QaPracticeTest.Components;

namespace QaPracticeTest.Pages.PopUp
{
    public class PopUpPage(IPage page) : QaPracticePage(page, "/elements/popup/modal")
    {
        public ILocator LaunchPopUpButton => Page.GetByRole(AriaRole.Button, new() { NameString = "Launch Pop-Up" });
        public Result Result => new(Page);
        public PopUpPageModal PopUpModal => new(Page, "I am a Pop-Up");
    }
}
