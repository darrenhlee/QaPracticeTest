using Microsoft.Playwright;

namespace QaPracticeTest.Pages.DragAndDrop
{
    public class ImagesPage : QaPracticePage
    {
        public ImagesPage(IPage page) : base(page, "/elements/dragndrop/images")
        {
        }

        public ILocator Droppable1 => Page.Locator("id=rect-droppable1");
        public ILocator Droppable2 => Page.Locator("id=rect-droppable2");
        public ILocator DraggableImage => Page.Locator("css=img.rect-draggable");
    }
}
