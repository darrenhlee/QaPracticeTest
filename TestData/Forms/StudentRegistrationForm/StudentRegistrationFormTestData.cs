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

        internal static IEnumerable<TestCaseData> InvalidEmailTestCases
        {
            get
            {
                yield return new TestCaseData(new StudentRegistrationFormData()
                {
                    FirstName = "Plain Address",
                    LastName = "Invalid Email",
                    Email = "plainaddress"
                });

                yield return new TestCaseData(new StudentRegistrationFormData()
                {
                    FirstName = "Missing Username",
                    LastName = "Invalid Email",
                    Email = "@missingusername.com"
                });

                yield return new TestCaseData(new StudentRegistrationFormData()
                {
                    FirstName = "Missing Domain",
                    LastName = "Invalid Email",
                    Email = "username@.com"
                });

                yield return new TestCaseData(new StudentRegistrationFormData()
                {
                    FirstName = "Trailing Dot",
                    LastName = "Invalid Email",
                    Email = "username@.com."
                });

                yield return new TestCaseData(new StudentRegistrationFormData()
                {
                    FirstName = "Consecutive Dots",
                    LastName = "Invalid Email",
                    Email = "username@domain..com"
                });
            }
        }

        internal static IEnumerable<TestCaseData> InvalidMobileTestCases
        {
            get
            {
                yield return new TestCaseData(new StudentRegistrationFormData()
                {
                    FirstName = "Nine Digits",
                    LastName = "Invalid Mobile",
                    Mobile = "123456789"
                });

                yield return new TestCaseData(new StudentRegistrationFormData()
                {
                    FirstName = "Eleven Digits",
                    LastName = "Invalid Mobile",
                    Mobile = "12345678901"
                });

                yield return new TestCaseData(new StudentRegistrationFormData()
                {
                    FirstName = "Contains Hyphens",
                    LastName = "Invalid Mobile",
                    Mobile = "1111111-11"
                });

                yield return new TestCaseData(new StudentRegistrationFormData()
                {
                    FirstName = "Contains Spaces",
                    LastName = "Invalid Mobile",
                    Mobile = "1111111 11"
                });

                yield return new TestCaseData(new StudentRegistrationFormData()
                {
                    FirstName = "Letters Instead",
                    LastName = "Invalid Mobile",
                    Mobile = "abcdefghij"
                });
            }
        }
    }
}
