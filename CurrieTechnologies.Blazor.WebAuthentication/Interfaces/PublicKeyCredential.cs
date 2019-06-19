using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrieTechnologies.Blazor.WebAuthentication
{
    /// <summary>
    /// The PublicKeyCredential interface provides information about a public key / private key pair, which is a credential for logging in to a service using an un-phishable and data-breach resistant asymmetric key pair instead of a password.
    /// It inherits from <see cref="Credential"/>, and was created by the Web Authentication API extension to the Credential Management API.
    /// Other interfaces that inherit from <see cref="Credential"/> are PasswordCredential and FederatedCredential.
    /// </summary>
    public class PublicKeyCredential : Credential
    {
        /// <summary>
        /// Inherited from Credential and overridden to be the base64url encoding of PublicKeyCredential.RawId.
        /// </summary>
        public override string Id => Convert.ToBase64String(RawId);

        /// <summary>
        /// A byte[] that holds the globally unique identifier for this PublicKeyCredential.
        /// This identifier can be used to look up credentials for future calls to CredentialsContainer.Get.
        /// </summary>
        public byte[] RawId { get; internal set; }

        /// <summary>
        /// An instance of an AuthenticatorResponse object.
        /// It is either of type AuthenticatorAttestationResponse if the PublicKeyCredential was the results of a navigator.credentials.create() call, or of type AuthenticatorAssertionResponse if the PublicKeyCredential was the result of a navigator.credentials.get() call.
        /// </summary>
        public AuthenticatorResponse Response { get; internal set; }

        private Guid domId;
        private IJSRuntime? jSRuntime;
        private IJSInProcessRuntime? jSInProcessRuntime;
        private readonly string jsNamespace = "CurrieTechnologies.Blazor.WebAuthentication";

        public byte[] GetClientExtensionResults()
        {
            if(jSInProcessRuntime == null)
            {
                return new byte[0] { };
            }

            return jSInProcessRuntime.Invoke<byte[]>($"{this.jsNamespace}.PublicKeyCredential.GetClientExtensionResults", this.domId);
        }

        internal void SetJSRuntime(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
            this.jSInProcessRuntime = (IJSInProcessRuntime)jSRuntime;
        }

        internal void SetDomId(Guid domId)
        {
            this.domId = domId;
        }
    }
}
