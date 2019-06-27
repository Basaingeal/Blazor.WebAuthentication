using System;
using System.Collections.Generic;
using System.Text;

namespace CurrieTechnologies.Blazor.WebAuthentication
{
    /// <summary>
    /// A generic and extensible Credential interface from which all credentials
    /// will inherit.
    /// <see href="https://www.w3.org/TR/credential-management-1/#credential"/>
    /// </summary>
    public abstract class CredentialBase
    {
        /// <summary>
        /// The credential’s identifier. This might be a GUID, username, or email
        /// address, for instance.
        /// </summary>
        public virtual string Id { get; internal set; }

        /// <summary>
        /// The credential’s type.
        /// </summary>
        public virtual string Type { get; internal set; }
    }
}
