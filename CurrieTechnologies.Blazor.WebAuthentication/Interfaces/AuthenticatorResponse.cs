using System;
using System.Collections.Generic;
using System.Text;

namespace CurrieTechnologies.Blazor.WebAuthentication
{
    /// <summary>
    /// The AuthenticatorResponse interface of the Web Authentication API is the base interface for interfaces that provide a cryptographic root of trust for a key pair.
    /// The child interfaces include information from the browser such as the challenge origin and either may be returned from PublicKeyCredential.Response.
    /// </summary>
    public class AuthenticatorResponse
    {
        /// <summary>
        /// A JSON string in a byte[], representing the client data that was passed to CredentialsContainer.Create() or CredentialsContainer.Get(). 
        /// </summary>
        public virtual byte[] ClientDataJSON { get; internal set; }
    }
}
