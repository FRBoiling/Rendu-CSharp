using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
    /// <summary>Holder for reflection information generated from google/protobuf/duration.proto</summary>
    public static partial class DurationReflection {

        #region Descriptor
        /// <summary>File descriptor for google/protobuf/duration.proto</summary>
        public static FileDescriptor Descriptor {
            get { return descriptor; }
        }
        private static FileDescriptor descriptor;

        static DurationReflection() {
            byte[] descriptorData = global::System.Convert.FromBase64String(
                string.Concat(
                    "Ch5nb29nbGUvcHJvdG9idWYvZHVyYXRpb24ucHJvdG8SD2dvb2dsZS5wcm90",
                    "b2J1ZiIqCghEdXJhdGlvbhIPCgdzZWNvbmRzGAEgASgDEg0KBW5hbm9zGAIg",
                    "ASgFQnwKE2NvbS5nb29nbGUucHJvdG9idWZCDUR1cmF0aW9uUHJvdG9QAVoq",
                    "Z2l0aHViLmNvbS9nb2xhbmcvcHJvdG9idWYvcHR5cGVzL2R1cmF0aW9u+AEB",
                    "ogIDR1BCqgIeR29vZ2xlLlByb3RvYnVmLldlbGxLbm93blR5cGVzYgZwcm90",
                    "bzM="));
            descriptor = FileDescriptor.FromGeneratedCode(descriptorData,
                new FileDescriptor[] { },
                new GeneratedClrTypeInfo(null, new GeneratedClrTypeInfo[] {
                    new GeneratedClrTypeInfo(typeof(global::Google.Protobuf.WellKnownTypes.Duration), global::Google.Protobuf.WellKnownTypes.Duration.Parser, new[]{ "Seconds", "Nanos" }, null, null, null)
                }));
        }
        #endregion

    }
}