using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
    /// <summary>Holder for reflection information generated from google/protobuf/source_context.proto</summary>
    public static partial class SourceContextReflection {

        #region Descriptor
        /// <summary>File descriptor for google/protobuf/source_context.proto</summary>
        public static FileDescriptor Descriptor {
            get { return descriptor; }
        }
        private static FileDescriptor descriptor;

        static SourceContextReflection() {
            byte[] descriptorData = global::System.Convert.FromBase64String(
                string.Concat(
                    "CiRnb29nbGUvcHJvdG9idWYvc291cmNlX2NvbnRleHQucHJvdG8SD2dvb2ds",
                    "ZS5wcm90b2J1ZiIiCg1Tb3VyY2VDb250ZXh0EhEKCWZpbGVfbmFtZRgBIAEo",
                    "CUKVAQoTY29tLmdvb2dsZS5wcm90b2J1ZkISU291cmNlQ29udGV4dFByb3Rv",
                    "UAFaQWdvb2dsZS5nb2xhbmcub3JnL2dlbnByb3RvL3Byb3RvYnVmL3NvdXJj",
                    "ZV9jb250ZXh0O3NvdXJjZV9jb250ZXh0ogIDR1BCqgIeR29vZ2xlLlByb3Rv",
                    "YnVmLldlbGxLbm93blR5cGVzYgZwcm90bzM="));
            descriptor = FileDescriptor.FromGeneratedCode(descriptorData,
                new FileDescriptor[] { },
                new GeneratedClrTypeInfo(null, new GeneratedClrTypeInfo[] {
                    new GeneratedClrTypeInfo(typeof(global::Google.Protobuf.WellKnownTypes.SourceContext), global::Google.Protobuf.WellKnownTypes.SourceContext.Parser, new[]{ "FileName" }, null, null, null)
                }));
        }
        #endregion

    }
}