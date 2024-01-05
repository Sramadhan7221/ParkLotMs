using Microsoft.Extensions.Options;
using ParkLotMs.Infrastructure.Authentication;

namespace ParkLotMs.WebApi.OptionsSetup;

public class JwtOptionSetup : IConfigureOptions<JwtOptions>
{
    private const string SectionName = "Jwt";
    private readonly IConfiguration _configuration;

    public JwtOptionSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtOptions options)
    {
        _configuration.Bind(SectionName,options);
    }
}
