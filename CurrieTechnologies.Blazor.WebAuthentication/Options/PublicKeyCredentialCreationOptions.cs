namespace CurrieTechnologies.Blazor.WebAuthentication
{
    /// <summary>
    /// Holds options passed to navigators.credentials.create() in order to create a PublicKeyCredential.
    /// </summary>
    public partial class PublicKeyCredentialCreationOptions
    {
        /// <summary>
        /// An object describing the relying party which requested the credential creation
        /// </summary>
        public PublicKeyCredentialRpEntity Rp { get; set; }

        /// <summary>
        /// An object describing the user account for which the credential is generated.
        /// </summary>
        public PublicKeyCredentialUserEntity User { get; set; }

        /// <summary>
        /// A byte[], emitted by the relying party's server and used as a cryptographic challenge.
        /// This value will be signed by the authenticator and the signature will be sent back as part of AuthenticatorAttestationResponse.AttestationObject.
        /// </summary>
        public byte[] Challenge { get; set; }

        /// <summary>
        /// An Array of element which specify the desired features of the credential, including its type and the algorithm used for the cryptographic signature operations.
        /// This array is sorted by descending order of preference.
        /// </summary>
        public PublicKeyCredentialParameter[] PubKeyCredParams { get; set; }

        /// <summary>
        /// A numerical hint, in milliseconds, which indicates the time the caller is willing to wait for the creation operation to complete.
        /// This hint may be overridden by the browser.
        /// </summary>
        public double? Timeout { get; set; }

        /// <summary>
        /// An Array of descriptors for existing credentials.
        /// This is provided by the relying party to avoid creating new public key credentials for an existing user who already have some.
        /// </summary>
        public PublicKeyCredentialDescriptor[]? ExcludeCredentials { get; set; }

        /// <summary>
        /// An object whose properties are criteria used to filter out the potential authenticators for the creation operation.
        /// </summary>
        public AuthenticatorSelectionCriteria? AuthenticatorSelection { get; set; }

        /// <summary>
        /// A string which indicates how the attestation (for the authenticator's origin) should be transported.
        /// </summary>
        public AttestationConveyancePreference? Attestation { get; set; }

        /// <summary>
        /// An object with several client extensions' inputs.
        /// Those extensions are used to request additional processing (e.g. dealing with legacy FIDO APIs credentials, prompting a specific text on the authenticator, etc.).
        /// </summary>
        public PublicKeyCredentialCreationExtensionEntity? Extentions { get; set; }
    }
}
