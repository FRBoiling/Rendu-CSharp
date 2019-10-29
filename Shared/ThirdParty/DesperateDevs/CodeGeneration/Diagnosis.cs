namespace DesperateDevs.CodeGeneration
{
    public class Diagnosis
    {
        public readonly string symptoms;
        public readonly string treatment;
        public readonly DiagnosisSeverity severity;

        public static Diagnosis Healthy
        {
            get
            {
                return new Diagnosis((string) null, (string) null, DiagnosisSeverity.Healthy);
            }
        }

        public Diagnosis(string symptoms, string treatment, DiagnosisSeverity severity)
        {
            this.symptoms = symptoms;
            this.treatment = treatment;
            this.severity = severity;
        }
    }
}