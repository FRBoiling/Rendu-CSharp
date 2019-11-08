namespace Rd.CodeGeneration
{
    public class Diagnosis
    {
        public readonly DiagnosisSeverity severity;
        public readonly string symptoms;
        public readonly string treatment;

        public Diagnosis(string symptoms, string treatment, DiagnosisSeverity severity)
        {
            this.symptoms = symptoms;
            this.treatment = treatment;
            this.severity = severity;
        }

        public static Diagnosis Healthy => new Diagnosis(null, null, DiagnosisSeverity.Healthy);
    }
}