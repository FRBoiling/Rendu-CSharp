using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
    /// <summary>Holder for reflection information generated from google/protobuf/empty.proto</summary>
    public static partial class EmptyReflection {

        #region Descriptor
        /// <summary>File descriptor for google/protobuf/empty.proto</summary>
        public static FileDescriptor Descriptor {
            get { return descriptor; }
        }
        private static FileDescriptor descriptor;

        static EmptyReflection() {
            byte[] descriptorData = global::System.Convert.FromBase64String(
                string.Concat(
                    "Chtnb29nbGUvcHJvdG9idWYvZW1wdHkucHJvdG8SD2dvb2dsZS5wcm90b2J1",
                    "ZiIHCgVFbXB0eUJ2ChNjb20uZ29vZ2xlLnByb3RvYnVmQgpFbXB0eVByb3Rv",
                    "UAFaJ2dpdGh1Yi5jb20vZ29sYW5nL3Byb3RvYnVmL3B0eXBlcy9lbXB0efgB",
                    "AaICA0dQQqoCHkdvb2dsZS5Qcm90b2J1Zi5XZWxsS25vd25UeXBlc2IGcHJv",
                    "dG8z"));
            descriptor = FileDescriptor.FromGeneratedCode(descriptorData,
                new FileDescriptor[] { },
                new GeneratedClrTypeInfo(null, new GeneratedClrTypeInfo[] {
                    new GeneratedClrTypeInfo(typeof(global::Google.Protobuf.WellKnownTypes.Empty), global::Google.Protobuf.WellKnownTypes.Empty.Parser, null, null, null, null)
                }));
        }
        #endregion

    }
}