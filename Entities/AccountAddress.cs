namespace N_To_N_With_AutoMapper.Entities;

public class AccountAddress
{
    public int AccountId { get; set; }
    public Account Account { get; set; } = null!;

    public int AddressId { get; set; }
    public Address Address { get; set; } = null!;
}