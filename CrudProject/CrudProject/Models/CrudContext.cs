using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CrudProject.Models
{
    public class CrudContext : DbContext
    {
        public DbSet<CrudProject.Models.Player> Players { get; set; }
    }
}