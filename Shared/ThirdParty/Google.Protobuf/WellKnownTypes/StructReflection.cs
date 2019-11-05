using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
    /// <summary>Holder for reflection information generated from google/protobuf/struct.proto</summary>
    public static partial class StructReflection {

        #region Descriptor
        /// <summary>File descriptor for google/protobuf/struct.proto</summary>
        public static FileDescriptor Descriptor {
            get { return descriptor; }
        }
        private static FileDescriptor descriptor;

        static StructReflection() {
            byte[] descriptorData = global::System.Convert.FromBase64String(
                string.Concat(
                    "Chxnb29nbGUvcHJvdG9idWYvc3RydWN0LnByb3RvEg9nb29nbGUucHJvdG9i",
                    "dWYihAEKBlN0cnVjdBIzCgZmaWVsZHMYASADKAsyIy5nb29nbGUucHJvdG9i",
                    "dWYuU3RydWN0LkZpZWxkc0VudHJ5GkUKC0ZpZWxkc0VudHJ5EgsKA2tleRgB",
                    "IAEoCRIlCgV2YWx1ZRgCIAEoCzIWLmdvb2dsZS5wcm90b2J1Zi5WYWx1ZToC",
                    "OAEi6gEKBVZhbHVlEjAKCm51bGxfdmFsdWUYASABKA4yGi5nb29nbGUucHJv",
                    "dG9idWYuTnVsbFZhbHVlSAASFgoMbnVtYmVyX3ZhbHVlGAIgASgBSAASFgoM",
                    "c3RyaW5nX3ZhbHVlGAMgASgJSAASFAoKYm9vbF92YWx1ZRgEIAEoCEgAEi8K",
                    "DHN0cnVjdF92YWx1ZRgFIAEoCzIXLmdvb2dsZS5wcm90b2J1Zi5TdHJ1Y3RI",
                    "ABIwCgpsaXN0X3ZhbHVlGAYgASgLMhouZ29vZ2xlLnByb3RvYnVmLkxpc3RW",
                    "YWx1ZUgAQgYKBGtpbmQiMwoJTGlzdFZhbHVlEiYKBnZhbHVlcxgBIAMoCzIW",
                    "Lmdvb2dsZS5wcm90b2J1Zi5WYWx1ZSobCglOdWxsVmFsdWUSDgoKTlVMTF9W",
                    "QUxVRRAAQoEBChNjb20uZ29vZ2xlLnByb3RvYnVmQgtTdHJ1Y3RQcm90b1AB",
                    "WjFnaXRodWIuY29tL2dvbGFuZy9wcm90b2J1Zi9wdHlwZXMvc3RydWN0O3N0",
                    "cnVjdHBi+AEBogIDR1BCqgIeR29vZ2xlLlByb3RvYnVmLldlbGxLbm93blR5",
                    "cGVzYgZwcm90bzM="));
            descriptor = FileDescriptor.FromGeneratedCode(descriptorData,
                new FileDescriptor[] { },
                new GeneratedClrTypeInfo(new[] {typeof(global::Google.Protobuf.WellKnownTypes.NullValue), }, new GeneratedClrTypeInfo[] {
                    new GeneratedClrTypeInfo(typeof(global::Google.Protobuf.WellKnownTypes.Struct), global::Google.Protobuf.WellKnownTypes.Struct.Parser, new[]{ "Fields" }, null, null, new GeneratedClrTypeInfo[] { null, }),
                    new GeneratedClrTypeInfo(typeof(global::Google.Protobuf.WellKnownTypes.Value), global::Google.Protobuf.WellKnownTypes.Value.Parser, new[]{ "NullValue", "NumberValue", "StringValue", "BoolValue", "StructValue", "ListValue" }, new[]{ "Kind" }, null, null),
                    new GeneratedClrTypeInfo(typeof(global::Google.Protobuf.WellKnownTypes.ListValue), global::Google.Protobuf.WellKnownTypes.ListValue.Parser, new[]{ "Values" }, null, null, null)
                }));
        }
        #endregion

    }
}