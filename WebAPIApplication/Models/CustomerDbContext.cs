using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAPIApplication.Models
{
    public class CustomerDbContext:DbContext
    {
       public CustomerDbContext() : base("connection")
        {
           

        }

        public DbSet<Product> Products { get; set; }


    }

}