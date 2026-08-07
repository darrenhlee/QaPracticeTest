using QaPracticeTest.Pages.DragAndDrop;

namespace QaPracticeTest.Tests.DragAndDrop
{
    [TestFixture]
    public class ImagesTests : PageTest
    {
        private ImagesPage ImagesPage { get; set; }

        [SetUp]
        public async Task SetUp()
        {
            ImagesPage = new ImagesPage(Page);
            await ImagesPage.GoToAsync();
        }

        [Test]
        public async Task SmileyCanBeDraggedFromSquareToSquare()
        {
            for (var i = 0; i < 3; i++)
            {
                await DragSmileyToBottomSquareAndExpectDroppedDisplay();
                await DragSmileyToTopSquareAndExpectDroppedDisplay();
            }
        }

        private async Task DragSmileyToTopSquareAndExpectDroppedDisplay()
        {
            await ImagesPage.DraggableImage.DragToAsync(ImagesPage.Droppable2);
            await Expect(ImagesPage.Droppable2).ToHaveTextAsync("Dropped!");
            await Expect(ImagesPage.Droppable1.Filter(new()
            {
                Has = ImagesPage.Droppable1.Locator("css=*")
            })).Not.ToBeVisibleAsync();
        }

        private async Task DragSmileyToBottomSquareAndExpectDroppedDisplay()
        {
            await ImagesPage.DraggableImage.DragToAsync(ImagesPage.Droppable1);
            await Expect(ImagesPage.Droppable1).ToHaveTextAsync("Dropped!");
            await Expect(ImagesPage.Droppable2.Filter(new()
            {
                Has = ImagesPage.Droppable2.Locator("css=*")
            })).Not.ToBeVisibleAsync();
        }
    }
}
