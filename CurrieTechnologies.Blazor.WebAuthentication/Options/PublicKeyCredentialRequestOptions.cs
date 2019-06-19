namespace CurrieTechnologies.Blazor.WebAuthentication
{
    public class PublicKeyCredentialRequestOptions
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
        public CredentialDescriptor[]? AllowCredentials { get; set; }

        /// <summary>
        /// A string qualifying how the user verification should be part of the authentication process.
        /// </summary>
        public UserVerificationType? UserVerification { get; set; }

        /// <summary>
        /// An object with several client extensions' inputs.
        /// Those extensions are used to request additional processing (e.g. dealing with legacy FIDO APIs credentials, prompting a specific text on the authenticator, etc.).
        /// </summary>
        public Extention? Extensions { get; set; }

        public class Extention
        {
            /// <summary>
            /// FIDO appID.
            /// An appID which was used with legacy FIDO JS APIs to identify the current relying party.
            /// </summary>
            public string? AppId { get; set; }

            /// <summary>
            /// Simple transaction authorization.
            /// This text is displayed on a prompt of the authenticator before verifying the user or testing their presence.
            /// The client outputs a USVString which is the text as it was displayed (line breaks may have been added).
            /// </summary>
            public string? TxAuthSimple { get; set; }

            /// <summary>
            /// Generic transaction authorization.
            /// This is used to display an image or some non-textual content on the authenticator before verifying the user or testing their presence.
            /// The contentType gives the MIME type of the resource to be displayed while content gives its actual content.
            /// The client outputs the hash of the content which was displayed (hashing with the same algorithm which is used for the signature).
            /// </summary>
            public GenericTransactionAuthorization? TxAuthGeneric { get; set; }

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

            public class GenericTransactionAuthorization
            {
                /// <summary>
                /// Gives the MIME type of the resource to be displayed.
                /// </summary>
                public string? ContentType { get; set; }

                /// <summary>
                /// Gives the actual content
                /// </summary>
                public byte[]? Content { get; set; }
            }
        }
    }
}
