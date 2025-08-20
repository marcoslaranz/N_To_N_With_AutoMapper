using N_To_N_With_AutoMapper.Models;

namespace N_To_N_With_AutoMapper.Services;

public class WheaterService
{
	private readonly string[] summaries = new[]
	{
		"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	};

	public IEnumerable<WeatherForecast> GetWeatherforecast()
	{
		return Enumerable.Range(1, 5).Select(index =>
			new WeatherForecast
			(
				DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
				Random.Shared.Next(-20, 55),
				summaries[Random.Shared.Next(summaries.Length)]
			))
			.ToArray();
	}
}