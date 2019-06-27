namespace CurrieTechnologies.Blazor.WebAuthentication
{
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
