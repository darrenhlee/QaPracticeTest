using NUnit.Framework.Internal;
using QaPracticeTest.Tests.Forms;

namespace QaPracticeTest.TestData.Forms.StudentRegistrationForm
{
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
}
