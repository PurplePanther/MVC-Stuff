using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VidlyClone3.Models
{
    public class VidlyClone3Context : DbContext
    {
        public VidlyClone3Context (DbContextOptions<VidlyClone3Context> options)
            : base(options)
        {
        }

        public DbSet<VidlyClone3.Models.Cats> Cats { get; set; }
    }
}
