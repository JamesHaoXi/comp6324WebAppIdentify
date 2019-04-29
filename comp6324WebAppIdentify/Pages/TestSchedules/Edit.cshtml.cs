using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using comp6324WebAppIdentify.Models;

namespace comp6324WebAppIdentify.Pages.TestSchedules
{
    public class EditModel : PageModel
    {
        private readonly comp6324WebAppIdentify.Models.comp6324WebAppIdentifyContext _context;

        public EditModel(comp6324WebAppIdentify.Models.comp6324WebAppIdentifyContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TestSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestScheduleExists(TestSchedule.ScheduleID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TestScheduleExists(int id)
        {
            return _context.TestSchedule.Any(e => e.ScheduleID == id);
        }
    }
}
