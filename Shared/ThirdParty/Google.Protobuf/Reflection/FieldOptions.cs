namespace Google.Protobuf.Reflection
{
    internal partial class FieldOptions
    {
        // We can't tell the difference between "explicitly set to false" and "not set"
        // in proto3, but we need to tell the difference for FieldDescriptor.IsPacked.
        // This won't work if we ever need to support proto2, but at that point we'll be
        // able to remove this hack and use field presence instead. 
        partial void OnConstruction()
        {
            Packed = true;
        }
    }
}