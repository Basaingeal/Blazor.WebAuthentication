using System;
using System.Collections.Generic;

namespace CurrieTechnologies.Blazor.WebAuthentication
{
    public enum CredentialTransportType
    {
        /// <summary>
        /// The authenticator can be contacted via a removable USB link.
        /// </summary>
        USB,

        /// <summary>
        /// The authenticator may be used over NFC.
        /// </summary>
        NFC,

        /// <summary>
        /// The authenticator may be used over BLE.
        /// </summary>
        BLE,

        /// <summary>
        /// The authenticator is specifically bound to the client device (cannot be removed).
        /// </summary>
        Internal
    }
}
