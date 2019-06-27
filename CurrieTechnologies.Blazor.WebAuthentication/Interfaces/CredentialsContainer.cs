using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrieTechnologies.Blazor.WebAuthentication
{
    public class CredentialsContainer
    {
        private readonly IJSRuntime jSRuntime;
        private readonly IJSInProcessRuntime jSInProcessRuntime;
        private static readonly Dictionary<Guid, TaskCompletionSource<PublicKeyCredential?>> createPublicKeyRequests =
            new Dictionary<Guid, TaskCompletionSource<PublicKeyCredential?>>();

        private const string jsNamespace = "CurrieTechnologies.Blazor.WebAuthentication";
        public CredentialsContainer(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
            this.jSInProcessRuntime = (IJSInProcessRuntime)jSRuntime;
        }

        /// <summary>
        /// Create a <see cref="CredentialBase"/> asynchronously.
        /// </summary>
        /// <param name="options">
        /// <see href="https://www.w3.org/TR/2017/WD-credential-management-1-20170804/#dom-credentialscontainer-create"/>
        /// </param>
        /// <returns></returns>
        public async Task<CredentialBase?> CreateAsync(CredentialCreationOptions options)
        {
            if (!(options.PublicKey != null ^ options.Federated != null ^ options.Password != null))
            {
                return null;
            }
            if(options.Signal != null)
            {

            }
            if (options.PublicKey != null)
            {
                return await CreateAsync(options.PublicKey);
            }
            if (options.Federated != null)
            {
                throw new NotImplementedException();
            }
            if (options.Password != null)
            {
                throw new NotImplementedException();
            }

            throw new NotImplementedException();
        }

        private async Task<PublicKeyCredential?> CreateAsync(PublicKeyCredentialCreationOptions options)
        {
            var tcs = new TaskCompletionSource<PublicKeyCredential?>();
            var requestId = Guid.NewGuid();
            var domId = Guid.NewGuid();
            createPublicKeyRequests.Add(requestId, tcs);
            await jSRuntime.InvokeAsync<object>($"{jsNamespace}.CreatePublicKey", requestId, options, domId);
            var credentials = await tcs.Task;

            if (credentials == null)
            {
                return null;
            }

            credentials.SetJSRuntime(this.jSRuntime);
            credentials.SetDomId(domId);
            return credentials;
        }

        [JSInvokable]
        public static Task CompleteCreatePublicKey(string requestId, PublicKeyCredential credential)
        {
            var requestGuid = Guid.Parse(requestId);
            createPublicKeyRequests.TryGetValue(requestGuid, out TaskCompletionSource<PublicKeyCredential?> pendingTask);
            createPublicKeyRequests.Remove(requestGuid);
            pendingTask.SetResult(credential);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Request a credential from the credential manager.
        /// </summary>
        /// <param name="options">
        /// Contains an object filled with type-specific sets of parameters
        /// which will be used to select a particular <see cref="CredentialBase"/> to
        /// return.
        /// <see href="https://www.w3.org/TR/credential-management-1/#dom-credentialscontainer-get"/>
        /// </param>
        /// <returns></returns>
        public async Task<CredentialBase?> GetAsync(CredentialRequestOptions options)
        {
            if (!(options.Password != null ^ options.Federated != null ^ options.PublicKey != null))
            {
                return null;
            }
            if (options.PublicKey != null)
            {
                return await GetAsync(options.PublicKey);
            }
            if (options.Federated != null)
            {
                throw new NotImplementedException();
            }
            if (options.Password != null)
            {
                throw new NotImplementedException();
            }

            throw new NotImplementedException();
        }

        private async Task<PublicKeyCredential?> GetAsync(PublicKeyCredentialRequestOptions options)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ask the credential manager to store a <see cref="CredentialBase"/> for the user.
        /// Authors could call this method after a user successfully signs in, or
        /// after a successful password change operation.
        /// <see href="https://www.w3.org/TR/credential-management-1/#dom-credentialscontainer-store"/>
        /// </summary>
        /// <param name="credential"></param>
        /// <returns></returns>
        public async Task<CredentialBase> StoreAsync(CredentialBase credential)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ask the credential manager to require user mediation before returning
        /// credentials for the origin in which the method is called. This might be
        /// called after a user signs out of a website, for instance, in order to
        /// ensure that they are not automatically signed back in next time they
        /// visits.
        /// </summary>
        /// <returns></returns>
        public async Task PreventSilentAccessAsync()
        {
            throw new NotImplementedException();
        }
    }
}
