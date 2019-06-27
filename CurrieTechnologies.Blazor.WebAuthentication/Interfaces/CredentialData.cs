using System;
using System.Collections.Generic;
using System.Text;

namespace CurrieTechnologies.Blazor.WebAuthentication
{
    public class CredentialData
    {
        /// <summary>
        /// The credential’s identifier. This might be a GUID, username, or email
        /// address, for instance.
        /// </summary>
        public virtual string Id { get; set; }
    }
}
