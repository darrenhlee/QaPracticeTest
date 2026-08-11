using Microsoft.Playwright;
using QaPracticeTest.Components;

namespace QaPracticeTest.Pages.PopUp
{
    public class PopUpPage : QaPracticePage
    {
        public ILocator LaunchPopUpButton => Page.GetByRole(AriaRole.Button, new() { NameRegex = new("Launch Pop-Up", RegexOptions.IgnoreCase) });
        public ILocator ExampleModal => Page.GetByRole(AriaRole.Dialog, new() { NameString = "I am a Pop-Up" });
        public ILocator SelectMeOrNotCheckbox => ExampleModal.GetByLabel("Select me or not");
        public ILocator CloseXButton => ExampleModal.GetByRole(AriaRole.Button, new() { NameString = "Close" }).First;
        public ILocator SendButton => ExampleModal.GetByRole(AriaRole.Button, new() { NameString = "Send" });
        public ILocator CloseButton => ExampleModal.GetByRole(AriaRole.Button, new() { NameString = "Close" }).Nth(1);
        public Result Result => new(Page);

        public PopUpPage(IPage page) : base(page, "/elements/popup/modal")
        {
        }
    }
}
