using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Models
{
	public class IdentityDataContext : IdentityDbContext<AppUser, AppRole, string>
	{
		public IdentityDataContext(DbContextOptions<IdentityDataContext> options) : base(options)
		{

		}

	}
}
