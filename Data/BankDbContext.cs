using N_To_N_With_AutoMapper.Entities;
using Microsoft.EntityFrameworkCore;

namespace N_To_N_With_AutoMapper.Data;

public class BankDbContext : DbContext
{
	public DbSet<Account> Accounts => Set<Account>();
	public DbSet<Address> Addresses => Set<Address>();
	public DbSet<AccountAddress> AccountAddresses => Set<AccountAddress>();
	
	public BankDbContext(DbContextOptions<BankDbContext> options)
        : base(options) { }
		
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		 modelBuilder.Entity<AccountAddress>()
			.HasKey(aa => new { aa.AccountId, aa.AddressId });

		 modelBuilder.Entity<AccountAddress>()
			.HasOne(aa => aa.Account)
			.WithMany(a => a.AccountAddresses)
			.HasForeignKey(aa => aa.AccountId);

		 modelBuilder.Entity<AccountAddress>()
			.HasOne(aa => aa.Address)
			.WithMany(a => a.AccountAddresses)
			.HasForeignKey(aa => aa.AddressId);

		
		modelBuilder.Entity<Account>().HasData(
            new Account
            {
				Id = 1,
				AccountNumber = "123",
				Balance = 500.00M,
				Limit = 150.00M,
            },
			new Account
            {
				Id = 2,
				AccountNumber = "222",
				Balance = 100.00M,
				Limit = 50.00M,
            });
		
		modelBuilder.Entity<Address>().HasData(
            new Address
            {
				Id = 1,
				City = "Auckland",
            },
			new Address
            {
				Id = 2,
				City = "Hamilton",
            },
			new Address
            {
				Id = 3,
				City = "Wellington",
            },
			new Address
            {
				Id = 4,
				City = "Chirschurch",
            });
			
		
		modelBuilder.Entity<AccountAddress>().HasData(
			new AccountAddress
			{
				AccountId = 1,
				AddressId = 1
			},
			new AccountAddress
			{
				AccountId = 1,
				AddressId = 2
			},
			new AccountAddress
			{
				AccountId = 2,
				AddressId = 1
			},
			new AccountAddress
			{
				AccountId = 2,
				AddressId = 2
			},
			new AccountAddress
			{
				AccountId = 2,
				AddressId = 3
			},
			new AccountAddress
			{
				AccountId = 2,
				AddressId = 4
			});
	}		
}
