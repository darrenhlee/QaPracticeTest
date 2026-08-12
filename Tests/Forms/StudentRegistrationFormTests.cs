using QaPracticeTest.Pages.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task RequiredFieldsAreRequired()
        {
            await Expect(StudentRegistrationFormPage.FirstNameInput).ToBeRequired();
        }
    }
}
