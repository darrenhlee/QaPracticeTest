using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaPracticeTest.Pages.Checkboxes
{
    public class CheckboxPage : ResultPage, ICheckboxPage
    {
        public ILocator SubmitButton { get; private set; }

        public CheckboxPage(IPage page, string url) : base(page, url)
        {
            SubmitButton = page.GetByRole(AriaRole.Button, new() { NameString = "Submit" });
        }

        public async Task ClickButton() => await SubmitButton.ClickAsync();
    }
}
