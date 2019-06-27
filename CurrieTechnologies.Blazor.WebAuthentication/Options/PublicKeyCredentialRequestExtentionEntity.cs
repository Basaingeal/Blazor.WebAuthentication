namespace CurrieTechnologies.Blazor.WebAuthentication
{
    public partial class PublicKeyCredentialRequestExtentionEntity
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
    }
}
