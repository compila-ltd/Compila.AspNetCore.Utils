using Compila.Net.Utils.Exceptions;

using Microsoft.AspNetCore.Authorization;

namespace Compila.AspNetCore.Utils.Authorization
{
    public class HasScopeRequirement : IAuthorizationRequirement
    {
        public string Issuer { get; set; }
        public string Scope { get; set; }

        public HasScopeRequirement(string scope, string issuer)
        {
            Issuer = issuer ?? throw new NullArgumentsException(nameof(issuer));
            Scope = scope ?? throw new NullArgumentsException(nameof(scope));
        }
    }
}
