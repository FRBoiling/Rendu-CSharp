﻿using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
    /// <summary>Holder for reflection information generated from google/protobuf/api.proto</summary>
    public static partial class ApiReflection {

        #region Descriptor
        /// <summary>File descriptor for google/protobuf/api.proto</summary>
        public static FileDescriptor Descriptor {
            get { return descriptor; }
        }
        private static FileDescriptor descriptor;

        static ApiReflection() {
            byte[] descriptorData = global::System.Convert.FromBase64String(
                string.Concat(
                    "Chlnb29nbGUvcHJvdG9idWYvYXBpLnByb3RvEg9nb29nbGUucHJvdG9idWYa",
                    "JGdvb2dsZS9wcm90b2J1Zi9zb3VyY2VfY29udGV4dC5wcm90bxoaZ29vZ2xl",
                    "L3Byb3RvYnVmL3R5cGUucHJvdG8igQIKA0FwaRIMCgRuYW1lGAEgASgJEigK",
                    "B21ldGhvZHMYAiADKAsyFy5nb29nbGUucHJvdG9idWYuTWV0aG9kEigKB29w",
                    "dGlvbnMYAyADKAsyFy5nb29nbGUucHJvdG9idWYuT3B0aW9uEg8KB3ZlcnNp",
                    "b24YBCABKAkSNgoOc291cmNlX2NvbnRleHQYBSABKAsyHi5nb29nbGUucHJv",
                    "dG9idWYuU291cmNlQ29udGV4dBImCgZtaXhpbnMYBiADKAsyFi5nb29nbGUu",
                    "cHJvdG9idWYuTWl4aW4SJwoGc3ludGF4GAcgASgOMhcuZ29vZ2xlLnByb3Rv",
                    "YnVmLlN5bnRheCLVAQoGTWV0aG9kEgwKBG5hbWUYASABKAkSGAoQcmVxdWVz",
                    "dF90eXBlX3VybBgCIAEoCRIZChFyZXF1ZXN0X3N0cmVhbWluZxgDIAEoCBIZ",
                    "ChFyZXNwb25zZV90eXBlX3VybBgEIAEoCRIaChJyZXNwb25zZV9zdHJlYW1p",
                    "bmcYBSABKAgSKAoHb3B0aW9ucxgGIAMoCzIXLmdvb2dsZS5wcm90b2J1Zi5P",
                    "cHRpb24SJwoGc3ludGF4GAcgASgOMhcuZ29vZ2xlLnByb3RvYnVmLlN5bnRh",
                    "eCIjCgVNaXhpbhIMCgRuYW1lGAEgASgJEgwKBHJvb3QYAiABKAlCdQoTY29t",
                    "Lmdvb2dsZS5wcm90b2J1ZkIIQXBpUHJvdG9QAVorZ29vZ2xlLmdvbGFuZy5v",
                    "cmcvZ2VucHJvdG8vcHJvdG9idWYvYXBpO2FwaaICA0dQQqoCHkdvb2dsZS5Q",
                    "cm90b2J1Zi5XZWxsS25vd25UeXBlc2IGcHJvdG8z"));
            descriptor = FileDescriptor.FromGeneratedCode(descriptorData,
                new FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.SourceContextReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.TypeReflection.Descriptor, },
                new GeneratedClrTypeInfo(null, new GeneratedClrTypeInfo[] {
                    new GeneratedClrTypeInfo(typeof(global::Google.Protobuf.WellKnownTypes.Api), global::Google.Protobuf.WellKnownTypes.Api.Parser, new[]{ "Name", "Methods", "Options", "Version", "SourceContext", "Mixins", "Syntax" }, null, null, null),
                    new GeneratedClrTypeInfo(typeof(global::Google.Protobuf.WellKnownTypes.Method), global::Google.Protobuf.WellKnownTypes.Method.Parser, new[]{ "Name", "RequestTypeUrl", "RequestStreaming", "ResponseTypeUrl", "ResponseStreaming", "Options", "Syntax" }, null, null, null),
                    new GeneratedClrTypeInfo(typeof(global::Google.Protobuf.WellKnownTypes.Mixin), global::Google.Protobuf.WellKnownTypes.Mixin.Parser, new[]{ "Name", "Root" }, null, null, null)
                }));
        }
        #endregion

    }
}