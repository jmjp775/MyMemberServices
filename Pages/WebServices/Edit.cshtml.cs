using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMemberServices.Data;
using MyMemberServices.Models;

namespace MyMemberServices.Pages.WebServices
{
    public class EditModel : PageModel
    {
        private readonly MyMemberServices.Data.MyMemberServicesContext _context;

        public EditModel(MyMemberServices.Data.MyMemberServicesContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ServiceAccountRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceAccountRequestExists(ServiceAccountRequest.RequestID))
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

        private bool ServiceAccountRequestExists(int id)
        {
            return _context.ServiceAccountRequest.Any(e => e.RequestID == id);
        }
    }
}
