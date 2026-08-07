using QaPracticeTest.Pages.DragAndDrop;

namespace QaPracticeTest.Tests.DragAndDrop
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class BoxesTests : PageTest
    {
        private BoxesPage BoxesPage { get; set; }

        [SetUp]
        public async Task SetUp()
        {
            BoxesPage = new BoxesPage(Page);
            await BoxesPage.GoToAsync();
        }

        [Test]
        public async Task UserCanDragAndDropBox()
        {
            await BoxesPage.DraggableBox.DragToAsync(BoxesPage.DroppableBox);
            await Expect(BoxesPage.DroppableBoxText).ToHaveTextAsync("Dropped!");
        }

        [Test]
        public async Task BottomSquareCanOnlyBeDraggedOnce()
        {
            await BoxesPage.DraggableBox.DragToAsync(BoxesPage.DroppableBox);
            await BoxesPage.DraggableBox.DragToAsync(Page.GetByText("Requirements"));
            await Expect(BoxesPage.DroppableBox).ToHaveTextAsync("Dropped! Drag me");
        }
    }
}
