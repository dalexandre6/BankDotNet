using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BankQ1Investment.Models
{
    public class BankQ1InvestmentContext : DbContext
    {
        public BankQ1InvestmentContext (DbContextOptions<BankQ1InvestmentContext> options)
            : base(options)
        {

        }

        public DbSet<BankQ1Investment.Models.ClientBasicInfo> ClientBasicInfo { get; set; }
    }
}
