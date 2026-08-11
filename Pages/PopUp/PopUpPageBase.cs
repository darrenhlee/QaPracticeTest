using Microsoft.Playwright;

namespace QaPracticeTest.Pages.PopUp
{
    public class PopUpPageBase : QaPracticePage
    {
        public ILocator LaunchPopUpButton => Page.GetByRole(AriaRole.Button, new() { NameString = "Launch Pop-Up" });

        public PopUpPageBase(IPage page, string url) : base(page, url)
        {
        }
    }
}
