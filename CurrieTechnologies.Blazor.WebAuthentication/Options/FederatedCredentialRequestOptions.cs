namespace CurrieTechnologies.Blazor.WebAuthentication
{
    /// <summary>
    /// <see href="https://www.w3.org/TR/credential-management-1/#dictdef-federatedcredentialrequestoptions"/>
    /// </summary>
    public class FederatedCredentialRequestOptions
    {
        /// <summary>
        /// An array of federation identifiers.
        /// <see href="https://www.w3.org/TR/credential-management-1/#dom-federatedcredentialrequestoptions-providers"/>
        /// </summary>
        public string[]? Providers { get; set; }

        /// <summary>
        /// An array of protocol identifiers.
        /// <see href="https://www.w3.org/TR/credential-management-1/#dom-federatedcredentialrequestoptions-protocols"/>
        /// </summary>
        public string[]? Protocols { get; set; }
    }
}