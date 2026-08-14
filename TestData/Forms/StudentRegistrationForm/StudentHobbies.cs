namespace QaPracticeTest.TestData.Forms.StudentRegistrationForm
{
    public class StudentHobbies
    {
        public bool Sports { get; set; } = false;
        public bool Reading { get; set; } = false;
        public bool Music { get; set; } = false;

        public override string ToString()
        {
            List<string> selectedHobbies = new(3);
            if (Sports) selectedHobbies.Add("Sports");
            if (Reading) selectedHobbies.Add("Reading");
            if (Music) selectedHobbies.Add("Music");
            return string.Join(", ", selectedHobbies);
        }
    }
}
