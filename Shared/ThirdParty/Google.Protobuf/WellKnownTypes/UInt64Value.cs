using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
    /// <summary>
    /// Wrapper message for `uint64`.
    ///
    /// The JSON representation for `UInt64Value` is JSON string.
    /// </summary>
    public sealed partial class UInt64Value : IMessage<UInt64Value> {
        private static readonly MessageParser<UInt64Value> _parser = new MessageParser<UInt64Value>(() => new UInt64Value());
        private UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageParser<UInt64Value> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageDescriptor Descriptor {
            get { return global::Google.Protobuf.WellKnownTypes.WrappersReflection.Descriptor.MessageTypes[3]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        MessageDescriptor IMessage.Descriptor {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public UInt64Value() {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public UInt64Value(UInt64Value other) : this() {
            value_ = other.value_;
            _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public UInt64Value Clone() {
            return new UInt64Value(this);
        }

        /// <summary>Field number for the "value" field.</summary>
        public const int ValueFieldNumber = 1;
        private ulong value_;
        /// <summary>
        /// The uint64 value.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public ulong Value {
            get { return value_; }
            set {
                value_ = value;
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
            return Equals(other as UInt64Value);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(UInt64Value other) {
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
            if (Value != 0UL) hash ^= Value.GetHashCode();
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
            if (Value != 0UL) {
                output.WriteRawTag(8);
                output.WriteUInt64(Value);
            }
            if (_unknownFields != null) {
                _unknownFields.WriteTo(output);
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize() {
            int size = 0;
            if (Value != 0UL) {
                size += 1 + CodedOutputStream.ComputeUInt64Size(Value);
            }
            if (_unknownFields != null) {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(UInt64Value other) {
            if (other == null) {
                return;
            }
            if (other.Value != 0UL) {
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
                        Value = input.ReadUInt64();
                        break;
                    }
                }
            }
        }

    }
}