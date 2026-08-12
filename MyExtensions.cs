using Microsoft.Playwright;

namespace QaPracticeTest
{
    public static class MyExtensions
    {
        public static async Task ToBeRequired(this ILocatorAssertions locatorAssertions) => await locatorAssertions.ToHaveAttributeAsync("required", string.Empty);
    }
}
