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
        private static readonly Dictionary<Guid, TaskCompletionSource<PublicKeyCredential>> createPublicKeyRequests =
            new Dictionary<Guid, TaskCompletionSource<PublicKeyCredential>>();

        private const string jsNamespace = "CurrieTechnologies.Blazor.WebAuthentication";
        public CredentialsContainer(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
            this.jSInProcessRuntime = (IJSInProcessRuntime)jSRuntime;
        }

        public async Task<Credential?> CreateAsync(CredentialCreationOptions options)
        {
            if (!(options.PublicKey != null))
            {
                return null;
            }
            if (options.PublicKey != null)
            {
                return await CreateAsync(options.PublicKey);
            }

            return null;
        }

        public async Task<PublicKeyCredential> CreateAsync(PublicKeyCredentialCreationOptions options)
        {
            var tcs = new TaskCompletionSource<PublicKeyCredential>();
            var requestId = Guid.NewGuid();
            var domId = Guid.NewGuid();
            createPublicKeyRequests.Add(requestId, tcs);
            await jSRuntime.InvokeAsync<object>($"{jsNamespace}.CreatePublicKey", requestId, options, domId);
            var credentials = await tcs.Task;
            credentials.SetJSRuntime(this.jSRuntime);
            credentials.SetDomId(domId);
            return credentials;
        }

        [JSInvokable]
        public static Task CompleteCreatePublicKey(string requestId, PublicKeyCredential credential)
        {
            var requestGuid = Guid.Parse(requestId);
            createPublicKeyRequests.TryGetValue(requestGuid, out TaskCompletionSource<PublicKeyCredential> pendingTask);
            createPublicKeyRequests.Remove(requestGuid);
            pendingTask.SetResult(credential);
            return Task.CompletedTask;
        }

        public async Task<Credential?> GetAsync(CredentialRequestOptions options)
        {
            if(!(options.Password != null ^ options.PublicKey != null))
            {
                return null;
            }
            if (options.PublicKey != null)
            {
                return await GetAsync(options.PublicKey);
            }

            throw new NotImplementedException();
        }

        public async Task<PublicKeyCredential> GetAsync(PublicKeyCredentialRequestOptions options)
        {
            throw new NotImplementedException();
        }

        public async Task PreventSilentAccessAsync()
        {
            throw new NotImplementedException();
        }
    }
}
