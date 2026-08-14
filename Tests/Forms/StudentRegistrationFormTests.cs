using NUnit.Framework.Internal;
using QaPracticeTest.Pages.Forms;
using QaPracticeTest.TestData.Forms.StudentRegistrationForm;

namespace QaPracticeTest.Tests.Forms
{
    [Parallelizable(ParallelScope.Self)]
    public sealed class StudentRegistrationFormTests : PageTest
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
            await Expect(StudentRegistrationFormPage.StateSelect).Not.ToBeRequired();
            await Expect(StudentRegistrationFormPage.CitySelect).Not.ToBeRequired();
        }

        [TestCaseSource(typeof(StudentRegistrationFormTestData), nameof(StudentRegistrationFormTestData.ValidFormData))]
        public async Task FormCanBeSubmittedWithValidData(StudentRegistrationFormData formData)
        {
            await StudentRegistrationFormPage.FirstNameInput.FillAsync(formData.FirstName);
            await StudentRegistrationFormPage.LastNameInput.FillAsync(formData.LastName);
            await StudentRegistrationFormPage.EmailInput.FillAsync(formData.Email);
            await StudentRegistrationFormPage.SetGender(formData.Gender);
            await StudentRegistrationFormPage.MobileInput.FillAsync(formData.Mobile);
            await StudentRegistrationFormPage.SetDateOfBirth(formData.DateOfBirth);
            await StudentRegistrationFormPage.SetSubjects(formData.Subjects);
            await StudentRegistrationFormPage.SetHobbies(formData.Hobbies);
            await StudentRegistrationFormPage.UploadPicture(formData.PictureFilePath);
            await StudentRegistrationFormPage.CurrentAddressTextarea.FillAsync(formData.CurrentAddress);
            await StudentRegistrationFormPage.SelectState(formData.State);
            await StudentRegistrationFormPage.SelectCity(formData.City);
            await StudentRegistrationFormPage.SubmitButton.ClickAsync();

            await Expect(StudentRegistrationFormPage.ResultsModal.RootElement).ToHaveTextAsync(new Regex($"Student Name(\\r\\n?|\\n)\\s+{formData.FirstName} {formData.LastName}"));
            await Expect(StudentRegistrationFormPage.ResultsModal.RootElement).ToHaveTextAsync(new Regex($"Student Email(\\r\\n?|\\n)\\s+{formData.Email}"));
            await Expect(StudentRegistrationFormPage.ResultsModal.RootElement).ToHaveTextAsync(new Regex($"Gender(\\r\\n?|\\n)\\s+{formData.Gender}"));
            await Expect(StudentRegistrationFormPage.ResultsModal.RootElement).ToHaveTextAsync(new Regex($"Mobile(\\r\\n?|\\n)\\s+{formData.Mobile}"));
            await Expect(StudentRegistrationFormPage.ResultsModal.RootElement).ToHaveTextAsync(new Regex($"Date of Birth(\\r\\n?|\\n)\\s+{formData.DateOfBirth:yyyy-MM-dd}"));
            await Expect(StudentRegistrationFormPage.ResultsModal.RootElement).ToHaveTextAsync(new Regex($"Subjects(\\r\\n?|\\n)\\s+{string.Join(", ", formData.Subjects)}"));
            await Expect(StudentRegistrationFormPage.ResultsModal.RootElement).ToHaveTextAsync(new Regex($"Hobbies(\\r\\n?|\\n)\\s+{formData.Hobbies}"));
            await Expect(StudentRegistrationFormPage.ResultsModal.RootElement).ToHaveTextAsync(new Regex($"Picture(\\r\\n?|\\n)\\s+{Path.GetFileName(formData.PictureFilePath)}"));
            await Expect(StudentRegistrationFormPage.ResultsModal.RootElement).ToHaveTextAsync(new Regex($"Address(\\r\\n?|\\n)\\s+{formData.CurrentAddress}"));
            await Expect(StudentRegistrationFormPage.ResultsModal.RootElement).ToHaveTextAsync(new Regex($"State and City(\\r\\n?|\\n)\\s+{formData.State}"));
        }
    }
}
