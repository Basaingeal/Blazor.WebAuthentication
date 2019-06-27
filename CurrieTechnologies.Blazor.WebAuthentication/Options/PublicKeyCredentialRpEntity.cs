namespace CurrieTechnologies.Blazor.WebAuthentication
{
    public class PublicKeyCredentialRpEntity
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
}
