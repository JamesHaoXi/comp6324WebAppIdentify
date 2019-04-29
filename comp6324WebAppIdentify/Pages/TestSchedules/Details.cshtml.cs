using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using comp6324WebAppIdentify.Models;

namespace comp6324WebAppIdentify.Pages.TestSchedules
{
    public class DetailsModel : PageModel
    {
        private readonly comp6324WebAppIdentify.Models.comp6324WebAppIdentifyContext _context;

        public DetailsModel(comp6324WebAppIdentify.Models.comp6324WebAppIdentifyContext context)
        {
            _context = context;
        }

        public TestSchedule TestSchedule { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TestSchedule = await _context.TestSchedule.FirstOrDefaultAsync(m => m.ScheduleID == id);

            if (TestSchedule == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
