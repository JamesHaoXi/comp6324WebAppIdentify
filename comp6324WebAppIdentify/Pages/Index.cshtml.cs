using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace comp6324WebAppIdentify.Pages
{
    [Authorize(Roles = "Admin")]
    //[Authorize]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}
