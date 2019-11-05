using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
    /// <summary>Holder for reflection information generated from google/protobuf/any.proto</summary>
    public static partial class AnyReflection {

        #region Descriptor
        /// <summary>File descriptor for google/protobuf/any.proto</summary>
        public static FileDescriptor Descriptor {
            get { return descriptor; }
        }
        private static FileDescriptor descriptor;

        static AnyReflection() {
            byte[] descriptorData = global::System.Convert.FromBase64String(
                string.Concat(
                    "Chlnb29nbGUvcHJvdG9idWYvYW55LnByb3RvEg9nb29nbGUucHJvdG9idWYi",
                    "JgoDQW55EhAKCHR5cGVfdXJsGAEgASgJEg0KBXZhbHVlGAIgASgMQm8KE2Nv",
                    "bS5nb29nbGUucHJvdG9idWZCCEFueVByb3RvUAFaJWdpdGh1Yi5jb20vZ29s",
                    "YW5nL3Byb3RvYnVmL3B0eXBlcy9hbnmiAgNHUEKqAh5Hb29nbGUuUHJvdG9i",
                    "dWYuV2VsbEtub3duVHlwZXNiBnByb3RvMw=="));
            descriptor = FileDescriptor.FromGeneratedCode(descriptorData,
                new FileDescriptor[] { },
                new GeneratedClrTypeInfo(null, new GeneratedClrTypeInfo[] {
                    new GeneratedClrTypeInfo(typeof(global::Google.Protobuf.WellKnownTypes.Any), global::Google.Protobuf.WellKnownTypes.Any.Parser, new[]{ "TypeUrl", "Value" }, null, null, null)
                }));
        }
        #endregion

    }
}