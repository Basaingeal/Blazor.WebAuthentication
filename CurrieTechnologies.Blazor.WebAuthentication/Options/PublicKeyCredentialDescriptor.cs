namespace CurrieTechnologies.Blazor.WebAuthentication
{
    public class PublicKeyCredentialDescriptor
    {
        /// <summary>
        /// A string describing type of public-key credential to be created.
        /// As of this writing (June 2019), only "public-key" may be used.
        /// </summary>
        public PublicKeyCredentialType Type { get; set; }

        /// <summary>
        /// A byte[] matching an existing public key credential identifier (PublicKeyCredential.RawId).
        /// This identifier is generated during the creation of the PublicKeyCredential instance.
        /// </summary>
        public byte[] Id { get; set; }

        /// <summary>
        /// An Array of strings describing the possible transports between the client and the authenticator.
        /// </summary>
        public AuthenticatorTransport[]? Transports { get; set; }
    }
}
