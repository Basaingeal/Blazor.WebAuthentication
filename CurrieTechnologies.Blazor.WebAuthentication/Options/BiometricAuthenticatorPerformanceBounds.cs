namespace CurrieTechnologies.Blazor.WebAuthentication
{
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
