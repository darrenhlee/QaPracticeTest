using Microsoft.Playwright;

namespace QaPracticeTest.Pages.PopUp
{
    public class PopUpModal
    {
        public ILocator RootElement { get; }
        public ILocator CloseXButton => RootElement.GetByRole(AriaRole.Button, new() { NameString = "Close" }).First;
        public ILocator CloseButton => RootElement.GetByRole(AriaRole.Button, new() { NameString = "Close" }).Nth(1);

        public PopUpModal(IPage page, PageGetByRoleOptions options)
        {
            RootElement = page.GetByRole(AriaRole.Dialog, options);
        }

        public PopUpModal(ILocator parentLocator, LocatorGetByRoleOptions options)
        {
            RootElement = parentLocator.GetByRole(AriaRole.Dialog, options);
        }

        public PopUpModal(ILocator rootElement)
        {
            RootElement = rootElement;
        }
    }
}
