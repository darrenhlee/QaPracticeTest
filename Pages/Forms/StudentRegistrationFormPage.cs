using Microsoft.Playwright;

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
        public ILocator DateOfBirthInput => Page.GetByLabel("Date of Birth*");

        // Subject
        public ILocator SubjectInput => Page.GetByLabel("Subject*");

        // Hobbies
        public ILocator SportsCheckbox => Page.GetByLabel("Sports");
        public ILocator ReadingCheckbox => Page.GetByLabel("Reading");
        public ILocator MusicCheckbox => Page.GetByLabel("Music");

        // Profile Picture
        public ILocator PictureInput => Page.GetByLabel("Picture");

        // Current Address
        public ILocator CurrentAddressTextarea => Page.GetByLabel("Current Address");

        // State and City
        public ILocator StateDropdown => Page.GetByLabel("State");
        public ILocator CityDropdown => Page.GetByLabel("City");

        // Submit Button
        public ILocator SubmitButton => Page.GetByRole(AriaRole.Button, new() { NameString = "Submit" });

        // Result Message
        public ILocator SuccessMessage => Page.Locator(".success-message");

        public StudentRegistrationFormPage(IPage page) : base(page, "/forms/practice-form")
        {
        }
    }
}
