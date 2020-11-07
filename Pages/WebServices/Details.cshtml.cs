using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyMemberServices.Data;
using MyMemberServices.Models;

namespace MyMemberServices.Pages.WebServices
{
    public class DetailsModel : PageModel
    {
        private readonly MyMemberServices.Data.MyMemberServicesContext _context;

        public DetailsModel(MyMemberServices.Data.MyMemberServicesContext context)
        {
            _context = context;
        }

        public ServiceAccountRequest ServiceAccountRequest { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ServiceAccountRequest = await _context.ServiceAccountRequest.FirstOrDefaultAsync(m => m.RequestID == id);

            if (ServiceAccountRequest == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
