namespace N_To_N_With_AutoMapper.Entities;

public class Account
{
	public int Id { get; set; }
	public string AccountNumber { get; set; } = string.Empty;
	public decimal Balance { get; set; }
	public decimal Limit { get; set; }
	
	// Navigation property
	public ICollection<AccountAddress> AccountAddresses { get; set; } = new List<AccountAddress>();
}