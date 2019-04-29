using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using comp6324WebAppIdentify.Models;
using Microsoft.AspNetCore.Authorization;

namespace comp6324WebAppIdentify.Pages.TestSchedules
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly comp6324WebAppIdentify.Models.comp6324WebAppIdentifyContext _context;

        public IndexModel(comp6324WebAppIdentify.Models.comp6324WebAppIdentifyContext context)
        {
            _context = context;
        }

        public IList<TestSchedule> TestSchedule { get;set; }

        public async Task OnGetAsync()
        {
            TestSchedule = await _context.TestSchedule.ToListAsync();
        }
    }
}
