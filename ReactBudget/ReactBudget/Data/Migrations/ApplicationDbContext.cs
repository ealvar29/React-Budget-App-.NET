using Microsoft.EntityFrameworkCore;
using ReactBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactBudget.Data.Migrations
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Expense> Expenses { get; set; }
    }
}
