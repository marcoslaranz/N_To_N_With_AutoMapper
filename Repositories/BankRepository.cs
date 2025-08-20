using Microsoft.EntityFrameworkCore;
using N_To_N_With_AutoMapper.DTOs;
using N_To_N_With_AutoMapper.Services;
using N_To_N_With_AutoMapper.Entities;
using N_To_N_With_AutoMapper.Data;
using N_To_N_With_AutoMapper.Application.Common.Mappings;
using AutoMapper;


namespace N_To_N_With_AutoMapper.Repositories;

public class BankRepository
{
	private readonly BankDbContext _dbcontext;
	private readonly IMapper _mapper;
	
	public BankRepository(BankDbContext dbcontext, IMapper mapper)
	{
		_dbcontext = dbcontext;
		_mapper = mapper;
	}
	
	public async Task<List<AccountDTO>> GetAllAccountsAsync()
	{
		var accounts = await _dbcontext.Accounts
			.Include(a => a.AccountAddresses)
			.ThenInclude(aa => aa.Address)
			.ToListAsync();

		return _mapper.Map<List<AccountDTO>>(accounts);
	}
}