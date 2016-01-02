using System;
using Microsoft.Data.Entity;

namespace EFTesting.DAL
{
    public class EFTestingContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
        }
    }
}
