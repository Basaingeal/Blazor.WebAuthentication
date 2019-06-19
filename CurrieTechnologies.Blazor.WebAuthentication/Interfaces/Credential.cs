using System;
using System.Collections.Generic;
using System.Text;

namespace CurrieTechnologies.Blazor.WebAuthentication
{
    public abstract class Credential
    {
        /// <summary>
        /// Returns a string containing the credential's identifier.
        /// This might be any one of a GUID, username, or email address.
        /// </summary>
        public virtual string Id { get; internal set; }

        /// <summary>
        /// Returns a DOMString containing the credential's type.
        /// Valid values are password, federated and public-key.
        /// </summary>
        public virtual CredentialType Type { get; internal set; }
    }
}
