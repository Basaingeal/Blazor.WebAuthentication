using System;
using System.Collections.Generic;
using System.Text;

namespace CurrieTechnologies.Blazor.WebAuthentication
{
    /// <summary>
    /// The AuthenticatorAttestationResponse interface of the Web Authentication API is returned by CredentialsContainer.Create() when a PublicKeyCredential is passed, and provides a cryptographic root of trust for the new key pair that has been generated.
    /// This response should be sent to the relying party's server to complete the creation of the credential.
    /// </summary>
    public class AuthenticatorAttestationResponse : AuthenticatorResponse
    {
        /// <summary>
        /// A byte[] containing authenticator data and an attestation statement for a newly-created key pair.
        /// </summary>
        public byte[] AttestationObject { get; internal set; }

        internal Guid DomId { get; set; }

        /// <summary>
        /// Returns an Array of strings describing which transport methods (e.g. "usb", "nfc") are believed to be supported with the authenticator. The array may be empty if the information is not available.
        /// </summary>
        /// <returns></returns>
        public AuthenticatorTransport[] GetTransports()
        {
            throw new NotImplementedException();
        }
    }
}
