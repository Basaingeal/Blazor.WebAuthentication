namespace CurrieTechnologies.Blazor.WebAuthentication
{
    public partial class PublicKeyCredentialCreationExtensionEntity
    {
        /// <summary>
        /// Authenticator selection.
        /// Restricts the list of authenticator models which may be used.
        /// If no matching authenticator is available, the credential is still generated with another available authenticator.
        /// </summary>
        public byte[]? AuthnSel { get; set; }

        /// <summary>
        /// Supported extensions.
        /// If true, the client outputs an array of strings containing the extensions which are supported by the authenticator.
        /// </summary>
        public bool? Exts { get; set; }

        /// <summary>
        /// User verification index.
        /// If true, the client outputs an ArrayBuffer which contains a value uniquely identifying a user verification data record.
        /// In other words, this may be used server side to check if the current operation is based on the same biometric data that the previous authentication.
        /// </summary>
        public bool? Uvi { get; set; }

        /// <summary>
        /// Location.
        /// If true, the client outputs a Coordinates object representing the geolocation of the authenticator.
        /// </summary>
        public bool? Loc { get; set; }

        /// <summary>
        /// User verification method.
        /// If true, the client outputs an array of arrays with 3 values containing information about how the user was verified (e.g. fingerprint, pin, pattern), how the key is protected, how the matcher (tool used for the authentication operation) is protected.
        /// </summary>
        public bool? Uvm { get; set; }

        /// <summary>
        /// Biometric authenticator performance bounds.
        /// The client must not use any authenticator with false acceptance rate (FAR) and false rejection rate (FRR) below the inputs.
        /// The client outputs true if this was taken into account.
        /// </summary>
        public BiometricAuthenticatorPerformanceBounds? BiometricPerfBounds { get; set; }
    }
}
