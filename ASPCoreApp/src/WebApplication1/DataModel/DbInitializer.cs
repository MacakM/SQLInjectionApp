using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DataModel
{
    public class DbInitializer
    {
        public static void Initialize(MyDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Candidates.Any())
            {
                return;   // DB has been seeded
            }

            context.Candidates.AddRange(new List<Candidate>
            {
                new Candidate
                {
                    Name = "Martin",
                    Votes = 63,
                    Info = "Very bad" 
                },
                new Candidate
                {
                    Name = "Peter",
                    Votes = 51,
                    Info = "Very good"
                }
            });

            context.SaveChanges();
        }
    }
}
