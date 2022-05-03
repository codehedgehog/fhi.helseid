﻿using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace Fhi.HelseId.Api
{
    public class ConfigureAuthentication
    {
        public Action<CookieAuthenticationOptions>? ConfigureCookieAuthentication { get; set; }
        public Action<OpenIdConnectOptions>? ConfigureOpenIdConnect { get; set; }
    }
}
