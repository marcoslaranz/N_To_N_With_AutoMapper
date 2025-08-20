using N_To_N_With_AutoMapper.DTOs;
using N_To_N_With_AutoMapper.Repositories;
using N_To_N_With_AutoMapper.Entities;
//using N_To_N_With_AutoMapper.Mapping;


namespace N_To_N_With_AutoMapper.Services;

public class BankService
{	
	private readonly BankRepository _repo;
	
	public BankService(BankRepository repo)
	{
		_repo = repo;
	}
	
	public async Task<List<AccountDTO>> GetAccounts()
	{
		return await _repo.GetAllAccountsAsync();
	}
}

