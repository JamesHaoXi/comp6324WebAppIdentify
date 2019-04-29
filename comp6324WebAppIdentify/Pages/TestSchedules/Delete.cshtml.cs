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
    public class DeleteModel : PageModel
    {
        private readonly comp6324WebAppIdentify.Models.comp6324WebAppIdentifyContext _context;

        public DeleteModel(comp6324WebAppIdentify.Models.comp6324WebAppIdentifyContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TestSchedule = await _context.TestSchedule.FindAsync(id);

            if (TestSchedule != null)
            {
                _context.TestSchedule.Remove(TestSchedule);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
