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
        public async Task RequiredFieldsAreRequiredOptionalFieldsAreOptional()
        {
            await Expect(StudentRegistrationFormPage.FirstNameInput).ToBeRequired();
            await Expect(StudentRegistrationFormPage.LastNameInput).ToBeRequired();
            await Expect(StudentRegistrationFormPage.MaleGenderInput).ToBeRequired();
            await Expect(StudentRegistrationFormPage.FemaleGenderInput).ToBeRequired();
            await Expect(StudentRegistrationFormPage.OtherGenderInput).ToBeRequired();
            await Expect(StudentRegistrationFormPage.MobileInput).ToBeRequired();

            await Expect(StudentRegistrationFormPage.SportsCheckbox).Not.ToBeRequired();
            await Expect(StudentRegistrationFormPage.ReadingCheckbox).Not.ToBeRequired();
            await Expect(StudentRegistrationFormPage.MusicCheckbox).Not.ToBeRequired();
            await Expect(StudentRegistrationFormPage.PictureInput).Not.ToBeRequired();
            await Expect(StudentRegistrationFormPage.CurrentAddressTextarea).Not.ToBeRequired();
            await Expect(StudentRegistrationFormPage.StateDropdown).Not.ToBeRequired();
            await Expect(StudentRegistrationFormPage.CityDropdown).Not.ToBeRequired();
        }
    }
}
