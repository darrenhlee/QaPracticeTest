using Microsoft.Playwright;

namespace QaPracticeTest.Components
{
    public class PopUpModalBase
    {
        public ILocator RootElement { get; }
        public ILocator CloseXButton => RootElement.GetByRole(AriaRole.Button, new() { NameString = "Close" }).First;
        public ILocator CloseButton => RootElement.GetByRole(AriaRole.Button, new() { NameString = "Close" }).Nth(1);

        public PopUpModalBase(IPage page, PageGetByRoleOptions options)
        {
            RootElement = page.GetByRole(AriaRole.Dialog, options);
        }

        public PopUpModalBase(ILocator parentLocator, LocatorGetByRoleOptions options)
        {
            RootElement = parentLocator.GetByRole(AriaRole.Dialog, options);
        }

        public PopUpModalBase(ILocator rootElement)
        {
            RootElement = rootElement;
        }
    }
}
