namespace CurrieTechnologies.Blazor.WebAuthentication
{
    public partial class PublicKeyCredentialRequestOptions
    {
        /// <summary>
        /// A BufferSource, emitted by the relying party's server and used as a cryptographic challenge.
        /// This value will be signed by the authenticator and the signature will be sent back as part of AuthenticatorAssertionResponse.Signature.
        /// </summary>
        public byte[] Challenge { get; set; }

        /// <summary>
        /// A numerical hint, in milliseconds, which indicates the time the caller is willing to wait for the retrieval operation to complete.
        /// This hint may be overridden by the browser.
        /// </summary>
        public double? Timeout { get; set; }

        /// <summary>
        /// A string which indicates the relying party's identifier (ex. "login.example.org").
        /// If this option is not provided, the client will use the current origin's domain.
        /// </summary>
        public string? RpId { get; set; }

        /// <summary>
        /// An Array of credential descriptors which restricts the acceptable existing credentials for retrieval.
        /// </summary>
        public PublicKeyCredentialDescriptor[]? AllowCredentials { get; set; }

        /// <summary>
        /// A string qualifying how the user verification should be part of the authentication process.
        /// </summary>
        public UserVerificationRequirement? UserVerification { get; set; }

        /// <summary>
        /// An object with several client extensions' inputs.
        /// Those extensions are used to request additional processing (e.g. dealing with legacy FIDO APIs credentials, prompting a specific text on the authenticator, etc.).
        /// </summary>
        public PublicKeyCredentialRequestExtentionEntity? Extensions { get; set; }
    }
}
