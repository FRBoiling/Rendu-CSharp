using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
    /// <summary>
    /// The syntax in which a protocol buffer element is defined.
    /// </summary>
    public enum Syntax {
        /// <summary>
        /// Syntax `proto2`.
        /// </summary>
        [OriginalName("SYNTAX_PROTO2")] Proto2 = 0,
        /// <summary>
        /// Syntax `proto3`.
        /// </summary>
        [OriginalName("SYNTAX_PROTO3")] Proto3 = 1,
    }
}