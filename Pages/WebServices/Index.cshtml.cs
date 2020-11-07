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
    public class IndexModel : PageModel
    {
        private readonly MyMemberServices.Data.MyMemberServicesContext _context;

        public IndexModel(MyMemberServices.Data.MyMemberServicesContext context)
        {
            _context = context;
        }

        public IList<ServiceAccountRequest> ServiceAccountRequest { get;set; }

        public async Task OnGetAsync()
        {
            ServiceAccountRequest = await _context.ServiceAccountRequest.ToListAsync();
        }
    }
}
