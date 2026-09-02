using NUnit.Framework.Internal;

namespace QaPracticeTest.TestData.Forms.StudentRegistrationForm
{
    public class StudentRegistrationFormData : TestCaseParameters
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public Gender Gender { get; set; } = Gender.Other;
        public DateTime DateOfBirth { get; set; } = DateTime.Today;
        public string[] Subjects { get; set; } = [];
        public StudentHobbies Hobbies { get; set; } = new StudentHobbies();
        public string PictureFilePath { get; set; } = string.Empty;
        public string CurrentAddress { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        public override string ToString()
        {
            var subjectsStr = Subjects.Length > 0 ? string.Join(", ", Subjects) : "None";
            var pictureStr = !string.IsNullOrEmpty(PictureFilePath) ? Path.GetFileName(PictureFilePath) : "None";
            var emailStr = !string.IsNullOrEmpty(Email) ? Email : "Not provided";
            var addressStr = !string.IsNullOrEmpty(CurrentAddress) ? CurrentAddress : "Not provided";
            var stateStr = !string.IsNullOrEmpty(State) ? State : "Not provided";
            var cityStr = !string.IsNullOrEmpty(City) ? City : "Not provided";

            return $"Student Registration Data:\n" +
                   $"  Name: {FirstName} {LastName}\n" +
                   $"  Email: {emailStr}\n" +
                   $"  Mobile: {Mobile}\n" +
                   $"  Gender: {Gender}\n" +
                   $"  Date of Birth: {DateOfBirth:dd MMM yyyy}\n" +
                   $"  Subjects: {subjectsStr}\n" +
                   $"  Hobbies: {Hobbies}\n" +
                   $"  Picture: {pictureStr}\n" +
                   $"  Address: {addressStr}\n" +
                   $"  State: {stateStr}\n" +
                   $"  City: {cityStr}";
        }
    }
}
