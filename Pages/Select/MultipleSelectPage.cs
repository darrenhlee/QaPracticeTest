using Microsoft.Playwright;

namespace QaPracticeTest.Pages.Select
{
    public class MultipleSelectPage(IPage page) : SelectPage(page, "https://www.qa-practice.com/elements/select/mult_select")
    {
        public ILocator PlaceSelect => _page.Locator("#id_choose_the_place_you_want_to_go");
        public ILocator HowSelect => _page.Locator("#id_choose_how_you_want_to_get_there");
        public ILocator WhenSelect => _page.Locator("#id_choose_when_you_want_to_go");
        public ILocator PlaceSelectLabel => _page.Locator($"[for={PlaceSelect.GetAttributeAsync("id").Result}]");
        public ILocator HowSelectLabel => _page.Locator($"[for={HowSelect.GetAttributeAsync("id").Result}]");
        public ILocator WhenSelectLabel => _page.Locator($"[for={WhenSelect.GetAttributeAsync("id").Result}]");

        public async Task SelectPlace(string option) => await PlaceSelect.SelectOptionAsync([new SelectOptionValue() { Label = option }]);

        public async Task SelectPlace(int index) => await PlaceSelect.SelectOptionAsync(new SelectOptionValue() { Index = index });

        public async Task SelectHow(string option) => await HowSelect.SelectOptionAsync([new SelectOptionValue() { Label = option }]);

        public async Task SelectHow(int index) => await HowSelect.SelectOptionAsync(new SelectOptionValue() { Index = index });

        public async Task SelectWhen(string option) => await WhenSelect.SelectOptionAsync([new SelectOptionValue() { Label = option }]);

        public async Task SelectWhen(int index) => await WhenSelect.SelectOptionAsync(new SelectOptionValue() { Index = index });
    }
}
