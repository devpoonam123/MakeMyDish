using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MakeMyDish.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext():base("DefaultConnection")
        {

        }


        public DbSet<Category> categories { get; set; }
    }
}