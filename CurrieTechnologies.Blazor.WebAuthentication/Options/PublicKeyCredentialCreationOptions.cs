using System;
using System.Collections.Generic;

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
        public RelyingParty Rp { get; set; }

        /// <summary>
        /// An object describing the user account for which the credential is generated.
        /// </summary>
        public UserAccount User { get; set; }

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
        public CredentialDescriptor[]? ExcludeCredentials { get; set; }

        /// <summary>
        /// An object whose properties are criteria used to filter out the potential authenticators for the creation operation.
        /// </summary>
        public AuthenticatorSelectionCriteria? AuthenticatorSelection { get; set; }

        /// <summary>
        /// A string which indicates how the attestation (for the authenticator's origin) should be transported.
        /// </summary>
        public AttestationType? Attestation { get; set; }

        /// <summary>
        /// An object with several client extensions' inputs.
        /// Those extensions are used to request additional processing (e.g. dealing with legacy FIDO APIs credentials, prompting a specific text on the authenticator, etc.).
        /// </summary>
        public Extension? Extentions { get; set; }

        public class RelyingParty
        {
            /// <summary>
            /// An URL which points to an image resource which can be the logo/icon of the relying party.
            /// </summary>
            public string? Icon { get; set; }

            /// <summary>
            /// A string uniquely identifying a relying party.
            /// The default value of this property is the domain of the current document (e.g. "login.example.com").
            /// It may be overridden with a suffix of the current domain (e.g. "example.com").
            /// </summary>
            public string Id { get; set; }

            /// <summary>
            /// A string giving a human-readable name for the relying party.
            /// This property is intended for display (e.g. "Example CORP").
            /// </summary>
            public string Name { get; set; }
        }

        public class UserAccount
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

        public class PublicKeyCredentialParameter
        {
            /// <summary>
            /// A string describing type of public-key credential to be created.
            /// As of this writing (June 2019), only "public-key" may be used.
            /// </summary>
            public CredentialType Type { get; set; }

            /// <summary>
            /// A numeric identifier for the algorithm to be used to generate the key pair.
            /// The links between identifier and algorithms are defined in this IANA registry (e.g. -7 indicates the elliptic curve algorithm ECDSA with SHA-256).
            /// </summary>
            public int Alg { get; set; }
        }

        public partial class AuthenticatorSelectionCriteria
        {
            /// <summary>
            /// A string which is either "platform" or "cross-platform".
            /// The former describes an authenticator which is bound to the client and which is generally not removable.
            /// The latter describes a device which may be used across different platform (such as a USB or NFC device).
            /// </summary>
            public AuthenticatorAttachmentType? AuthenticatorAttachment { get; set; }

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
            public UserVerificationType? UserVerification { get; set; }

            public enum AuthenticatorAttachmentType
            {
                Platform,
                CrossPlaform
            }
        }

        public enum AttestationType
        {
            /// <summary>
            ///  The relying party is not interested in this attestation.
            ///  This avoids making a check with the attestation certificate authority and asking the user consent for sharing identifying information.
            /// </summary>
            None,

            /// <summary>
            /// The client may change the assertion from the authenticator (for instance, using an anonymization CA).
            /// This value is used when the relying party wishes to verify the attestation.
            /// </summary>
            Indirect,

            /// <summary>
            /// The relying party wants to receive the attestation as generated by the authenticator.
            /// </summary>
            Direct
        }

        public class Extension
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

            public class BiometricAuthenticatorPerformanceBounds
            {
                /// <summary>
                /// False acceptance rate.
                /// </summary>
                public double? FAR { get; set; }

                /// <summary>
                /// False rejection rate
                /// </summary>
                public double? FRR { get; set; }
            }
        }
    }
}
