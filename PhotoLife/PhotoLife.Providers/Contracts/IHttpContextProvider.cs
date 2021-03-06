﻿using System.Security.Principal;
using System.Web;
using Microsoft.Owin;

namespace PhotoLife.Providers.Contracts
{
    public interface IHttpContextProvider
    {
        HttpContext CurrentHttpContext { get; }

        IOwinContext CurrentOwinContext { get; }

        IIdentity CurrentIdentity { get; }
        TManager GetUserManager<TManager>();
    }
}
