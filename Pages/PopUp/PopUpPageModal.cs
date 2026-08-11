using Microsoft.Playwright;

namespace QaPracticeTest.Pages.PopUp
{
    public class PopUpPageModal
    {
        public ILocator RootElement { get; }
        public ILocator SelectMeOrNotCheckbox => RootElement.GetByLabel("Select me or not");
        public ILocator CloseXButton => RootElement.GetByRole(AriaRole.Button, new() { NameString = "Close" }).First;
        public ILocator SendButton => RootElement.GetByRole(AriaRole.Button, new() { NameString = "Send" });
        public ILocator CloseButton => RootElement.GetByRole(AriaRole.Button, new() { NameString = "Close" }).Nth(1);

        public PopUpPageModal(IPage page, string nameString)
        {
            RootElement = page.GetByRole(AriaRole.Dialog, new() { NameString = nameString });
        }

        public PopUpPageModal(ILocator parentLocator, string nameString)
        {
            RootElement = parentLocator.GetByRole(AriaRole.Dialog, new() { NameString = nameString });
        }
    }
}
