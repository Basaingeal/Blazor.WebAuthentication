using System;
using System.Collections.Generic;
using System.Text;

namespace CurrieTechnologies.Blazor.WebAuthentication
{
    /// <summary>
    /// <see href="https://www.w3.org/TR/credential-management-1/#dictdef-passwordcredentialdata"/>
    /// </summary>
    public class PasswordCredentialData : SiteBoundCredentialData
    {
        /// <summary>
        /// The plain-text password.
        /// </summary>
        public string Password { get; internal set; }
    }
}
