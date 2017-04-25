using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DataModel
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Votes { get; set; }
        public string Info { get; set; }
    }
}
