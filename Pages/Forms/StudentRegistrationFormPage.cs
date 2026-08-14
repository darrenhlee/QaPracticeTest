using Microsoft.Playwright;
using QaPracticeTest.TestData.Forms.StudentRegistrationForm;
using QaPracticeTest.Tests.Forms;

namespace QaPracticeTest.Pages.Forms
{
    public class StudentRegistrationFormPage : QaPracticePage
    {
        // Basic Information
        public ILocator FirstNameInput => Page.GetByLabel("First Name*");
        public ILocator LastNameInput => Page.GetByLabel("Last Name*");
        public ILocator EmailInput => Page.GetByLabel("Email");
        public ILocator MobileInput => Page.GetByLabel("Mobile (10 Digits)*");

        // Gender
        public ILocator MaleGenderInput => Page.GetByLabel("Male", new() { Exact = true });
        public ILocator FemaleGenderInput => Page.GetByLabel("Female");
        public ILocator OtherGenderInput => Page.GetByLabel("Other");

        // Date of Birth
        public ILocator DateOfBirthInput => Page.GetByLabel("Date of Birth");

        // Subject
        public ILocator SubjectInput => Page.GetByPlaceholder("Type to search subjects...");

        // Hobbies
        public ILocator SportsCheckbox => Page.GetByLabel("Sports");
        public ILocator ReadingCheckbox => Page.GetByLabel("Reading");
        public ILocator MusicCheckbox => Page.GetByLabel("Music");

        // Profile Picture
        public ILocator PictureInput => Page.GetByLabel("Picture");

        // Current Address
        public ILocator CurrentAddressTextarea => Page.GetByLabel("Current Address");

        public ILocator StateSelect => Page.GetByLabel("state");
        public ILocator CitySelect => Page.GetByLabel("city");

        public ILocator CustomDropdownMenu => Page.Locator("div.custom-dropdown-menu.show");

        // Submit Button
        public ILocator SubmitButton => Page.GetByRole(AriaRole.Button, new() { NameString = "Submit" });

        // Result Message
        public ILocator SuccessMessage => Page.Locator(".success-message");

        public StudentRegistrationFormResultsModal ResultsModal => new(Page);

        public StudentRegistrationFormPage(IPage page) : base(page, "/forms/practice-form")
        {
        }

        public async Task SetGender(Gender gender)
        {
            switch (gender)
            {
                case Gender.Male:
                    await MaleGenderInput.CheckAsync();
                    break;
                case Gender.Female:
                    await FemaleGenderInput.CheckAsync();
                    break;
                case Gender.Other:
                    await OtherGenderInput.CheckAsync();
                    break;
            }
        }

        public async Task SetDateOfBirth(DateTime dateTime) => await DateOfBirthInput.FillAsync(dateTime.ToString("dd MMM yyyy"));

        public async Task SetSubjects(IEnumerable<string> subjects)
        {
            foreach (var subject in subjects)
            {
                await SubjectInput.FillAsync(subject);
                await SubjectInput.PressAsync("Enter");
            }
        }

        public async Task SetHobbies(StudentHobbies hobbies)
        {
            await SportsCheckbox.SetCheckedAsync(hobbies.Sports);
            await ReadingCheckbox.SetCheckedAsync(hobbies.Reading);
            await MusicCheckbox.SetCheckedAsync(hobbies.Music);
        }

        public async Task UploadPicture(string filePath) 
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                var fileChooser = await Page.RunAndWaitForFileChooserAsync(async () => await PictureInput.ClickAsync());
                await fileChooser.SetFilesAsync(filePath);
            }
        }

        public async Task SelectState(string state)
        {
            if (!string.IsNullOrEmpty(state))
            {
                await Page.Locator("#div_id_state > div.custom-dropdown").ClickAsync();
                await CustomDropdownMenu.GetByText(state).ClickAsync();
            }
        }

        internal async Task SelectCity(string city)
        {
            if (!string.IsNullOrEmpty(city))
            {
                await Page.Locator("#div_id_city > div.custom-dropdown").ClickAsync();
                await CustomDropdownMenu.GetByText(city).ClickAsync();
            }
        }
    }
}
