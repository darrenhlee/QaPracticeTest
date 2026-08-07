using Microsoft.Playwright;

namespace QaPracticeTest.Pages.DragAndDrop
{
    public class BoxesPage : QaPracticePage
    {
        public ILocator DroppableBox => Page.Locator("id=rect-droppable");
        public ILocator DraggableBox => Page.Locator("id=rect-draggable");
        public ILocator DroppableBoxText => DroppableBox.Locator("id=text-droppable");

        public BoxesPage(IPage page) : base(page, "/elements/dragndrop/boxes")
        {
        }
    }
}
