using QaPracticeTest.Pages.Forms;

namespace QaPracticeTest.Tests.Forms
{
    [Parallelizable(ParallelScope.Self)]
    public class StudentRegistrationFormTests : PageTest
    {
        private StudentRegistrationFormPage StudentRegistrationFormPage { get; set; }

        [SetUp]
        public async Task SetUp()
        {
            StudentRegistrationFormPage = new StudentRegistrationFormPage(Page);
            await StudentRegistrationFormPage.GoToAsync();
        }

        [Test]
        public async Task RequiredFieldsAreRequired()
        {
            await Expect(StudentRegistrationFormPage.FirstNameInput).ToBeRequired();
            await Expect(StudentRegistrationFormPage.LastNameInput).ToBeRequired();
            await Expect(StudentRegistrationFormPage.MaleGenderInput).ToBeRequired();
            await Expect(StudentRegistrationFormPage.FemaleGenderInput).ToBeRequired();
            await Expect(StudentRegistrationFormPage.OtherGenderInput).ToBeRequired();
            await Expect(StudentRegistrationFormPage.MobileInput).ToBeRequired();
        }
    }
}
