using Microsoft.Playwright;

namespace QaPracticeTest.Pages.PopUp
{
    public class IframePopUpPage : PopUpPageBase
    {
        public IframePopUpModal Modal => new(Page.Locator("id=exampleModal"));
        public ILocator TextFromIframeInput => Page.GetByRole(AriaRole.Textbox, new() { NameString = "Text from iframe*" });
        public ILocator SubmitButton => Page.GetByRole(AriaRole.Button, new() { NameString = "Submit" });
        public ILocator CheckResult => Page.Locator("id=check-result");

        public IframePopUpPage(IPage page) : base(page, "/elements/popup/iframe_popup")
        {
        }
    }
}
