

// 覧覧覧覧覧覧覧 
// <auto-generated> 
//	This code was auto-generated 01/22/2021 05:38:28
//     	T4 template generates dbcontext context and concurrency code
//	NOTE:T4 generated code may need additional updates/addjustments by developer in order to compile a solution.
// <auto-generated> 
// 覧覧覧覧覧覧蘭

using System;
using System.Threading.Tasks;
using System.Linq;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace AgroExpCore.Entity.Context
{
    public partial class DefaultDbContext : DbContext
    {
	
		public DbSet<Company> Companys { get; set; }

		/// Add new entities concurrency declarations (Fluent API)
		partial void SetAdditionalConcurency(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Company>().Property(a => a.RowVersion).IsRowVersion();
   
		}
	}
}

