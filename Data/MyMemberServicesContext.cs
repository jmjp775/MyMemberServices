using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyMemberServices.Models;

namespace MyMemberServices.Data
{
    public class MyMemberServicesContext : DbContext
    {
        public MyMemberServicesContext (DbContextOptions<MyMemberServicesContext> options)
            : base(options)
        {
        }

        public DbSet<MyMemberServices.Models.ServiceAccountRequest> ServiceAccountRequest { get; set; }
    }
}
