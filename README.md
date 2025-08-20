# This is an example of working with Entity Framework


<img width="587" height="310" alt="image" src="https://github.com/user-attachments/assets/6faa72c4-450d-4219-937c-8de3cb8620de" />


### What is interesting about this kind of relationship in EF is the simplicity that is lacking in the One-to-N, as the table that ties both tables together is an ordinary table. The first table (Account) has a navigation property; basically, this is a list of type 'AccountAddress'. The second table also has the same declaration.

	**In this project example, I am demonstrating the use of the relationship N-TO-N with Microsoft Entity Framework.
	For simplicity's sake, I am using AutoMapper.
	As I want to focus on the relationship between tables, building the 'Mapping' manually can be a little frustrating sometimes.**
	
	
	

1. Create your Entity classes

	Folder: Entities:
	
		AccountEntity.cs
		AddressEntity.cs
		AccountAddressEntity.cs
		
		
	
	Relation: N-TO-N
		
			In this example: An account can have many Addresses, and One Address can have many Accounts.
			
			Declare a property in the 'Account' class of type ICollection that will
			be a type of a new List of the class Address. Example:
			
			// This is called a Navigation property.
			// Check the convention names like the plural for the type name
	        public ICollection<Address> addresses { get; set; } = new List<Address>();
			
			
	Optional:
			Into the class 'Address', add a navigation property of type of 
			class 'Account'. Example:
			
			// Navigation Property
			public Account Account { get; set; } = null;
		
		
	Note: If you don't declare the optional navigation property in 'Address'
	      Your scripts to create the tables and relationships won't be affected.
		  This will be used for EF to create queries and use strategies to load
		  the data from these tables,(Lazy, Eager, Explici).
		  
	Option: For clarity's sake:
	
		Enforce the referential integrity:

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

		
	Option: Seeds

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
		  
		  
		
		
2. Create your DbContext Service

	Folder: Data
		
		 BankDbContext.cs
		 
3.  Register your DbContext service class into DI container in the Program.cs


	File: Program.cs
	
	
	
	
