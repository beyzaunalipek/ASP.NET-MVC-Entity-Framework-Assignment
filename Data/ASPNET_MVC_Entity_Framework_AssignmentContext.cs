using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ASP_NET_MVC_Entity_Framework_Assignment.Models;

namespace ASP_NET_MVC_Entity_Framework_Assignment.Data
{
    public class ASPNET_MVC_Entity_Framework_AssignmentContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ASPNET_MVC_Entity_Framework_AssignmentContext() : base("name=ASPNET_MVC_Entity_Framework_AssignmentContext")
        {
        }

        public System.Data.Entity.DbSet<Insuree> Insurees { get; set; }
    }
}
