using Microsoft.Playwright;
using QaPracticeTest.Components;

namespace QaPracticeTest.Pages.Forms
{
    public class StudentRegistrationFormResultsModal(IPage page) : PopUpModalBase(page, new PageGetByRoleOptions() { NameString = "Thanks for submitting the form" })
    {
        public ILocator StudentNameRow => RootElement.GetByRole(AriaRole.Row, new() { NameString = "Student Name" });
    }
}
