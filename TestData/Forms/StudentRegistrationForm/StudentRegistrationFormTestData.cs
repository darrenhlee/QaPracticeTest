using QaPracticeTest.Tests.Forms;

namespace QaPracticeTest.TestData.Forms.StudentRegistrationForm
{
    internal static class StudentRegistrationFormTestData
    {
        internal static IEnumerable<TestCaseData> ValidFormData()
        {
            // Minimal info
            yield return new TestCaseData(new StudentRegistrationFormData()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = string.Empty,
                Mobile = "1234567890",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(1969, 6, 21),
                Subjects = [],
                Hobbies = new StudentHobbies(),
                PictureFilePath = string.Empty,
                CurrentAddress = string.Empty,
                State = string.Empty,
                City = string.Empty
            });

            // All fields complete
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
                PictureFilePath = @"..\..\..\TestData\Basic_human_drawing.png",
                CurrentAddress = "123 Fake Street",
                State = "NCR",
                City = "Delhi"
            });
        }
    }
}
