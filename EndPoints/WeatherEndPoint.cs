using N_To_N_With_AutoMapper.Models;
using N_To_N_With_AutoMapper.Services;

namespace N_To_N_With_AutoMapper.EndPoints;

public static class WeatherForecast
{
	public static WebApplication MapWeatherForecast(this WebApplication app)
	{
		app.MapGet("/weatherforecast", (WheaterService service) =>
		{
			return service.GetWeatherforecast();
		})
		.WithName("GetWeatherForecast");
		
		return app;
	}
}