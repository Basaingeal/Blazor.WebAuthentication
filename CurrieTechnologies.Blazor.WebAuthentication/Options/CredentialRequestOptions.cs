using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CurrieTechnologies.Blazor.WebAuthentication
{
    /// <summary>
    /// <see href="https://www.w3.org/TR/credential-management-1/#dictdef-credentialrequestoptions"/>
    /// </summary>
    public class CredentialRequestOptions
    {
        /// <summary>
        /// If set, the user agent will request <see cref="PasswordCredential"/> objects.
        /// Defaults to <code>false</code>.
        /// </summary>
        public bool? Password { get; set; }

        /// <summary>
        /// If set, the user agent will request <see cref="FederatedCredential"/> objects
        /// </summary>
        public FederatedCredentialRequestOptions? Federated { get; set; }

        /// <summary>
        /// This property specifies the mediation requirements for a given credential
        /// request.
        /// </summary>
        public MediationRequirement? Mediation { get; set; }

        /// <summary>
        /// This property specifies options for requesting a public-key signature.
        /// </summary>
        public PublicKeyCredentialRequestOptions? PublicKey { get; set; }

        /// <summary>
        /// This property lets the developer abort an ongoing get() operation.
        /// </summary>
        public CancellationToken? Signal { get; set; }
    }
}
