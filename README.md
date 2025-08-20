This is an example of working with Entity Framework

	This project adds some complexity due the addition of 
	DTOs returning from the ENDPOINTs we could return directly
	the 'Entities' what would make it very simple without need 
	of 'Mappings'
	Other element that contribute for the complexity is the need
	of a circular reference of Account inside of a DTO Address.
	
	
	

1. Create your Entities classes

	Folder: Entities:
	
		AccountEntity.cs
		AddressEntity.cs
		
	
	Relation: 1-TO-N
		
			In this example: each Account can have multple addresses
			
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
	
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Address>()
				.HasOne(a => a.Account)
				.WithMany(acc => acc.addresses)
				.HasForeignKey(a => a.AccountId)
				.OnDelete(DeleteBehavior.Cascade); // Optional: controls delete behavior
		}
		
	Option: Seeds

			modelBuilder.Entity<Account>().HasData(
            new Account
            {
				Id = 1;
				AccountNumber = "123";
				Balance = 100.00;
				Limit = 50;
            });
		
			modelBuilder.Entity<Address>().HasData(
            new Address
            {
				Id = 1;
				AccountId = "123";
				City = "Auckland";
            });
		  
		  
		
		
2. Create your DbContext Service

	Folder: Data
		
		 BankDbContext.cs
		 
3.  Register your DbContext service class into DI container in the Program.cs


	File: Program.cs
	
	
	
	