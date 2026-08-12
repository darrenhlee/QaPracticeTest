using Microsoft.Playwright;
using QaPracticeTest.Components;

namespace QaPracticeTest.Pages.PopUp
{
    public class IframePopUpModal : PopUpModalBase
    {
        public IFrameLocator Iframe => RootElement.FrameLocator("iframe");
        public ILocator Title => Iframe.GetByRole(AriaRole.Heading);
        public ILocator TextToCopy => Iframe.Locator("id=text-to-copy");
        public ILocator CheckButton => RootElement.GetByRole(AriaRole.Button, new() { NameString = "Check" });

        public IframePopUpModal(IPage page, PageGetByRoleOptions options) : base(page, options)
        {
        }

        public IframePopUpModal(ILocator parentLocator, LocatorGetByRoleOptions options) : base(parentLocator, options)
        {
        }

        public IframePopUpModal(ILocator rootElement) : base(rootElement)
        {
        }
    }
}
