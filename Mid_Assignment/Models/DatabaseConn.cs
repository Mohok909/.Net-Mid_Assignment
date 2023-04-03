using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mid_Assignment.Models
{
    public class DatabaseConn : DbContext
    {
        public DbSet<Shop> Shops { get; set; }
        public DbSet<FoodRequest> FoodRequests { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<CollectionAssign> CollectionAssigns { get; set; }

    }
}