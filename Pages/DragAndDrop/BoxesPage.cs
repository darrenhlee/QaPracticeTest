using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaPracticeTest.Pages.DragAndDrop
{
    public class BoxesPage : QaPracticePage
    {
        public BoxesPage(IPage page) : base(page, "/elements/dragndrop/boxes")
        {
        }
    }
}
