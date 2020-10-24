using System;
using Lab1_Korcz.Rest.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab1_Korcz.Rest.Context
{
    public class AzureDbContext : DbContext
    {
        public AzureDbContext(DbContextOptions<AzureDbContext> options) :base(options)
        {
        }


        protected AzureDbContext()
        {
        }

        public DbSet<Person> People { get; set; }



        }
}
