using System;
using System.Collections.Generic;

namespace CurrieTechnologies.Blazor.WebAuthentication
{
    public enum UserVerificationRequirement
    {
        /// <summary>
        /// User verification is required, the operation will fail if the response does not have the UV flag (as part of the AuthenticatorData property of AuthenticatorAttestationResponse.AttestationObject)
        /// </summary>
        Required,

        /// <summary>
        /// User verification is prefered, the operation will not fail if the response does not have the UV flag (as part of the AuthenticatorData property of AuthenticatorAttestationResponse.AttestationObject)
        /// </summary>
        Preferred,

        /// <summary>
        /// User verification should not be employed as to minimize the user interaction during the process.
        /// </summary>
        Discouraged
    }
}
