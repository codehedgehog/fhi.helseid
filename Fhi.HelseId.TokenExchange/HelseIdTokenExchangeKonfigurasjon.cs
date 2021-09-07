using System;
using Fhi.HelseId.Common;

namespace Fhi.HelseId.TokenExchange
{
    public class HelseIdTokenExchangeKonfigurasjon : HelseIdClientKonfigurasjon
    {
        public HelseIdApiKonfigurasjonOutgoing[] Apis { get; set; } = Array.Empty<HelseIdApiKonfigurasjonOutgoing>();
    }
}