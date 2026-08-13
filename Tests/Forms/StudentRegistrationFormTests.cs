using NUnit.Framework.Internal;
using QaPracticeTest.Pages.Forms;

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
            await Expect(StudentRegistrationFormPage.StateDropdown).Not.ToBeRequired();
            await Expect(StudentRegistrationFormPage.CityDropdown).Not.ToBeRequired();
        }

        private static IEnumerable<TestCaseData> ValidFormData()
        {
            yield return new TestCaseData(new StudentRegistrationFormData()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = string.Empty,
                Mobile = "1234567890",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(2000, 1, 1),
                Subjects = [],
                Hobbies = new StudentHobbies(),
                PictureFilePath = string.Empty,
                CurrentAddress = string.Empty,
                State = string.Empty,
                City = string.Empty
            });

            yield return new TestCaseData(new StudentRegistrationFormData()
            {
                FirstName = "Jane",
                LastName = "Doe",
                Email = "jane.doe@example.com",
                Mobile = "1234567890",
                Gender = Gender.Female,
                DateOfBirth = DateTime.Today,
                Subjects = ["Maths", "Physics"],
                Hobbies = new StudentHobbies() { Sports = true, Reading = true, Music = true },
                PictureFilePath = string.Empty,
                CurrentAddress = string.Empty,
                State = string.Empty,
                City = string.Empty
            }).Ignore("Not complete.");
        }

        [TestCaseSource(nameof(ValidFormData))]
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
        }
    }

    public class StudentRegistrationFormData : TestCaseParameters
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Mobile { get; set; }
        public required Gender Gender { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public required string[] Subjects { get; set; }
        public required StudentHobbies Hobbies { get; set; }
        public required string PictureFilePath { get; set; }
        public required string CurrentAddress { get; set; }
        public required string State { get; set; }
        public required string City { get; set; }
    }

    public class StudentHobbies
    {
        public bool Sports { get; set; } = false;
        public bool Reading { get; set; } = false;
        public bool Music { get; set; } = false;
    }
}
