using System;
using System.Collections.Generic;
using System.Text;

namespace CurrieTechnologies.Blazor.WebAuthentication
{
    /// <summary>
    /// <see href="https://www.w3.org/TR/credential-management-1/#dictdef-siteboundcredentialdata"/>
    /// </summary>
    public class SiteBoundCredentialData : CredentialData
    {
        /// <summary>
        /// A name associated with the credential, intended as a human-understandable
        /// public name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// A URL pointing to an image for the credential. This URL MUST be an
        /// <see href="https://w3c.github.io/webappsec-mixed-content/#a-priori-authenticated-url">
        /// a priori authenticated URL</see>
        /// </summary>
        public string? IconURL { get; set; }
    }
}
