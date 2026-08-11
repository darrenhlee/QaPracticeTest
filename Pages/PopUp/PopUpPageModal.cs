using Microsoft.Playwright;

namespace QaPracticeTest.Pages.PopUp
{
    public class PopUpPageModal : PopUpModal
    {
        public ILocator SelectMeOrNotCheckbox => RootElement.GetByLabel("Select me or not");
        public ILocator SendButton => RootElement.GetByRole(AriaRole.Button, new() { NameString = "Send" });

        public PopUpPageModal(IPage page, PageGetByRoleOptions options) : base(page, options)
        {
        }

        public PopUpPageModal(ILocator parentLocator, LocatorGetByRoleOptions options) : base(parentLocator, options)
        {
        }
    }
}
