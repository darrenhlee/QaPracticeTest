using QaPracticeTest.Pages.Checkboxes;
using System.Threading.Tasks;

namespace QaPracticeTest.Tests.Checkboxes
{
    public class MultipleCheckboxTests : PageTest
    {
        private MultipleCheckboxPage CheckboxPage { get; set; }

        [SetUp]
        public async Task SetUp()
        {
            CheckboxPage = new MultipleCheckboxPage(Page);
            await CheckboxPage.GoToAsync();
        }

        [Test]
        public async Task NumberOfCheckboxesIsCorrect() => await Expect(CheckboxPage.Checkboxes).ToHaveCountAsync(3);
    }
}
