using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
    /// <summary>Holder for reflection information generated from google/protobuf/timestamp.proto</summary>
    public static partial class TimestampReflection {

        #region Descriptor
        /// <summary>File descriptor for google/protobuf/timestamp.proto</summary>
        public static FileDescriptor Descriptor {
            get { return descriptor; }
        }
        private static FileDescriptor descriptor;

        static TimestampReflection() {
            byte[] descriptorData = global::System.Convert.FromBase64String(
                string.Concat(
                    "Ch9nb29nbGUvcHJvdG9idWYvdGltZXN0YW1wLnByb3RvEg9nb29nbGUucHJv",
                    "dG9idWYiKwoJVGltZXN0YW1wEg8KB3NlY29uZHMYASABKAMSDQoFbmFub3MY",
                    "AiABKAVCfgoTY29tLmdvb2dsZS5wcm90b2J1ZkIOVGltZXN0YW1wUHJvdG9Q",
                    "AVorZ2l0aHViLmNvbS9nb2xhbmcvcHJvdG9idWYvcHR5cGVzL3RpbWVzdGFt",
                    "cPgBAaICA0dQQqoCHkdvb2dsZS5Qcm90b2J1Zi5XZWxsS25vd25UeXBlc2IG",
                    "cHJvdG8z"));
            descriptor = FileDescriptor.FromGeneratedCode(descriptorData,
                new FileDescriptor[] { },
                new GeneratedClrTypeInfo(null, new GeneratedClrTypeInfo[] {
                    new GeneratedClrTypeInfo(typeof(global::Google.Protobuf.WellKnownTypes.Timestamp), global::Google.Protobuf.WellKnownTypes.Timestamp.Parser, new[]{ "Seconds", "Nanos" }, null, null, null)
                }));
        }
        #endregion

    }
}