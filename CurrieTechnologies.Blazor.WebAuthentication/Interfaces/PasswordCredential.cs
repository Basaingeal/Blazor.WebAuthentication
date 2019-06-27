using System;
using System.Collections.Generic;
using System.Text;

namespace CurrieTechnologies.Blazor.WebAuthentication
{
    public class PasswordCredential: SiteBoundCredential
    {
        public override string Type { get; internal set; } = "password";

        /// <summary>
        /// Represents the name which will be used for the ID field when submitting
        /// the PasswordCredential to a remote endpoint via <code>fetch()</code>. It
        /// defaults to "username", but can be overridden by a developer to match
        /// whatever the backend service expects.
        /// <see href="https://www.w3.org/TR/credential-management-1/#dom-passwordcredential-idname"/>
        /// </summary>
        public string IdName { get; set; }

        /// <summary>
        /// Represents the name which will be used for the ID field when submitting
        /// the PasswordCredential to a remote endpoint via fetch(). It defaults to
        /// "password", but can be overridden by a developer to match whatever the
        /// backend service expects.
        /// <see href="https://www.w3.org/TR/credential-management-1/#dom-passwordcredential-passwordname"/>
        /// </summary>
        public string PasswordName { get; set; }

        /// <summary>
        /// The plain-text password. Returned for implementation of the 08/04/2017
        /// Working Draft of Credential Management, not returned before this.
        /// <see href="https://www.w3.org/TR/credential-management-1/#passwordcredential"/>
        /// </summary>
        public string? Password { get; internal set; }

        /// <summary>
        /// <see href="https://www.w3.org/TR/credential-management-1/#dom-passwordcredential-passwordcredential-data"/>
        /// <see href="https://www.w3.org/TR/credential-management-1/#dom-passwordcredential-passwordcredential"/>
        /// </summary>
        public PasswordCredential(PasswordCredentialData data)
        {
            Id = data.Id;
            Name = data.Name;
            Password = data.Password;
            IdName = "username";
            PasswordName = "password";
        }
    }
}
