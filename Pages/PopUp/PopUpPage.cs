using Microsoft.Playwright;
using QaPracticeTest.Components;

namespace QaPracticeTest.Pages.PopUp
{
    public class PopUpPage(IPage page) : PopUpPageBase(page, "/elements/popup/modal")
    {
        public Result Result => new(Page);
        public PopUpPageModal PopUpModal => new(Page, new() { NameString = "I am a Pop-Up" });
    }
}
