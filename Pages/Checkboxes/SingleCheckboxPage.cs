using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaPracticeTest.Pages.Checkboxes
{
    internal class SingleCheckboxPage : CheckboxPage
    {


        public SingleCheckboxPage(IPage page, string url) : base(page, "https://www.qa-practice.com/elements/checkbox/single_checkbox")
        {
        }
    }
}
