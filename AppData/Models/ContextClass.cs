using AppData.Models.ModelConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppData.Models
{
   public class ContextClass:DbContext
    {
        public ContextClass (DbContextOptions<ContextClass> options)
            :base(options)
        {
        }

        protected override void OnModelCreating (ModelBuilder modelbuilder)
             => modelbuilder.ApplyConfiguration(new ClientConfiguration () );
        public DbSet<Client> Client { get; set; }

    }
}
