using System;

namespace Fhi.HelseId.TokenExchange
{
    public class HelseIdApiKonfigurasjonOutgoing
    {
        public string Name { get; set; } = "";
        public string ApiUrl { get; set; } = "";
        public string Scope { get; set; } = "";
        public string ProxyUrl { get; set; } = "";
        public bool UseProxy { get; set; } = false;
        public Uri ApiUri => new(ApiUrl);
        public Uri ProxyUri => UseProxy ? new Uri(ProxyUrl) : null;

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}