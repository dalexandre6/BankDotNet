using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankQ1Investment.Models
{
    public class SeedData
    {
        public static void Initialized(IServiceProvider serviceProvider)
        {
            using (var context = new BankQ1InvestmentContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<BankQ1InvestmentContext>>()))  //Warning! Here you must type the ..Context
            {
                // Look for any Customer.
                if (context.ClientBasicInfo.Any())//Change to ..ClientBasicInfo.Any
                {
                    return; // DB has been seeded
                }
                context.ClientBasicInfo.AddRange(  //Change to ..ClientBasicInfo
                new ClientBasicInfo
                {
                    Customer_Name = "Sally LLC",
                    Location = "Chicago",
                    Current_Investment = 520000,

                },

                new ClientBasicInfo
                {
                    Customer_Name = "Spicy Inc",
                    Location = "Chicago",
                    Current_Investment = 520000,

                }
            );
                context.SaveChanges();

            }

        }

    }
}
