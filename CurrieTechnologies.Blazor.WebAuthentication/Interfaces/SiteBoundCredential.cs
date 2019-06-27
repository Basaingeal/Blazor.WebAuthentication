using System;
using System.Collections.Generic;
using System.Text;

namespace CurrieTechnologies.Blazor.WebAuthentication
{
    /// <summary>
    /// Defines the specific attributes shared by any Credential persisted in user
    /// agent’s credential
    /// store.
    /// </summary>
    public abstract class SiteBoundCredential : CredentialBase
    {
        /// <summary>
        /// A name associated with the credential, intended as a human-understandable
        /// public name.
        /// </summary>
        public string? Name { get; internal set; }

        /// <summary>
        /// A URL pointing to an image for the credential. This URL MUST be an
        /// <see href="https://w3c.github.io/webappsec-mixed-content/#a-priori-authenticated-url">
        /// a priori authenticated URL</see>
        /// </summary>
        public string? IconUrl { get; internal set; }
    }
}
