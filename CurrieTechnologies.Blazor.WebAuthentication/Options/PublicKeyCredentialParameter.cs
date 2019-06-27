namespace CurrieTechnologies.Blazor.WebAuthentication
{
    public class PublicKeyCredentialParameter
    {
        /// <summary>
        /// A string describing type of public-key credential to be created.
        /// As of this writing (June 2019), only "public-key" may be used.
        /// </summary>
        public PublicKeyCredentialType Type { get; set; }

        /// <summary>
        /// A numeric identifier for the algorithm to be used to generate the key pair.
        /// The links between identifier and algorithms are defined in this IANA registry (e.g. -7 indicates the elliptic curve algorithm ECDSA with SHA-256).
        /// </summary>
        public int Alg { get; set; }
    }
}
