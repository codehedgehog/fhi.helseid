using System;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fhi.HelseId.TokenExchange
{
    public class TokenExchangeSetup
    {
        public IConfiguration Configuration { get; }
        private HelseIdTokenExchangeKonfigurasjon HelseIdConfig { get; }

        public TokenExchangeSetup(IConfiguration configuration)
        {
            Configuration = configuration;
            HelseIdConfig = Configuration.GetTokenExchangeKonfigurasjon();
        }

        public void Configure(IServiceCollection services)
        {
            ConfigureServices(services);
            ConfigureOptions(services);
        }

        public TokenExchangeSetup ConfigureServices(IServiceCollection services)
        {
            foreach (var api in HelseIdConfig.Apis)
                ConfigureService(services, api);
            return this;
        }
        private void ConfigureService(IServiceCollection services, HelseIdApiKonfigurasjonOutgoing api)
        {
            services.AddAccessTokenManagement(options =>
            {
                options.Client.Clients.Add(api.Name, new IdentityModel.Client.ClientCredentialsTokenRequest
                {
                    Address = HelseIdConfig.Authority,
                    ClientId = api.ClientId,
                    ClientSecret = api.ClientSecret,
                    Scope = api.Scope
                });
            });

            services.AddClientAccessTokenClient(api.Name, configureClient: client =>
                {
                    client.BaseAddress = new Uri(api.ApiUrl);
                })
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                {
                    UseProxy = api.UseProxy,
                    Proxy = api.UseProxy ? new WebProxy(api.ProxyUrl, false) : null
                })
                .AddClientAccessTokenHandler();
        }

        public TokenExchangeSetup ConfigureOptions(IServiceCollection services)
        {
            var section = Configuration.GetSection(nameof(HelseIdTokenExchangeKonfigurasjon));
            services.Configure<HelseIdTokenExchangeKonfigurasjon>(section);
            return this;
        }

    }
}