using System;
using System.Collections.Generic;
using System.Text;

namespace CurrieTechnologies.Blazor.WebAuthentication
{
    public class FederatedCredential : SiteBoundCredential
    {
        public override string Type { get; internal set; } = "federated";

        /// <summary>
        /// The credential’s federated identity provider. Must be a absolute,
        /// hierarchical, https URI with no path (e.g. https://www.facebook.com).
        /// <see href="https://www.w3.org/TR/credential-management-1/#dom-federatedcredential-provider"/>
        /// </summary>
        public string Provider { get; internal set; }

        /// <summary>
        /// The credential’s federated identity provider’s protocol (e.g.
        /// "openidconnect"). If this value is null, then the protocol can be
        /// inferred from the provider.
        /// <see href="https://www.w3.org/TR/credential-management-1/#dom-federatedcredential-protocol"/>
        /// </summary>
        public string? Protocol { get; internal set; }

        public FederatedCredential(FederatedCredentialData data)
        {
            Id = data.Id;
            Name = data.Name;
            Protocol = data.Protocol;
            Provider = data.Provider;
        }
    }
}
