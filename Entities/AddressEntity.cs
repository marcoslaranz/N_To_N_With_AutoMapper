namespace N_To_N_With_AutoMapper.Entities;

public class Address
{
    public int Id { get; set; }
    public string City { get; set; } = string.Empty;
    public ICollection<AccountAddress> AccountAddresses { get; set; } = new List<AccountAddress>();
}