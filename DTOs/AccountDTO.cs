namespace N_To_N_With_AutoMapper.DTOs;

public class AccountDTO
{
	public int Id { get; set; }
	public string AccountNumber { get; set; } = string.Empty;
	public decimal Balance { get; set; }
	public decimal Limit { get; set; }
	public List<AddressDTO> Addresses { get; set; }
}
