using Microsoft.Playwright;

namespace QaPracticeTest.Pages.PopUp
{
    public class PopUpPageModal
    {
        private readonly ILocator rootElement;

        public PopUpPageModal(IPage page, string nameString)
        {
            rootElement = page.GetByRole(AriaRole.Dialog, new() { NameString = nameString });
        }

        public PopUpPageModal(ILocator parentLocator, string nameString)
        {
            rootElement = parentLocator.GetByRole(AriaRole.Dialog, new() { NameString = nameString });
        }

        public ILocator SelectMeOrNotCheckbox => rootElement.GetByLabel("Select me or not");
        public ILocator CloseXButton => rootElement.GetByRole(AriaRole.Button, new() { NameString = "Close" }).First;
        public ILocator SendButton => rootElement.GetByRole(AriaRole.Button, new() { NameString = "Send" });
        public ILocator CloseButton => rootElement.GetByRole(AriaRole.Button, new() { NameString = "Close" }).Nth(1);
    }
}
