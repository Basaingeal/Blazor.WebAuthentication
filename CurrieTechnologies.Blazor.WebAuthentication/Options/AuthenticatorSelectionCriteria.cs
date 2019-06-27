namespace CurrieTechnologies.Blazor.WebAuthentication
{
    public partial class AuthenticatorSelectionCriteria
    {
        /// <summary>
        /// A string which is either "platform" or "cross-platform".
        /// The former describes an authenticator which is bound to the client and which is generally not removable.
        /// The latter describes a device which may be used across different platform (such as a USB or NFC device).
        /// </summary>
        public AuthenticatorAttachment? AuthenticatorAttachment { get; set; }

        /// <summary>
        /// A boolean which indicated that the credential private key must be stored in the authenticator, the client or in a client device.
        /// The default value is false.
        /// </summary>
        public bool? RequireResidentKey { get; set; }

        /// <summary>
        /// A string qualifying how the user verification should be part of the authentication process.
        /// <para>
        /// The default value is "preferred".
        /// </para>
        /// </summary>
        public UserVerificationRequirement? UserVerification { get; set; }
    }
}
