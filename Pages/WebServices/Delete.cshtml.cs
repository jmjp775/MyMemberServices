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
    public class DeleteModel : PageModel
    {
        private readonly MyMemberServices.Data.MyMemberServicesContext _context;

        public DeleteModel(MyMemberServices.Data.MyMemberServicesContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ServiceAccountRequest = await _context.ServiceAccountRequest.FindAsync(id);

            if (ServiceAccountRequest != null)
            {
                _context.ServiceAccountRequest.Remove(ServiceAccountRequest);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
