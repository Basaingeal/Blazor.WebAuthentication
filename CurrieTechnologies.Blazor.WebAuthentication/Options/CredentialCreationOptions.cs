using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CurrieTechnologies.Blazor.WebAuthentication
{
    /// <summary>
    /// <see href="https://www.w3.org/TR/2017/WD-credential-management-1-20170804/#dictdef-credentialcreationoptions"/>
    /// </summary>
    public class CredentialCreationOptions
    {
        /// <summary>
        /// <see href="https://www.w3.org/TR/2017/WD-credential-management-1-20170804/#dictdef-federatedcredentialinit"/>
        /// </summary>
        public PasswordCredentialData? Password { get; set; }

        /// <summary>
        /// <see href="https://www.w3.org/TR/2017/WD-credential-management-1-20170804/#dom-credentialcreationoptions-federated"/>
        /// </summary>
        public FederatedCredentialData? Federated { get; set; }
        /// <summary>
        /// <see href="https://w3c.github.io/webauthn/#dictionary-makecredentialoptions"/>
        /// </summary>
        public PublicKeyCredentialCreationOptions? PublicKey { get; set; }

        /// <summary>
        /// <see href="https://w3c.github.io/webappsec-credential-management/#dom-credentialrequestoptions-signal"/>
        /// </summary>
        public CancellationTokenSource? Signal { get; private set; } = new CancellationTokenSource();
    }
}
