using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
    /// <summary>Holder for reflection information generated from google/protobuf/field_mask.proto</summary>
    public static partial class FieldMaskReflection {

        #region Descriptor
        /// <summary>File descriptor for google/protobuf/field_mask.proto</summary>
        public static FileDescriptor Descriptor {
            get { return descriptor; }
        }
        private static FileDescriptor descriptor;

        static FieldMaskReflection() {
            byte[] descriptorData = global::System.Convert.FromBase64String(
                string.Concat(
                    "CiBnb29nbGUvcHJvdG9idWYvZmllbGRfbWFzay5wcm90bxIPZ29vZ2xlLnBy",
                    "b3RvYnVmIhoKCUZpZWxkTWFzaxINCgVwYXRocxgBIAMoCUKJAQoTY29tLmdv",
                    "b2dsZS5wcm90b2J1ZkIORmllbGRNYXNrUHJvdG9QAVo5Z29vZ2xlLmdvbGFu",
                    "Zy5vcmcvZ2VucHJvdG8vcHJvdG9idWYvZmllbGRfbWFzaztmaWVsZF9tYXNr",
                    "ogIDR1BCqgIeR29vZ2xlLlByb3RvYnVmLldlbGxLbm93blR5cGVzYgZwcm90",
                    "bzM="));
            descriptor = FileDescriptor.FromGeneratedCode(descriptorData,
                new FileDescriptor[] { },
                new GeneratedClrTypeInfo(null, new GeneratedClrTypeInfo[] {
                    new GeneratedClrTypeInfo(typeof(global::Google.Protobuf.WellKnownTypes.FieldMask), global::Google.Protobuf.WellKnownTypes.FieldMask.Parser, new[]{ "Paths" }, null, null, null)
                }));
        }
        #endregion

    }
}