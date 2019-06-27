using System;
using System.Collections.Generic;
using System.Text;

namespace CurrieTechnologies.Blazor.WebAuthentication
{
    public class FederatedCredentialData : SiteBoundCredentialData
    {
        public string Provider { get; set; }
        public string? Protocol { get; set; }
    }
}
