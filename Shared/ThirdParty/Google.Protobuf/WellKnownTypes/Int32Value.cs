using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
    /// <summary>
    /// Wrapper message for `int32`.
    ///
    /// The JSON representation for `Int32Value` is JSON number.
    /// </summary>
    public sealed partial class Int32Value : IMessage<Int32Value> {
        private static readonly MessageParser<Int32Value> _parser = new MessageParser<Int32Value>(() => new Int32Value());
        private UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageParser<Int32Value> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageDescriptor Descriptor {
            get { return global::Google.Protobuf.WellKnownTypes.WrappersReflection.Descriptor.MessageTypes[4]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        MessageDescriptor IMessage.Descriptor {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Int32Value() {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Int32Value(Int32Value other) : this() {
            value_ = other.value_;
            _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Int32Value Clone() {
            return new Int32Value(this);
        }

        /// <summary>Field number for the "value" field.</summary>
        public const int ValueFieldNumber = 1;
        private int value_;
        /// <summary>
        /// The int32 value.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int Value {
            get { return value_; }
            set {
                value_ = value;
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
            return Equals(other as Int32Value);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(Int32Value other) {
            if (ReferenceEquals(other, null)) {
                return false;
            }
            if (ReferenceEquals(other, this)) {
                return true;
            }
            if (Value != other.Value) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
            int hash = 1;
            if (Value != 0) hash ^= Value.GetHashCode();
            if (_unknownFields != null) {
                hash ^= _unknownFields.GetHashCode();
            }
            return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString() {
            return JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(CodedOutputStream output) {
            if (Value != 0) {
                output.WriteRawTag(8);
                output.WriteInt32(Value);
            }
            if (_unknownFields != null) {
                _unknownFields.WriteTo(output);
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize() {
            int size = 0;
            if (Value != 0) {
                size += 1 + CodedOutputStream.ComputeInt32Size(Value);
            }
            if (_unknownFields != null) {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(Int32Value other) {
            if (other == null) {
                return;
            }
            if (other.Value != 0) {
                Value = other.Value;
            }
            _unknownFields = UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(CodedInputStream input) {
            uint tag;
            while ((tag = input.ReadTag()) != 0) {
                switch(tag) {
                    default:
                        _unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
                        break;
                    case 8: {
                        Value = input.ReadInt32();
                        break;
                    }
                }
            }
        }

    }
}