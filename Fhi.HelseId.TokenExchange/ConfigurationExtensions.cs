using Fhi.HelseId.Common;
using Microsoft.Extensions.Configuration;

namespace Fhi.HelseId.TokenExchange
{
    public static class ConfigurationExtensions
    {
        public static HelseIdTokenExchangeKonfigurasjon GetTokenExchangeKonfigurasjon(this IConfiguration root) =>
            root.GetConfig<HelseIdTokenExchangeKonfigurasjon>(nameof(HelseIdTokenExchangeKonfigurasjon));

    }
}
