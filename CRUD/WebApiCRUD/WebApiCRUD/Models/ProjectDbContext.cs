using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApiCRUD.Models
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<Info> Infos { get; set; }
    }
}