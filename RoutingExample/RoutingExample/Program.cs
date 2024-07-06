using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

IDictionary<int,string> country = new Dictionary<int,string>();
country.Add(1, "United States");
country.Add(2, "Canada");
country.Add(3, "United Kingdom");
country.Add(4, "India");
country.Add(5, "Japan");


//enable routing
app.UseRouting();

//creating endpoints
app.UseEndpoints(endpoints =>
{
    endpoints.Map("/countries", async context =>
    {
        var response = new StringBuilder();
        foreach (var kvp in country)
        {
            response.AppendLine($"{kvp.Key}: {kvp.Value}");
        }

        await context.Response.WriteAsync(response.ToString());
    });


    endpoints.Map("/countries/{countryid:int}", async context =>
    {
        var countryIdStr = context.Request.RouteValues["countryid"].ToString();
        int countreyid2 = Int32.Parse(countryIdStr);
        if (int.TryParse(countryIdStr, out int countryId) && country.TryGetValue(countryId, out var countryName))
        {
            var response = new StringBuilder();
            response.AppendLine($"{countryId}: {countryName}");
            await context.Response.WriteAsync(response.ToString());
        }
        else if ( countreyid2 > 100)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("The CountryID should be between 1 and 100");
        }
        else
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("Country not found.");
        }
    });


});
app.Run();
