using System;
using System.Collections.Generic;
using System.Text;

namespace CurrieTechnologies.Blazor.WebAuthentication
{
    /// <summary>
    /// The AuthenticatorAssertionResponse interface of the Web Authentication API is returned by CredentialsContainer.Get() when a PublicKeyCredential is passed, and provides proof to a service that it has a key pair and that the authentication request is valid and approved.
    /// </summary>
    public class AuthenticatorAssertionResponse : AuthenticatorResponse
    {
        /// <summary>
        /// A byte[] containing information from the authenticator such as the Relying Party ID Hash (rpIdHash), a signature counter, test of user presence and user verification flags, and any extensions processed by the authenticator.
        /// </summary>
        public byte[] AuthenticatorData { get; internal set; }

        /// <summary>
        /// An assertion signature over AuthenticatorAssertionResponse.AuthenticatorData and AuthenticatorResponse.ClientDataJSON.
        /// The assertion signature is created with the private key of keypair that was created during the navigator.credentials.create() call and verified using the public key of that same keypair.
        /// </summary>
        public byte[] Signature { get; internal set; }

        /// <summary>
        /// A byte[] containing an opaque user identifier.
        /// </summary>
        public byte[] UserHandle { get; internal set; }
    }
}
