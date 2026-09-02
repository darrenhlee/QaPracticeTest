using Microsoft.Playwright;
using QaPracticeTest.Components;

namespace QaPracticeTest.Pages.Forms
{
    public class StudentRegistrationFormResultsModal : PopUpModalBase
    {
        public ILocator StudentNameRow => RootElement.GetByRole(AriaRole.Row, new() { NameString = "Student Name" });

        public StudentRegistrationFormResultsModal(IPage page) : base(page, new PageGetByRoleOptions() { NameString = "Thanks for submitting the form" })
        {
        }
    }
}
