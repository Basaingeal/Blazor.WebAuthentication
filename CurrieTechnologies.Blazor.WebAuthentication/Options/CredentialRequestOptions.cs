using System;
using System.Collections.Generic;
using System.Text;

namespace CurrieTechnologies.Blazor.WebAuthentication
{
    public class CredentialRequestOptions
    {
        public bool? Password { get; set; }
        public PublicKeyCredentialRequestOptions? PublicKey { get; set; }
        public bool? Unmediated { get; set; }
    }
}
