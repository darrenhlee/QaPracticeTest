using Microsoft.Playwright;

namespace QaPracticeTest.Tests
{
    public abstract class QaPracticeTestBase : PageTest
    {
        protected async Task ExpectFieldToBeRequired(ILocator field) => await Expect(field).ToHaveAttributeAsync("required", string.Empty);

        protected async Task ExpectFieldNotToBeRequired(ILocator field) => await Expect(field).Not.ToHaveAttributeAsync("required", string.Empty);
    }
}
