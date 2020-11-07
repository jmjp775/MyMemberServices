using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyMemberServices.Data;
using MyMemberServices.Models;

namespace MyMemberServices.Pages.WebServices
{
    public class CreateModel : PageModel
    {
        private readonly MyMemberServices.Data.MyMemberServicesContext _context;

        public CreateModel(MyMemberServices.Data.MyMemberServicesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ServiceAccountRequest ServiceAccountRequest { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ServiceAccountRequest.Add(ServiceAccountRequest);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
