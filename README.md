# This is an example of working with Entity Framework

	**In this project example I am demostrating the use of the relationship N-TO-N with Microsoft EntityFramework.
	For simplicity sake I am using AutoMapper
	as build the Mappings manually when you want to focus on 
	the relationship between tables, can be a little frustated sometimes.**
	
	
	

1. Create your Entities classes

	Folder: Entities:
	
		AccountEntity.cs
		AddressEntity.cs
		AccountAddressEntity.cs
		
		
	
	Relation: N-TO-N
		
			In this example: An account can have many Addresses, and One Address can have many Accounts.
			
			Declare a property into 'Account' class of type ICollection that will
			be a type of a new List of the class Address. Example:
			
			// This is called Navigation property.
			// Check the convetion names like the plural for the type name
	        public ICollection<Address> addresses { get; set; } = new List<Address>();
			
			
	Optional:
			Into the class 'Address' add a navigation property of type of 
			class 'Account'. Example:
			
			// Navigation Property
			public Account Account { get; set; } = null;
		
		
	Note: If you don't declare the optional navigation property into 'Address'
	      Your scrips to create the tables and relationship won't be affected.
		  This will be use for EF to create queries and use strategies to load
		  the data from these tables,(Lazy, Eager, Explici).
		  
	Option: For clarity sake:
	
		Enforce the referential entigrity:

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
	
	
	
	