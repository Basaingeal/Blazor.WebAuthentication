namespace CurrieTechnologies.Blazor.WebAuthentication
{
    public class PublicKeyCredentialUserEntity
    {
        /// <summary>
        /// A string which is human readable and intended for display.
        /// It may be the full name of the user (e.g. "John Doe").
        /// This is not intended to store the login of the user.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// An URL which points to an image resource which can be the avatar image for the user.
        /// </summary>
        public string? Icon { get; set; }

        /// <summary>
        /// A byte[] uniquely identifying a given user.
        /// This an opaque identifier which can be used by the authenticator to link the user account with its corresponding credentials.
        /// This value will later be used when fetching the credentials in AuthenticatorAssertionResponse.UserHandle.
        /// </summary>
        public byte[] Id { get; set; }

        /// <summary>
        /// A string giving a human-readable name for the user's identifier (e.g. "jdoe@example.com").
        /// This property is intended for display and may be use to distinguish different account with the same DisplayName.
        /// </summary>
        public string Name { get; set; }
    }
}
