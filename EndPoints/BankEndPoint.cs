using N_To_N_With_AutoMapper.Services;

namespace N_To_N_With_AutoMapper.EndPoints;

public static class BankEndPoint
{
	public static WebApplication MapBankEndPoint(this WebApplication app)
	{
		app.MapGet("/account", (BankService service) =>
		{
			return service.GetAccounts();
		});
		
		return app;
	}
	
}