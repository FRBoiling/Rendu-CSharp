using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
    /// <summary>
    /// `NullValue` is a singleton enumeration to represent the null value for the
    /// `Value` type union.
    ///
    ///  The JSON representation for `NullValue` is JSON `null`.
    /// </summary>
    public enum NullValue {
        /// <summary>
        /// Null value.
        /// </summary>
        [OriginalName("NULL_VALUE")] NullValue = 0,
    }
}